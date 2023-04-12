using System.Text;
using Domain.ErrorEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace Utilities.Middleware;

public class LoggingMiddleware
{
    private const int ReadChunkBufferLength = 4096;
    private static readonly ActionDescriptor EmptyActionDescriptor = new();
    private readonly IActionResultExecutor<ObjectResult> _executor;
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory,
        IActionResultExecutor<ObjectResult> executor)
    {
        _next = next;
        _executor = executor;
        _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestData = GetRequestData(context);
        var requestDisplayUrl = context.Request.GetDisplayUrl();
        try
        {
            await LogRequest(context.Request);
            await LogResponseAsync(context);
        }
        catch (Exception ex)
        {
            var routeData = context.GetRouteData();

            _logger.LogError(ex,
                "An unhandled exception has occurred while executing the request. " +
                "\nUrl: {RequestDisplayUrl}. " +
                "\nRequest Data: {RequestData}", requestDisplayUrl, requestData);

            var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);

            var statusCode = context.Response.StatusCode;
            var msg = "";
            switch (statusCode)
            {
                case 401:
                    msg = "You are not authorized to access this information";
                    break;
                case 403:
                    msg = "You are forbidden to access this information";
                    break;
                case 404:
                    msg = "This content is not found or either deleted";
                    break;
                case 400:
                    msg = "This request is not valid";
                    break;
                case 500:
                    msg = "Internal server error occured";
                    break;
                default:
                {
                    if (statusCode != 100)
                        msg = "Unknown";
                    break;
                }
            }

            var result = new ObjectResult(
                new ErrorResponse(
                    ex.Message))
            {
                StatusCode = statusCode
            };

            ClearCacheHeaders(context.Response);

            if (!string.IsNullOrWhiteSpace(msg))
                await HandleExceptionAsync(statusCode, msg);

            await _executor.ExecuteAsync(actionContext, result);
        }
    }

    private static async Task HandleExceptionAsync(int statusCode, string msg)
    {
        await Task.FromResult(JsonConvert.SerializeObject(new ErrorResult
        {
            Success = false,
            Msg = msg,
            Type = statusCode.ToString()
        }));
    }

    private static string GetRequestData(HttpContext context)
    {
        var sb = new StringBuilder();

        if (context.Request.HasFormContentType && context.Request.Form.Any())
        {
            sb.Append("Form variables:");
            foreach (var x in context.Request.Form) sb.Append($"Key={x.Key}, Value={x.Value}<br/>");
        }

        sb.AppendLine("Method: " + context.Request.Method);

        return sb.ToString();
    }

    private static void ClearCacheHeaders(HttpResponse response)
    {
        response.Headers[HeaderNames.CacheControl] = "no-cache";
        response.Headers[HeaderNames.Pragma] = "no-cache";
        response.Headers[HeaderNames.Expires] = "-1";
        response.Headers.Remove(HeaderNames.ETag);
    }

    private async Task LogRequest(HttpRequest request)
    {
        request.EnableBuffering();
        await using var requestStream = _recyclableMemoryStreamManager.GetStream();
        await request.Body.CopyToAsync(requestStream);
        request.Body.Position = 0;

        var queryStringNullOrNot = request.QueryString.HasValue ? request.QueryString.Value : "No query string";

        var readStreamInChunks = await ReadStreamInChunks(requestStream);

        _logger.LogInformation("\nHttp Ticket Information:" +
                               "\nSchema:{RequestScheme} " +
                               "\nHost: {RequestHost} " +
                               "\nPath: {RequestPath} " +
                               "\nQueryString: {RequestQueryString} " +
                               "\nRequest Body: {ReadStreamInChunks} \n"
            , request.Scheme, request.Host,
            request.Path, queryStringNullOrNot, readStreamInChunks);
    }

    private async Task LogResponseAsync(HttpContext context)
    {
        var originalBody = context.Response.Body;
        await using var responseStream = _recyclableMemoryStreamManager.GetStream();
        context.Response.Body = responseStream;
        await responseStream.CopyToAsync(originalBody);

        var readStreamInChunks = await ReadStreamInChunks(responseStream);

        var queryStringNullOrNot = context.Request.QueryString.HasValue
            ? context.Request.QueryString.Value
            : "No query string";

        _logger.LogInformation("\nHttp Response Information\n" +
                               "\nSchema:{ContextTicketScheme} " +
                               "\nHost: {ContextTicketHost} " +
                               "\nPath: {ContextTicketPath} " +
                               "\nQueryString: {ContextTicketQueryString} " +
                               "\nResponse Body: {ReadStreamInChunks} \n",
            context.Request.Scheme, context.Request.Host,
            context.Request.Path, queryStringNullOrNot, readStreamInChunks);

        context.Response.Body = originalBody;
        await _next.Invoke(context);
    }


    private static async Task<string> ReadStreamInChunks(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        await using var textWriter = new StringWriter();
        using var reader = new StreamReader(stream);
        var readChunk = new char[ReadChunkBufferLength];
        int readChunkLength;
        //do while: is useful for the last iteration in case readChunkLength < chunkLength
        do
        {
            readChunkLength = await reader.ReadBlockAsync(readChunk, 0, ReadChunkBufferLength);
            await textWriter.WriteAsync(readChunk, 0, readChunkLength);
        } while (readChunkLength > 0);

        var result = textWriter.ToString();
        stream.Seek(0, SeekOrigin.Begin);

        return result;
    }
}
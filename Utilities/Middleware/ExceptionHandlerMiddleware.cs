using System.Net;
using System.Text;
using Domain.ErrorEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Utilities.HttpException;

namespace Utilities.Middleware;

public class ExceptionHandlerMiddleware
{
    private const int ReadChunkBufferLength = 4096;
    private static readonly ActionDescriptor EmptyActionDescriptor = new();
    private readonly IActionResultExecutor<ObjectResult> _executor;
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory,
        IActionResultExecutor<ObjectResult> executor)
    {
        _next = next;
        _executor = executor;
        _logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await LogRequest(context.Request);
            await LogResponseAsync(context);
        }
        catch (Exception exception)
        {
            var requestData = GetRequestData(context);
            var requestDisplayUrl = context.Request.GetDisplayUrl();

            _logger.LogError(exception,
                "An unhandled exception has occurred while executing the request. " +
                "\nUrl: {RequestDisplayUrl}. " +
                "\nRequest Data: {RequestData}", requestDisplayUrl, requestData);

            var errorId = Guid.NewGuid().ToString();

            var errorResult = new ErrorResult
            {
                Source = exception.TargetSite?.DeclaringType?.FullName,
                Exception = exception.Message.Trim(),
                ErrorId = errorId,
                SupportMessage = $"Provide the Error Id: {errorId} to the support team for further analysis."
            };

            errorResult.Message.Add(exception.Message);

            if (exception is not CustomException && exception.InnerException != null)
                while (exception.InnerException != null)
                    exception = exception.InnerException;

            switch (exception)
            {
                case CustomException e:
                    errorResult.StatusCode = (int)e.StatusCode;
                    if (e.ErrorMessages is not null) errorResult.Message = e.ErrorMessages;

                    break;

                case KeyNotFoundException:
                    errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            ClearCacheHeaders(context.Response);

            var response = context.Response;

            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = errorResult.StatusCode;
                await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
            }
            else
            {
                Console.WriteLine("Can't write error response. Response has already started.");
            }
        }
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
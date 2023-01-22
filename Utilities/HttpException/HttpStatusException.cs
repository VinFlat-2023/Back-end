using System.Net;
using Newtonsoft.Json.Linq;

namespace Utilities.HttpException;

public class HttpStatusException : Exception
{
    public HttpStatusException(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }

    public HttpStatusException(HttpStatusCode statusCode, string message)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusException(HttpStatusCode statusCode, Exception inner)
        : this(statusCode, inner.ToString())
    {
    }

    public HttpStatusException(HttpStatusCode statusCode, JObject errorObject)
        : this(statusCode, errorObject.ToString())
    {
        ContentType = @"application/json";
    }

    private HttpStatusCode StatusCode { get; }
    private string ContentType { get; } = @"text/plain";
}
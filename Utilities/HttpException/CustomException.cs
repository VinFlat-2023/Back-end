using System.Net;

namespace Utilities.HttpException;

public class CustomException : Exception
{
    public CustomException(string message, List<string>? errors = default,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorMessages = errors;
    }

    public List<string>? ErrorMessages { get; }

    public HttpStatusCode StatusCode { get; }
}
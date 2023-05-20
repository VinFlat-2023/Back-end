using System.Net;

namespace Utilities.HttpException;

public class ForbiddenException : CustomException
{
    public ForbiddenException(string message, List<string>? errors = default)
        : base(message, errors, HttpStatusCode.Forbidden)
    {
    }
}
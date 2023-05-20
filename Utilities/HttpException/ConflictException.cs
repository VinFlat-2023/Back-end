using System.Net;

namespace Utilities.HttpException;

public class ConflictException : CustomException
{
    public ConflictException(string message)
        : base(message, null, HttpStatusCode.Conflict) { }
}
namespace Utilities.HttpException;

public class InternalServerException : CustomException
{
    public InternalServerException(string message, List<string>? errors = default)
        : base(message, errors)
    {
    }
}
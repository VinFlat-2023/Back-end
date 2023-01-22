namespace Domain.ErrorEntities;

public class ControllerErrorResponse
{
    public ControllerErrorResponse(Exception? ex)
    {
        if (ex == null)
            return;
        Type = ex.GetType().Name;
        Message = ex.Message;
        StackTrace = ex.ToString();
    }

    private string? Type { get; }
    private string? Message { get; }
    private string? StackTrace { get; }
}
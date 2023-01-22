namespace Domain.EntityRequest.RequestType;

public class RequestTypeCreateRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
}
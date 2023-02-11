namespace Domain.EntityRequest.RequestType;

public class TicketTypeUpdateRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
}
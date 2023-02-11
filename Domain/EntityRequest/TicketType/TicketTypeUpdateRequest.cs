namespace Domain.EntityRequest.TicketType;

public class TicketTypeUpdateRequest
{
    public int TicketTypeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }
}
namespace Domain.EntityRequest.TicketType;

public class TicketTypeCreateRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
}
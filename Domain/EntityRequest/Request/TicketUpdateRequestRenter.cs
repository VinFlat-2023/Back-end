namespace Domain.EntityRequest.Request;

public class TicketUpdateRequestRenter
{
    public string? Description { get; set; }
    public DateTime? SolveDate { get; set; }
    public int? TicketTypeId { get; set; }
}
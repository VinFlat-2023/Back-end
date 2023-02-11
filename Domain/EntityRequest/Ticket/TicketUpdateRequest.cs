namespace Domain.EntityRequest.Ticket;

public class TicketUpdateRequest
{
    public int TicketId { get; set; }
    public string? TicketName { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public double? Amount { get; set; }
    public string Status { get; set; } = null!;
    public int? TicketTypeId { get; set; }
}
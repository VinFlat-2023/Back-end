namespace Domain.EntityRequest.Ticket;

public class TicketUpdateRequest
{
    public int TicketId { get; set; }
    public string? TicketName { get; set; }
    public string? Description { get; set; }
    public string CreateDate { get; set; }
    public string? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; } = null!;
    public int? TicketTypeId { get; set; }
}
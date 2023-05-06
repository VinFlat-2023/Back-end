namespace Domain.EntityRequest.Ticket;

public class TicketUpdateRequest
{
    public string TicketName { get; set; }
    public string Description { get; set; }
    public string? SolveDate { get; set; }
    public decimal Amount { get; set; }
    public string? ImageUrl1 { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public int? TicketTypeId { get; set; }
}
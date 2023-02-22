namespace Domain.EntityRequest.Request;

public class TicketUpdateRequestManagement
{
    public string? RequestName { get; set; }

    public string? Description { get; set; }

    public DateTime? SolveDate { get; set; }

    public decimal? Amount { get; set; }

    public string? Status { get; set; }

    public int? TicketTypeId { get; set; }
}
using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class TicketFilterRequest : PagingFilter
{
    public string? TicketName { get; set; }
    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? SolveDate { get; set; }

    public double? Amount { get; set; }
    public string? Status { get; set; }
    public int? TicketTypeId { get; set; }
}
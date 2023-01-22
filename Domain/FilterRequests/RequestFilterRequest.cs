using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class RequestFilterRequest : PagingFilter
{
    public string? RequestName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? SolveDate { get; set; }

    public decimal? Amount { get; set; }

    public string Status { get; set; } = null!;

    public int? RequestTypeId { get; set; }
}
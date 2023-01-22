using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class FlatTypeFilterRequest : PagingFilter
{
    public int? Capacity { get; set; }

    public string? Status { get; set; }
}
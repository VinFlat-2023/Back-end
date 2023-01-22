using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class ServiceTypeFilterRequest : PagingFilter
{
    public string? Name { get; set; }

    public string? Status { get; set; }
}
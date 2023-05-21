using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class AreaFilterRequest : PagingFilter
{
    public string? Name { get; set; }
    public bool? Status { get; set; }
}
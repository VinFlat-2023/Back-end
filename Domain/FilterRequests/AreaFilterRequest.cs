using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class AreaFilterRequest : PagingFilter
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public bool? Status { get; set;
}
}
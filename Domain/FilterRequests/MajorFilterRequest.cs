using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class MajorFilterRequest : PagingFilter
{
    public string? Name { get; set; }

    public string? UniversityName { get; set; }
}
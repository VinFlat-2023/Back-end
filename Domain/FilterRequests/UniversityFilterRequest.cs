using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class UniversityFilterRequest : PagingFilter
{
    public string? UniversityName { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }
}
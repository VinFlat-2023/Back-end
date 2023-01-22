using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class FeedbackTypeFilterRequest : PagingFilter
{
    public string? Name { get; set; }
}
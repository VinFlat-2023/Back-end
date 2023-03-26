using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class FeedbackFilterRequest : PagingFilter
{
    public string? FeedbackTitle { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? FlatId { get; set; }

    public string? FlatName { get; set; }

    public int? RenterId { get; set; }

    public string? FullName { get; set; }

    public int? FeedbackTypeId { get; set; }
}
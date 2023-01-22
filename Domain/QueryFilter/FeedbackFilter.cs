namespace Domain.QueryFilter;

public class FeedbackFilter : PagingFilter
{
    public string? FeedbackTitle { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int? FlatId { get; set; }
    public int? RenterId { get; set; }
    public int? FeedbackTypeId { get; set; }
}
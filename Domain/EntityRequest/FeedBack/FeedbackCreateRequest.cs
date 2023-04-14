namespace Domain.EntityRequest.FeedBack;

public class FeedbackCreateRequest
{
    public int RenterId { get; set; }
    public int FlatId { get; set; }
    public string Description { get; set; } = null!;
    public string FeedbackTitle { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int FeedbackTypeId { get; set; }
}
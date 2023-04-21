namespace Domain.EntityRequest.FeedBack;

public class FeedbackUpdateRequest
{
    public int RenterId { get; set; }
    public int FlatId { get; set; }
    public int FeedbackTypeId { get; set; }
    public string Description { get; set; } = null!;
    public string FeedbackTitle { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreateDate { get; set; }
  
}
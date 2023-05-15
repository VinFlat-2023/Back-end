using System.Globalization;
using Domain.ViewModel.FeedbackTypeDetail;
using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.RenterEntity;

namespace Domain.ViewModel.FeedbackEntity;

public class FeedbackDetailEntity
{
    public int FeedbackId { get; set; }
    public string FeedbackTitle { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }

    public string CreateDateReturn
        => CreateDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public int FlatId { get; set; }
    public FlatBasicDetailEntity Flat { get; set; }
    public int RenterId { get; set; }
    public RenterBasicDetailEntity Renter { get; set; }
    public int FeedbackTypeId { get; set; }
    public FeedbackTypeDetailEntity FeedbackType { get; set; } = null!;
}
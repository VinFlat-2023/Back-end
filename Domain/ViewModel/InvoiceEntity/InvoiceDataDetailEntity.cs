using Domain.ViewModel.PlaceholderForFeeEntity;
using Domain.ViewModel.ServiceEntity;

namespace Domain.ViewModel.InvoiceEntity;

public class InvoiceDataDetailEntity
{
    public int InvoiceDetailId { get; set; }
    public decimal Amount { get; set; }
    public int InvoiceId { get; set; }
    public InvoiceRenterDetailEntity Invoice { get; set; }
    public int? ServiceId { get; set; }
    public ServiceDetailEntity? Service { get; set; }
    public int? WildcardIdForFee { get; set; }
    public PlaceholderForFeeDetailEntity? PlaceholderForFee { get; set; }
}
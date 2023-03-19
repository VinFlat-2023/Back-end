using Domain.ViewModel.InvoiceEntity;
using Domain.ViewModel.ServiceEntity;

namespace Domain.ViewModel.InvoiceDetailEntity;

public class InvoiceDataDetailEntity
{
    public int InvoiceDetailId { get; set; }
    public decimal Amount { get; set; }
    public int InvoiceId { get; set; }
    public InvoiceRenterDetailEntity Invoice { get; set; } = null!;
    public int? ServiceId { get; set; }
    public ServiceDetailEntity? Service { get; set; }
    public int? WildcardIdForFee { get; set; }
}
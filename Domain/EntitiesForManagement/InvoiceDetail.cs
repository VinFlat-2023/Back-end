using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class InvoiceDetail
{
    public int InvoiceDetailId { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
    public int InvoiceId { get; set; }
    public virtual Invoice Invoice { get; set; }
    [ForeignKey("ServiceId")] public int? ServiceId { get; set; }
    public virtual ServiceEntity? Service { get; set; }
    public int? PlaceholderForFeeId { get; set; }
    public virtual PlaceholderForFee? PlaceholderForFee { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class InvoiceDetail
{
    public int InvoiceDetailId { get; set; }
    public double Amount { get; set; }
    public int InvoiceId { get; set; }
    public virtual Invoice Invoice { get; set; } = null!;

    [ForeignKey("Service")] public int? ServiceId { get; set; }

    public virtual ServiceEntity Service { get; set; }
}
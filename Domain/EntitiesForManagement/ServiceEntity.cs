using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class ServiceEntity
{
    public ServiceEntity()
    {
        InvoiceDetails = new HashSet<InvoiceDetail>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public decimal? Amount { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public int ServiceTypeId { get; set; }
    public virtual ServiceType ServiceType { get; set; }
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = null!;
}
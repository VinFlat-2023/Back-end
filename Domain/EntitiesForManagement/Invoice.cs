using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Invoice
{
    public Invoice()
    {
        InvoiceDetails = new HashSet<InvoiceDetail>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceId { get; set; }

    public string Name { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? PaymentTime { get; set; }

    public string Detail { get; set; }

    // Contract 
    public int? ContractId { get; set; }

    public virtual Contract? Contract { get; set; }

    // Receiver 
    public int? RenterId { get; set; }

    public virtual Renter? Renter { get; set; }

    // Management employee
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    // Building which this invoice belongs to
    public int BuildingId { get; set; }
    public int InvoiceTypeId { get; set; }
    public virtual InvoiceType InvoiceType { get; set; } = null!;
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}
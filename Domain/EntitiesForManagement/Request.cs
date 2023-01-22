using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Request
{
    public Request()
    {
        InvoiceDetails = new HashSet<InvoiceDetail>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestId { get; set; }

    public string RequestName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; } = null!;
    public int? RequestTypeId { get; set; }
    // Renter
    public int RenterId { get; set; }
    public virtual Renter Renter { get; set; } = null!; 
    // Management
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public virtual RequestType RequestType { get; set; } = null!;
}
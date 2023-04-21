using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

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
    public int Amount { get; set; }
    public bool Status { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Detail { get; set; }
    public string? ImageUrl { get; set; }

    [MaxUploadedFileSize(1 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public DateTime? PaymentTime { get; set; }

    public DateTime? CreatedTime { get; set; }

    // Contract 
    public int? ContractId { get; set; }

    // Receiver employee
    public int? RenterId { get; set; }

    public virtual Renter? Renter { get; set; }

    // Management employee
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public int InvoiceTypeId { get; set; }
    public virtual InvoiceType InvoiceType { get; set; } = null!;
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}
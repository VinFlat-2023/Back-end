using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Invoice;

public class InvoiceUpdateRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceId { get; set; }

    public string Name { get; set; }
    public int Amount { get; set; }
    public bool Status { get; set; }
    public DateTime DueDate { get; set; }

    public string Detail { get; set; }

    public string ImageUrl { get; set; }

    [MaxUploadedFileSize(1 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public int ContractId { get; set; }

    public virtual EntitiesForManagement.Contract Contract { get; set; }

    public DateTime PaymentTime { get; set; }

    public TimeSpan PaymentPeriod { get; set; }

    public DateTime CreatedTime { get; set; }

    public int RenterId { get; set; }

    public int AccountId { get; set; }

    public int InvoiceTypeId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Invoice;

public class InvoiceUpdateRequest
{
    public string Name { get; set; } = null!;
    public bool Status { get; set; }
    public string? DueDate { get; set; }
    public string? Detail { get; set; }
    public string? ImageUrl { get; set; }

    [MaxUploadedFileSize(1 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public int ContractId { get; set; }
    public string? PaymentTime { get; set; }
    public int RenterId { get; set; }
    public int EmployeeId { get; set; }
    public int InvoiceTypeId { get; set; }
}
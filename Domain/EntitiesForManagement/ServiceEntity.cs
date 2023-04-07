using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

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

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public string? ImageUrl4 { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public int ServiceTypeId { get; set; }
    public virtual ServiceType ServiceType { get; set; }
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = null!;
}
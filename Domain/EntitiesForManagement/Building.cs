using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Building
{
    public Building()
    {
        Flats = new HashSet<Flat>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BuildingId { get; set; }

    public string BuildingName { get; set; }
    public string BuildingAddress { get; set; }
    public string Description { get; set; }
    public int TotalFlats { get; set; }
    public string BuildingPhoneNumber { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? BuildingImageUrl1 { get; set; }
    public string? BuildingImageUrl2 { get; set; }
    public string? BuildingImageUrl3 { get; set; }
    public string? BuildingImageUrl4 { get; set; }
    public string? BuildingImageUrl5 { get; set; }
    public string? BuildingImageUrl6 { get; set; }
    public decimal AveragePrice { get; set; }
    public bool Status { get; set; }

    // Management Company
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    [ForeignKey("AreaId")] public int AreaId { get; set; }
    public virtual Area Area { get; set; }
    public virtual ICollection<Flat> Flats { get; set; }
}
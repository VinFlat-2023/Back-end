using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Area
{
    public Area()
    {
        Buildings = new HashSet<Building>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AreaId { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? AreaImageUrl1 { get; set; }
    public string? AreaImageUrl2 { get; set; }
    public string? AreaImageUrl3 { get; set; }
    public string? AreaImageUrl4 { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Building> Buildings { get; set; }
}
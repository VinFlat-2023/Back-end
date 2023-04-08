using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Utility
{
    public Utility()
    {
        UtilitiesFlats = new HashSet<UtilitiesFlat>();
    }

    public int UtilityId { get; set; }
    public string UtilitiesName { get; set; } = null!;
    public string? Description { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public string? ImageUrl4 { get; set; }
    public virtual ICollection<UtilitiesFlat> UtilitiesFlats { get; set; }
}
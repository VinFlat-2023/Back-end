using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Utility
{
    public Utility()
    {
        UtilitiesRooms = new HashSet<UtilitiesRoomFlat>();
    }

    public int UtilityId { get; set; }
    public string UtilitiesName { get; set; } = null!;
    public string? Description { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? UtilityImageUrl { get; set; }
    public string? UtilityImageUrl2 { get; set; }
    public string? UtilityImageUrl3 { get; set; }
    public string? UtilityImageUrl4 { get; set; }
    public virtual ICollection<UtilitiesRoomFlat> UtilitiesRooms { get; set; }
}
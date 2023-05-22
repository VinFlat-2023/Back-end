using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class RoomType
{
    public RoomType()
    {
        Rooms = new HashSet<Room>();
    }

    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; }
    public int TotalSlot { get; set; } // Max slot, Min slot = 1
    public string Description { get; set; }
    public string Status { get; set; } // Active / Inactive
    public decimal ElectricityAttribute { get; set; } = 1;
    public decimal WaterAttribute { get; set; } = 1;

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public int BuildingId { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}
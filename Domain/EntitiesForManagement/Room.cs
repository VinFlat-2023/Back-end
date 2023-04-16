using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Room
{
    public int RoomId { get; set; }
    public string RoomName { get; set; } = null!;
    public int AvailableSlots { get; set; }
    public string Description { get; set; } 
    public decimal ElectricityAttribute { get; set; }
    public decimal WaterAttribute { get; set; }
    public string Status { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public string? ImageUrl4 { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; }
    public int RoomTypeId { get; set; }
    public virtual RoomType RoomType { get; set; }
}
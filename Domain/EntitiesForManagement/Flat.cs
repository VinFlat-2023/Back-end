using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Flat
{
    public Flat()
    {
        Contracts = new HashSet<Contract>();
        Rooms = new HashSet<Room>();
        MetricHistories = new HashSet<MetricHistory>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlatId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public decimal WaterMeterBefore { get; set; }
    public decimal WaterMeterAfter { get; set; }
    public decimal ElectricityMeterBefore { get; set; }
    public decimal ElectricityMeterAfter { get; set; }
    public int MaxRoom { get; set; }
    public int AvailableRoom { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? FlatImageUrl1 { get; set; }
    public string? FlatImageUrl2 { get; set; }
    public string? FlatImageUrl3 { get; set; }
    public string? FlatImageUrl4 { get; set; }
    public string? FlatImageUrl5 { get; set; }
    public string? FlatImageUrl6 { get; set; }
    public int FlatTypeId { get; set; }
    public virtual FlatType FlatType { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public virtual ICollection<MetricHistory> MetricHistories { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
}
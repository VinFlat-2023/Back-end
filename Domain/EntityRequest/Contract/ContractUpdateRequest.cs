using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Contract;

public class ContractUpdateRequest
{
    public int ContractId { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? LastUpdated { get; set; }

    [MaxLength(200, ErrorMessage = "Description length must less than 200")]
    public string Description { get; set; } = null!;

    [DataType(DataType.ImageUrl)] public string? ImageUrl { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Price must not be negative")]
    public decimal Price { get; set; }

    [MaxLength(20, ErrorMessage = "Status length must less than 20")]
    public string ContractStatus { get; set; } = null!;

    [Range(0, int.MaxValue, ErrorMessage = "Flat Id must not be negative")]
    public int RenterId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Renter;

public class RenterUpdateRequest
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime? BirthDate { get; set; }

    public bool Status { get; set; }

    public string? ImageUrl { get; set; }

    [MaxUploadedFileSize(1 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? CitizenNumber { get; set; }

    public string? CitizenImageUrl { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? CitizenImage { get; set; }

    public int? ContractId { get; set; }
    public string Address { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public int? UniversityId { get; set; }
    public int? MajorId { get; set; }

    public string? DeviceToken { get; set; }
}
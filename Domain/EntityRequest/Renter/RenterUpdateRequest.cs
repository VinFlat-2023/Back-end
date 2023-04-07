namespace Domain.EntityRequest.Renter;

public class RenterUpdateRequest
{
    //public string Username { get; set; } = null!;
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }

    public DateTime? BirthDate { get; set; }

    //public string? CitizenNumber { get; set; }
    //public string? CitizenImageUrl { get; set; }
    //[MaxUploadedFileSize(4 * 1024 * 1024)]
    //[AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    //[DataType(DataType.Upload)]
    //[NotMapped]
    //public IFormFile? CitizenImage { get; set; }
    //public int? ContractId { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int? UniversityId { get; set; }
    public int? MajorId { get; set; }

    //public string? DeviceToken { get; set; }
}
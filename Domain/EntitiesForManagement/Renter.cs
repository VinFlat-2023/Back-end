using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Renter
{
    public Renter()
    {
        Invoices = new HashSet<Invoice>();
        Feedbacks = new HashSet<Feedback>();
        ContractHistories = new HashSet<ContractHistory>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RenterId { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Status { get; set; }
    public string? ImageUrl { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
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

    public string Address { get; set; }
    public string Gender { get; set; }
    public int? UniversityId { get; set; }
    public int? MajorId { get; set; }
    public virtual Major Major { get; set; }
    public virtual University University { get; set; }
    [ForeignKey("ContractId")] public int? ContractId { get; set; }
    public string? DeviceToken { get; set; }
    public virtual ICollection<ContractHistory>? ContractHistories { get; set; }
    public virtual ICollection<Invoice>? Invoices { get; set; }
    public virtual ICollection<Feedback>? Feedbacks { get; set; }
    public virtual ICollection<UserDevice>? UserDevices { get; set; }
}
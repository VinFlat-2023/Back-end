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
        Contracts = new HashSet<Contract>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RenterId { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public string? ImageUrl { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? CitizenNumber { get; set; }
    public string? CitizenCardFrontImageUrl { get; set; }
    public string? CitizenCardBackImageUrl { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? CitizenImage { get; set; }

    public string Address { get; set; }
    public string Gender { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<Feedback> Feedbacks { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Employee
{
    public Employee()
    {
        Invoices = new HashSet<Invoice>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }

    public string Username { get; set; }
    public string FullName { get; set; }
    [DataType(DataType.Password)] public string Password { get; set; }
    [DataType(DataType.EmailAddress)] public string Email { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? EmployeeImageUrl { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public string Address { get; set; }
    public int? TechnicianBuildingId { get; set; }
    public int? SupervisorBuildingId { get; set; }

    [Range(0, 100, ErrorMessage = "Role Id cannot be negative")]
    public int RoleId { get; set; }

    public virtual Role Role { get; set; }
    public virtual ICollection<Building> Building { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<UserDevice> UserDevices { get; set; }
}
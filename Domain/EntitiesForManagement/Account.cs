using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Account
{
    public Account()
    {
        Invoices = new HashSet<Invoice>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    public string Username { get; set; }
    public string FullName { get; set; }
    [DataType(DataType.Password)] public string Password { get; set; }
    [DataType(DataType.EmailAddress)] public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }

    [Range(0, 100, ErrorMessage = "Role Id cannot be negative")]
    public int? RoleId { get; set; }

    public virtual Role Role { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<UserDevice> UserDevices { get; set; }
}
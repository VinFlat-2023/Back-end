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

    [StringLength(20, MinimumLength = 6, ErrorMessage = "Username length must be 6-20")]
    [RegularExpression("^[a-zA-Z0-9]{6,20}$", ErrorMessage = "Username only accept alphabet characters and numbers")]
    public string Username { get; set; }

    [StringLength(20, MinimumLength = 6, ErrorMessage = "Username length must be 6-20")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.EmailAddress)] public string Email { get; set; }

    [MaxLength(10)]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number only accept 10 numbers")]
    public string Phone { get; set; }

    public bool Status { get; set; }

    [Range(0, 100, ErrorMessage = "Role Id cannot be negative")]
    public int? RoleId { get; set; }

    public virtual Role Role { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<UserDevice> UserDevices { get; set; }
}
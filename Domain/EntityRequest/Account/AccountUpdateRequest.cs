using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Account;

public class AccountUpdateRequest
{
    [StringLength(35, MinimumLength = 6, ErrorMessage = "Username length must be 6-35")]
    [RegularExpression("^[a-zA-Z0-9]{6,20}$", ErrorMessage = "Username only accept alphabet characters and numbers")]
    public string Username { get; set; } = null!;

    [StringLength(35, MinimumLength = 6, ErrorMessage = "Password length must be 6-35")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.EmailAddress)] public string Email { get; set; } = null!;

    public string Fullname { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public bool Status { get; set; }

    [Range(0, 100, ErrorMessage = "Role Id cannot be negative")]
    public int RoleId { get; set; }
}
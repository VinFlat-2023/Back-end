using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Account;

public class EmployeeCreateRequest
{
    public string Username { get; set; } = null!;
    public string Fullname { get; set; } = null!;

    [DataType(DataType.EmailAddress)] public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; }
    public int RoleId { get; set; }

    /// <summary>
    ///     Device Token.
    /// </summary>
    public string? DeviceToken { get; set; }
}
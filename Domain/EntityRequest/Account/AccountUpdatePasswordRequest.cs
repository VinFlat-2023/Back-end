using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Account;

public class AccountUpdatePasswordRequest
{
    [DataType(DataType.Password)] public string Password { get; set; } = null!;
}
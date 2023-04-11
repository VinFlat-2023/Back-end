using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Renter;

public class RenterUpdatePasswordRequest
{
    [DataType(DataType.Password)] public string Password { get; set; } = null!;

    [DataType(DataType.Password)] public string ConfirmPassword { get; set; } = null!;
}
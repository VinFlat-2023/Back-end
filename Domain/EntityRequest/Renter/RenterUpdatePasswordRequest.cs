using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Renter;

public class RenterUpdatePasswordRequest
{
    [DataType(DataType.Password)] public string Password { get; set; } = null!;
}
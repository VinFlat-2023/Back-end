using System.ComponentModel.DataAnnotations;

namespace Domain.ControllerEntities;

public class LoginModel
{
    public string UsernameOrPhoneNumber { get; set; }
    [DataType(DataType.Password)] public string Password { get; set; }
    public string? DeviceToken { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Employee;

public class EmployeeUpdatePasswordRequest
{
    [DataType(DataType.Password)] public string OldPassword { get; set; } = null!;
    [DataType(DataType.Password)] public string Password { get; set; } = null!;
    [DataType(DataType.Password)] public string ConfirmPassword { get; set; } = null!;
}
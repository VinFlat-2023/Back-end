using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Employee;

public class EmployeeUpdatePasswordRequest
{
    [DataType(DataType.Password)] public string Password { get; set; } = null!;
}
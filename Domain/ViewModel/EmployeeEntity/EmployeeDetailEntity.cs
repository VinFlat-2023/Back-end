using Domain.ViewModel.RoleEntity;

namespace Domain.ViewModel.EmployeeEntity;

public class EmployeeDetailEntity
{
    public int EmployeeId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool Status { get; set; }
    public string? EmployeeImageUrl { get; set; }
    public string Address { get; set; }
    public RoleDetailEntity Role { get; set; }
}
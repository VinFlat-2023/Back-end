namespace Domain.EntityRequest.Employee;

public class EmployeeUpdateRequest
{
    public string Fullname { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
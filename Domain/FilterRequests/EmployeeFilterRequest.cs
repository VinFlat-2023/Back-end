using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class EmployeeFilterRequest : PagingFilter
{
    public string? Username { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? Status { get; set; }

    public string? RoleName { get; set; }
}
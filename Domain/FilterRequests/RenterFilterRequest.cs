using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class RenterFilterRequest : PagingFilter
{
    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FullName { get; set; }

    public bool? Status { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }
}
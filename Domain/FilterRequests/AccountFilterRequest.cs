using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class AccountFilterRequest : PagingFilter
{
    public string? Username { get; set; }

    public string? Phone { get; set; }

    public bool? Status { get; set; }

    public int? RoleId { get; set; }
}
using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class RoleFilterRequest : PagingFilter
{
    public string? RoleName { get; set; }

    public bool? Status { get; set; }
}
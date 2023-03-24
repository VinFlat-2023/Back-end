namespace Domain.QueryFilter;

public class RoleFilter : PagingFilter
{
    public string? RoleName { get; set; }
    public bool? Status { get; set; }
}
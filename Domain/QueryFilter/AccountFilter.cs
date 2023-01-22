namespace Domain.QueryFilter;

public class AccountFilter : PagingFilter
{
    public string? Username { get; set; }

    public string? Phone { get; set; }

    public bool? Status { get; set; }

    public int? RoleId { get; set; }
}
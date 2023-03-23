namespace Domain.EntityRequest.Role;

public class RoleCreateRequest
{
    public string RoleName { get; set; } = null!;
    public bool Status { get; set; }
}
namespace Domain.EntityRequest.Role;

public class RoleUpdateRequest
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public bool Status { get; set; }
}
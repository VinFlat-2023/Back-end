namespace Domain.EntityRequest.Role;

public class RoleUpdateRequest
{
    public string RoleName { get; set; } = null!;
    public bool Status { get; set; }
    public int UniversityId { get; set; }
}
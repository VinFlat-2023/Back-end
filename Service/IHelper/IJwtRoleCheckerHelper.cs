using System.Security.Claims;

namespace Service.IHelper;

public interface IJwtRoleCheckerHelper
{
    public Task<bool> IsManagementRoleAuthorized(ClaimsPrincipal user);
    public Task<bool> IsRenterRoleAuthorized(ClaimsPrincipal user, int id);
    public Task<bool> IsRenterRoleAuthorized(ClaimsPrincipal user);
    public Task<bool> IsManagementAndEmployeeRoleAuthorized(ClaimsPrincipal user, int id);
}
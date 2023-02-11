using System.Security.Claims;
using System.Security.Principal;
using Service.IHelper;

namespace Service.Helper;

public class JwtRoleCheckHelper : IJwtRoleCheckerHelper
{
    public async Task<bool> IsManagementRoleAuthorized(ClaimsPrincipal user)
    {
        var roleCheck = await JwtRoleCheck(user);

        if (!await JwtCheck(user))
            return false;

        return roleCheck is not ("Admin" or "SuperAdmin" or "Supervisor");
    }

    public async Task<bool> IsRenterRoleAuthorized(ClaimsPrincipal user, int id)
    {
        var roleCheck = await JwtRoleCheck(user);

        if (!await JwtCheck(user))
            return false;

        return roleCheck is not ("Admin" or "SuperAdmin" or "Supervisor")
               || (roleCheck is not "Renter" && user.Identity?.Name == id.ToString());
    }

    public async Task<bool> IsRenterRoleAuthorized(ClaimsPrincipal user)
    {
        var roleCheck = await JwtRoleCheck(user);

        if (!await JwtCheck(user))
            return false;

        return roleCheck is not ("Admin" or "SuperAdmin" or "Supervisor" or "Renter");
    }

    public async Task<bool> IsManagementAndEmployeeRoleAuthorized(ClaimsPrincipal user, int id)
    {
        var roleCheck = await JwtRoleCheck(user);

        if (!await JwtCheck(user))
            return false;

        return roleCheck is not ("Admin" or "SuperAdmin" or "Supervisor")
               || (roleCheck is not "Employee"
                   && user.Identity?.Name == id.ToString());
    }

    public async Task<bool> IsSuperAdminRoleAuthorized(ClaimsPrincipal user)
    {
        var roleCheck = await JwtRoleCheck(user);

        if (!await JwtCheck(user))
            return false;

        return roleCheck is not "SuperAdmin";
    }

    private static async Task<string> JwtRoleCheck(ClaimsPrincipal user)
    {
        return await Task.FromResult(user.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty);
    }

    private static async Task<bool> JwtCheck(IPrincipal user)
    {
        var jwtId = user.Identity?.Name;
        if (string.IsNullOrEmpty(jwtId) || jwtId == string.Empty || int.Parse(jwtId) <= 0)
            return await Task.FromResult(false);
        return await Task.FromResult(true);
    }
}
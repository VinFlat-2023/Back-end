using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationContext _context;

    public RoleRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all roles
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Role> GetRoleList(RoleFilter filters)
    {
        return _context.Roles
            .Where(x =>
                filters.RoleName == null || (x.RoleName.Contains(filters.RoleName)
                                             && (filters.Status == null || x.Status == filters.Status)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get role details by id
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Role?> GetRoleDetail(int? roleId)
    {
        return await _context.Roles
            .SingleOrDefaultAsync(x => x.RoleId == roleId);
    }

    /// <summary>
    ///     AddExpenseHistory new role
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<Role> AddRole(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
        return role;
    }

    /// <summary>
    ///     UpdateExpenseHistory role details
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<Role?> UpdateRole(Role? role)
    {
        var roleData = await _context.Roles
            .FirstOrDefaultAsync(x => x.RoleId == role!.RoleId);
        if (roleData == null)
            return null;
        roleData.RoleName = role?.RoleName ?? roleData.RoleName;

        await _context.SaveChangesAsync();
        return role;
    }

    /// <summary>
    ///     Toggle Role status
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> DeleteRole(int roleId)
    {
        var roleFound = await _context.Roles
            .FirstOrDefaultAsync(x => x.RoleId == roleId);
        if (roleFound == null)
            return false;
        _ = roleFound.Status == !roleFound.Status;
        await _context.SaveChangesAsync();
        return true;
    }
}
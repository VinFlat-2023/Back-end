using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoleRepository
{
    public IQueryable<Role> GetRoleList(RoleFilter filters);
    public Task<Role?> GetRoleDetail(int? roleId);
    public Task<Role> AddRole(Role role);
    public Task<Role?> UpdateRole(Role role);
    public Task<bool> DeleteRole(int roleId);
}
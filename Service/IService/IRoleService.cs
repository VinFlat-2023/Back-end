using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoleService
{
    public Task<PagedList<Role>?> GetRoleList(RoleFilter filters, CancellationToken token);
    public Task<Role?> GetRoleById(int? roleId, CancellationToken cancellationToken);
    public Task<Role?> AddRole(Role role);
    public Task<Role?> UpdateRole(Role role);
    public Task<bool> DeleteRole(int roleId);
}
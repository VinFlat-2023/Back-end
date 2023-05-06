using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RoleService : IRoleService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoleService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Role>?> GetRoleList(RoleFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Roles.GetRoleList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Role>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Role?> GetRoleById(int? roleId, CancellationToken token)
    {
        return await _repositoryWrapper.Roles.GetRoleDetail(roleId);
    }

    public async Task<Role?> AddRole(Role role)
    {
        return await _repositoryWrapper.Roles.AddRole(role);
    }

    public async Task<Role?> UpdateRole(Role role)
    {
        return await _repositoryWrapper.Roles.UpdateRole(role);
    }

    public async Task<bool> DeleteRole(int roleId)
    {
        return await _repositoryWrapper.Roles.DeleteRole(roleId);
    }
}
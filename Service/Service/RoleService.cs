using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class RoleService : IRoleService
{
    private readonly string _cacheKey = "role";
    private readonly string _cacheKeyPageNumber = "page-number-role";
    private readonly string _cacheKeyPageSize = "page-size-role";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoleService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Role>?> GetRoleList(RoleFilter filters, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        /*
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Role>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                var matches =
                    cacheDataList.Where(x =>
                        (filters.RoleName == null || x.RoleName.Contains(filters.RoleName))
                        && (filters.Status == null || x.Status == filters.Status)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }
        */
        var queryable = _repositoryWrapper.Roles.GetRoleList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Role>
            .Create(queryable, pageNumber, pageSize, token);

        /*
        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        */
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
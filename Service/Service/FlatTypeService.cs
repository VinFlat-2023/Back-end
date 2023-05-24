using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class FlatTypeService : IFlatTypeService
{
    private readonly string _cacheKey = "flat-type";
    private readonly string _cacheKeyPageNumber = "page-number-flat-type";
    private readonly string _cacheKeyPageSize = "page-size-flat-type";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<FlatType>?> GetFlatTypeList(FlatTypeFilter filters, int buildingId,
        CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<FlatType>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

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
                var matches = cacheDataList.Where(x =>
                    (filters.Status == null || x.Status == filters.Status)
                    && (filters.FlatTypeName == null
                        || (x.FlatTypeName.ToLower().Contains(filters.FlatTypeName.ToLower())
                            && (filters.RoomCapacity == null
                                || x.RoomCapacity == filters.RoomCapacity)))
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.FlatTypes.GetFlatTypeList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<FlatType>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<FlatType?> GetFlatTypeById(int? flatTypeId, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.FlatTypes.GetFlatTypeDetail(flatTypeId, buildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<FlatType?> AddFlatType(FlatType flatType)
    {
        return await _repositoryWrapper.FlatTypes.AddFlatType(flatType);
    }

    public async Task<RepositoryResponse> UpdateFlatType(FlatType flatType)
    {
        return await _repositoryWrapper.FlatTypes.UpdateFlatType(flatType);
    }

    public async Task<RepositoryResponse> ToggleStatus(int id)
    {
        return await _repositoryWrapper.FlatTypes.ToggleStatus(id);
    }

    public async Task<RepositoryResponse> DeleteFlatType(int flatTypeId)
    {
        return await _repositoryWrapper.FlatTypes.DeleteFlatType(flatTypeId);
    }

    public async Task<RepositoryResponse> IsAnyFlatIsInUseWithThisType(int? flatTypeId, int buildingId,
        CancellationToken token)
    {
        return await _repositoryWrapper.FlatTypes.IsAnyFlatIsInUseWithThisType(flatTypeId, buildingId, token);
    }

    public async Task<RepositoryResponse> IsFlatTypeNameDuplicate(string? flatTypeName, int buildingId,
        CancellationToken token)
    {
        return await _repositoryWrapper.FlatTypes.IsFlatTypeNameDuplicate(flatTypeName, buildingId, token);
    }
}
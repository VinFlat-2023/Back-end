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

public class AreaService : IAreaService
{
    private readonly string _cacheKey = "area";
    private readonly string _cacheKeyAreaList = "area-list";
    private readonly string _cacheKeyPageNumber = "page-number-area";
    private readonly string _cacheKeyPageSize = "page-size-area";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AreaService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Area>?> GetAreaList(AreaFilter filters, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Area>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);
        var cacheDataAreaList = await _redis.GetCachePagedDataAsync<List<Area>>(_cacheKeyAreaList);

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
            }
            else
            {
                var matches = cacheDataList.Where(p =>
                    (filters.Name == null || p.Name == filters.Name)
                    && (filters.Status == null || p.Status == filters.Status)
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
            }
        }

        var queryable = _repositoryWrapper.Areas.GetAreaList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Area>.Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }


    public async Task<List<Area>?> GetAreaList(CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<List<Area>>(_cacheKeyAreaList);

        if (cacheDataList != null)
            return cacheDataList;

        var listArea = await _repositoryWrapper.Areas.GetAreaList()
            .ToListAsync(token);

        await _redis.SetCacheDataAsync(_cacheKeyAreaList, listArea, 10, 5);

        return listArea;
    }

    public async Task<Area?> GetAreaByIdWithCache(int? areaId, CancellationToken token)
    {
        return await _repositoryWrapper.Areas.GetAreaById(areaId, token);
    }


    public async Task<Area?> GetAreaById(int? areaId, CancellationToken token)
    {
        return await _repositoryWrapper.Areas.GetAreaById(areaId, token);
    }

    public async Task<RepositoryResponse> GetAreaByName(string? areaName, CancellationToken token)
    {
        return await _repositoryWrapper.Areas.GetAreaByName(areaName, token);
    }

    public async Task<RepositoryResponse> GetAreaByName(string? areaName, int? areaId,
        CancellationToken token)
    {
        return await _repositoryWrapper.Areas.GetAreaByName(areaName, areaId, token);
    }

    public async Task<Area?> AddArea(Area area)
    {
        await _repositoryWrapper.Areas.AddArea(area);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
        return area;
    }

    public async Task<RepositoryResponse> UpdateArea(Area area)
    {
        var response = await _repositoryWrapper.Areas.UpdateArea(area);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
        return response;
    }

    public async Task<RepositoryResponse> DeleteArea(int areaId)
    {
        var response = await _repositoryWrapper.Areas.DeleteArea(areaId);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
        return response;
    }

    public async Task<RepositoryResponse> UpdateAreaImage(Area updateArea, int number)
    {
        var response = await _repositoryWrapper.Areas.UpdateAreaImage(updateArea, number);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
        return response;
    }

    public async Task<RepositoryResponse> ToggleAreaStatus(int areaId)
    {
        var response = await _repositoryWrapper.Areas.ToggleArea(areaId);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyAreaList);
        return response;
    }
}
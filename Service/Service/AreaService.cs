using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class AreaService : IAreaService
{
    private readonly string _cacheKey = "area";
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


    public async Task<(PagedList<Area>?, bool)> GetAreaList(AreaFilter filters, CancellationToken token)
    {
        var cacheData = await _redis.GetCacheDataAsync<PagedList<Area>>(_cacheKey);

        if (cacheData != null) return (cacheData, true);

        var queryable = _repositoryWrapper.Areas.GetAreaList(filters);

        if (!queryable.Any())
            return (null, false);

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Area>
            .Create(queryable, page, size, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);

        return (pagedList, false);
    }

    public async Task<(Area?, bool)> GetAreaByIdWithCache(int? areaId, CancellationToken token)
    {
        var cacheData = await _redis.GetCacheDataAsync<PagedList<Area>>(_cacheKey);
        // Check if the cache data contains any number of books
        if (cacheData != null)
        {
            var areaFromCache = cacheData.FirstOrDefault(x => x.AreaId == areaId);

            return areaFromCache == null ? (null, false) : (areaFromCache, true);
        }

        var result = await _repositoryWrapper.Areas.GetAreaById(areaId, token);

        return result == null ? (null, false) : (result, false);
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
        return area;
    }

    public async Task<RepositoryResponse> UpdateArea(Area area)
    {
        var response = await _repositoryWrapper.Areas.UpdateArea(area);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        return response;
    }

    public async Task<RepositoryResponse> DeleteArea(int areaId)
    {
        var response = await _repositoryWrapper.Areas.DeleteArea(areaId);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        return response;
    }

    public async Task<RepositoryResponse> UpdateAreaImage(Area updateArea, int number)
    {
        var response = await _repositoryWrapper.Areas.UpdateAreaImage(updateArea, number);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        return response;
    }

    public async Task<RepositoryResponse> ToggleAreaStatus(int areaId)
    {
        var response = await _repositoryWrapper.Areas.ToggleArea(areaId);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        return response;
    }
}
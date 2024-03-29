using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Metric;
using Domain.Options;
using Domain.QueryFilter;
using Domain.ViewModel.MetricNumber;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class FlatService : IFlatService
{
    private readonly string _cacheKey = "flat";
    private readonly string _cacheKeyFlatList = "flat-list";
    private readonly string _cacheKeyPageNumber = "page-number-flat";
    private readonly string _cacheKeyPageSize = "page-size-flat";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<int?> GetTotalFlatBasedOnFilter(MetricFlatFilter filters, int buildingId,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Flats.GetTotalFlatBasedOnFilter(filters, buildingId);

        if (!queryable.Any())
            return null;

        return await queryable.SumAsync(token);
    }

    public async Task<PagedList<Flat>?> GetFlatList(FlatFilter filters, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Flat>>(_cacheKey);
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
                await _redis.RemoveCacheDataAsync(_cacheKeyFlatList);
            }
            else
            {
                var matches = cacheDataList.Where(f =>
                    (filters.Name == null || f.Name.Contains(filters.Name.ToLower()))
                    && (filters.Description == null || f.Description.Contains(filters.Description.ToLower()))
                    && (filters.Status == null || f.Status == filters.Status)
                    && (filters.FlatTypeId == null || f.FlatTypeId == filters.FlatTypeId)
                    && (filters.FlatTypeName == null ||
                        f.FlatType.FlatTypeName.ToLower().Contains(filters.FlatTypeName.ToLower()))
                    && (filters.BuildingId == null || f.BuildingId == filters.BuildingId)
                    && (filters.BuildingName == null ||
                        f.Building.BuildingName.ToLower().Contains(filters.BuildingName.ToLower()))
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyFlatList);
            }
        }

        var queryable = _repositoryWrapper.Flats.GetFlatList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Flat>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<PagedList<Flat>?> GetFlatList(FlatFilter filters, int buildingId, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Flat>>(_cacheKey);
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
                await _redis.RemoveCacheDataAsync(_cacheKeyFlatList);
            }
            else
            {
                var matches = cacheDataList.Where(f =>
                    (filters.Name == null || f.Name.Contains(filters.Name.ToLower()))
                    && (filters.Description == null || f.Description.Contains(filters.Description.ToLower()))
                    && (filters.Status == null || f.Status == filters.Status)
                    && (filters.FlatTypeId == null || f.FlatTypeId == filters.FlatTypeId)
                    && (filters.FlatTypeName == null ||
                        f.FlatType.FlatTypeName.ToLower().Contains(filters.FlatTypeName.ToLower()))
                    && (filters.BuildingId == null || f.BuildingId == filters.BuildingId)
                    && (filters.BuildingName == null ||
                        f.Building.BuildingName.ToLower().Contains(filters.BuildingName.ToLower()))
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyFlatList);
            }
        }

        var queryable = _repositoryWrapper.Flats.GetFlatList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Flat>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<Flat?> GetFlatById(int? flatId, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Flats.GetFlatDetail(flatId, buildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<RepositoryResponse> AddFlat(Flat flat, List<int> roomTypeIds, CancellationToken token)
    {
        var response = await _repositoryWrapper.Flats.AddFlat(flat, roomTypeIds, token);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyFlatList);
        return response;
    }

    public async Task<RepositoryResponse> UpdateFlat(Flat flat)
    {
        var response = await _repositoryWrapper.Flats.UpdateFlat(flat);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyFlatList);
        return response;
    }

    public async Task<RepositoryResponse> DeleteFlat(int flatId)
    {
        return await _repositoryWrapper.Flats.DeleteFlat(flatId);
    }

    public async Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken token)
    {
        return await _repositoryWrapper.Flats.GetRoomInAFlat(flatId, token);
    }

    public async Task<List<Flat>?> GetFlatList(int buildingId, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<List<Flat>>(_cacheKeyFlatList);

        if (cacheDataList != null)
            return cacheDataList;

        var response = await _repositoryWrapper.Flats.GetFlatList(buildingId)
            .ToListAsync(token);

        await _redis.SetCacheDataAsync(_cacheKeyFlatList, response, 10, 5);

        return response;
    }

    public async Task<MetricNumberForTotal?> GetTotalWaterAndElectricity(int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Flats.GetTotalWaterAndElectricity(buildingId, token);
    }

    public async Task<MetricNumberForTotal?> GetTotalWaterAndElectricityByFlat(int flatId, int buildingId,
        CancellationToken token)
    {
        return await _repositoryWrapper.Flats.GetTotalWaterAndElectricityByFlat(flatId, buildingId, token);
    }

    public async Task<RepositoryResponse> SetTotalWaterAndElectricityByFlat(UpdateMetricRequest request, int flatId,
        int buildingId, CancellationToken cancellationToken)
    {
        return await _repositoryWrapper.Flats.SetTotalWaterAndElectricityByFlat(request, flatId, buildingId,
            cancellationToken);
    }
}
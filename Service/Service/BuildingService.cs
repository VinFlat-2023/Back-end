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

public class BuildingService : IBuildingService
{
    private readonly string _cacheKey = "building";
    private readonly string _cacheKeyPageNumber = "page-number-building";
    private readonly string _cacheKeyPageSize = "page-size-building";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public BuildingService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Building>?> GetBuildingList(BuildingFilter filters, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;
        /*
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Building>>(_cacheKey);
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
                        (filters.BuildingName == null ||
                         x.BuildingName.ToLower().Contains(filters.BuildingName.ToLower()))
                        && (filters.Description == null ||
                            x.Description.ToLower().Contains(filters.Description.ToLower()))
                        && (filters.BuildingAddress == null ||
                            x.BuildingAddress.ToLower().Contains(filters.BuildingAddress.ToLower()))
                        && (filters.TotalFlats == null || x.TotalFlats == filters.TotalFlats)
                        && (filters.Status == null || x.Status == filters.Status)
                        && (filters.BuildingPhoneNumber == null ||
                            x.BuildingPhoneNumber.Contains(filters.BuildingPhoneNumber))
                        && (filters.EmployeeName == null ||
                            x.Employee.Username.ToLower().Contains(filters.EmployeeName.ToLower()))
                        && (filters.AreaName == null || x.Area.Name.ToLower().Contains(filters.AreaName.ToLower()))
                        && (filters.AveragePrice == null || x.AveragePrice <= filters.AveragePrice)
                        && (filters.SpareSlots == null ||
                            x.Flats.Any(flat => flat.Rooms.Any(room => room.AvailableSlots > 0)))
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }
        */
        var queryable = _repositoryWrapper.Buildings.GetBuildingList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Building>.Create(queryable, pageNumber, pageSize, token);

        /*
        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        */
        return pagedList;
    }

    public async Task<Building?> GetBuildingById(int? buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Buildings.GetBuildingDetail(buildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<RepositoryResponse> AddBuildingAndItsManagement(Building building, int employeeId)
    {
        return await _repositoryWrapper.Buildings.AddBuildingAndItsManagement(building, employeeId);
    }

    public async Task<RepositoryResponse> UpdateBuilding(Building building)
    {
        return await _repositoryWrapper.Buildings.UpdateBuilding(building);
    }

    public async Task<RepositoryResponse> UpdateBuildingImages(Building building, int number)
    {
        return await _repositoryWrapper.Buildings.UpdateBuildingImages(building, number);
    }

    public async Task<RepositoryResponse> DeleteBuilding(int buildingId)
    {
        return await _repositoryWrapper.Buildings.DeleteBuilding(buildingId);
    }
}
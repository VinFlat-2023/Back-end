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

public class ServiceEntityService : IServiceEntityService
{
    private readonly string _cacheKey = "service-entity";
    private readonly string _cacheKeyPageNumber = "page-number-service-entity";
    private readonly string _cacheKeyPageSize = "page-size-service-entity";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceEntityService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters,
        CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        /*
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<ServiceEntity>>(_cacheKey);
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
                        (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                        && (filters.Status == null || x.Status == filters.Status)
                        && (filters.Price == null || x.Price == filters.Price)
                        && (filters.BuildingId == null || x.BuildingId == filters.BuildingId)
                        && (filters.BuildingName == null ||
                            x.Building.BuildingName.ToLower().Contains(filters.BuildingName.ToLower()))
                        && (filters.ServiceTypeId == null || x.ServiceTypeId == filters.ServiceTypeId)
                        && (filters.ServiceTypeName == null ||
                            x.ServiceType.Name.ToLower().Contains(filters.ServiceTypeName.ToLower()))
                        && (filters.Description == null ||
                            x.Description.ToLower().Contains(filters.Description.ToLower()))
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }
        */
        var queryable = _repositoryWrapper.ServiceEntities.GetServiceList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<ServiceEntity>
            .Create(queryable, pageNumber, pageSize, token);

        /*
        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        */

        return pagedList;
    }

    public async Task<ServiceEntity?> GetServiceEntityById(int? serviceEntityId, CancellationToken token)
    {
        return await _repositoryWrapper.ServiceEntities.GetServiceDetail(serviceEntityId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<ServiceEntity?> AddServiceEntity(ServiceEntity serviceEntity)
    {
        return await _repositoryWrapper.ServiceEntities.AddService(serviceEntity);
    }

    public async Task<RepositoryResponse> UpdateServiceEntity(ServiceEntity serviceEntity)
    {
        return await _repositoryWrapper.ServiceEntities.UpdateService(serviceEntity);
    }

    public async Task<RepositoryResponse> DeleteServiceEntity(int serviceEntityId)
    {
        return await _repositoryWrapper.ServiceEntities.DeleteService(serviceEntityId);
    }

    public async Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters, int? buildingId,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.ServiceEntities.GetServiceList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<ServiceEntity>
            .Create(queryable, page, size, token);

        return pagedList;
    }
}
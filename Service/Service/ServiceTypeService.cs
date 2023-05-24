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

public class ServiceTypeService : IServiceTypeService
{
    private readonly string _cacheKey = "service-type";
    private readonly string _cacheKeyPageNumber = "page-number-service-type";
    private readonly string _cacheKeyPageSize = "page-size-service-type";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<ServiceType>?> GetServiceTypeList(ServiceTypeFilter filters, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<ServiceType>>(_cacheKey);
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
                var matches =
                    cacheDataList.Where(x =>
                        (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                        && (filters.Status == null || x.Status == filters.Status)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.ServiceTypes.GetServiceTypeList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<ServiceType>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<ServiceType?> GetServiceTypeById(int? serviceTypeId, CancellationToken token)
    {
        return await _repositoryWrapper.ServiceTypes.GetServiceTypeDetail(serviceTypeId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<ServiceType?> AddServiceType(ServiceType serviceType)
    {
        return await _repositoryWrapper.ServiceTypes.AddServiceType(serviceType);
    }

    public async Task<RepositoryResponse> UpdateServiceType(ServiceType serviceType)
    {
        return await _repositoryWrapper.ServiceTypes.UpdateServiceType(serviceType);
    }

    public async Task<RepositoryResponse> DeleteServiceType(int serviceTypeId)
    {
        return await _repositoryWrapper.ServiceTypes.DeleteServiceType(serviceTypeId);
    }
}
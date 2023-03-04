using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class ServiceEntityService : IServiceEntityService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceEntityService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.ServiceEntities.GetServiceList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<ServiceEntity>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<ServiceEntity?> GetServiceEntityById(int? serviceEntityId)
    {
        return await _repositoryWrapper.ServiceEntities.GetServiceDetail(serviceEntityId)
            .FirstOrDefaultAsync();
    }

    public async Task<ServiceEntity?> AddServiceEntity(ServiceEntity serviceEntity)
    {
        return await _repositoryWrapper.ServiceEntities.AddService(serviceEntity);
    }

    public async Task<ServiceEntity?> UpdateServiceEntity(ServiceEntity serviceEntity)
    {
        return await _repositoryWrapper.ServiceEntities.UpdateService(serviceEntity);
    }

    public async Task<bool> DeleteServiceEntity(int serviceEntityId)
    {
        return await _repositoryWrapper.ServiceEntities.DeleteService(serviceEntityId);
    }

    public async Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters, int buildingId,
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

    public async Task<PagedList<ServiceEntity>?> GetServiceEntityList(int renterId, ServiceEntityFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.ServiceEntities.GetServiceList(filters, renterId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<ServiceEntity>
            .Create(queryable, page, size, token);

        return pagedList;
        
    }
}
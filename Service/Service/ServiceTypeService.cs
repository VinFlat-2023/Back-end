using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class ServiceTypeService : IServiceTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<ServiceType>?> GetServiceTypeList(ServiceTypeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.ServiceTypes.GetServiceTypeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<ServiceType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<ServiceType?> GetServiceTypeById(int? serviceTypeId)
    {
        return await _repositoryWrapper.ServiceTypes.GetServiceTypeDetail(serviceTypeId)
            .FirstOrDefaultAsync();
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
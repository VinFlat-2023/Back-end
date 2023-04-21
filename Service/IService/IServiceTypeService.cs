using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IServiceTypeService
{
    public Task<PagedList<ServiceType>?> GetServiceTypeList(ServiceTypeFilter filters, CancellationToken token);
    public Task<ServiceType?> GetServiceTypeById(int? serviceTypeId, CancellationToken cancellationToken);
    public Task<ServiceType?> AddServiceType(ServiceType serviceType);
    public Task<RepositoryResponse> UpdateServiceType(ServiceType serviceType);
    public Task<RepositoryResponse> DeleteServiceType(int serviceTypeId);
}
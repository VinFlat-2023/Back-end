using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IServiceTypeService
{
    public Task<PagedList<ServiceType>?> GetServiceTypeList(ServiceTypeFilter filters, CancellationToken token);
    public Task<ServiceType?> GetServiceTypeById(int? serviceTypeId);
    public Task<ServiceType?> AddServiceType(ServiceType serviceType);
    public Task<ServiceType?> UpdateServiceType(ServiceType serviceType);
    public Task<bool> DeleteServiceType(int serviceTypeId);
}
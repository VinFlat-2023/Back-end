using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IServiceEntityService
{
    public Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters, CancellationToken token);
    public Task<ServiceEntity?> GetServiceEntityById(int? serviceEntityId);
    public Task<ServiceEntity?> AddServiceEntity(ServiceEntity serviceEntity);
    public Task<ServiceEntity?> UpdateServiceEntity(ServiceEntity serviceEntity);
    public Task<bool> DeleteServiceEntity(int serviceEntityId);

    public Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters, int buildingId,
        CancellationToken token);

    public Task<PagedList<ServiceEntity>?> GetServiceEntityList(int renterId, ServiceEntityFilter filters,
        CancellationToken token);
}
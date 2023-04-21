using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IServiceEntityService
{
    public Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters, CancellationToken token);

    public Task<PagedList<ServiceEntity>?> GetServiceEntityList(ServiceEntityFilter filters, int? buildingId,
        CancellationToken token);

    public Task<ServiceEntity?> GetServiceEntityById(int? serviceEntityId, CancellationToken cancellationToken);
    public Task<ServiceEntity?> AddServiceEntity(ServiceEntity serviceEntity);
    public Task<RepositoryResponse> UpdateServiceEntity(ServiceEntity serviceEntity);
    public Task<RepositoryResponse> DeleteServiceEntity(int serviceEntityId);
}
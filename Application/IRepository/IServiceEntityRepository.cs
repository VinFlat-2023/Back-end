using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IServiceEntityRepository
{
    public IQueryable<ServiceEntity> GetServiceList(ServiceEntityFilter filters);
    public IQueryable<ServiceEntity> GetServiceList(ServiceEntityFilter filters, int? buildingId);
    public IQueryable<ServiceEntity> GetServiceDetail(int? serviceId);
    public Task<ServiceEntity> AddService(ServiceEntity serviceEntity);
    public Task<RepositoryResponse> UpdateService(ServiceEntity serviceEntity);
    public Task<RepositoryResponse> DeleteService(int serviceId);
}
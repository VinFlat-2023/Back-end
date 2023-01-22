using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IServiceEntityRepository
{
    public IQueryable<ServiceEntity> GetServiceList(ServiceEntityFilter filters);
    public IQueryable<ServiceEntity> GetServiceDetail(int? serviceId);
    public Task<ServiceEntity> AddService(ServiceEntity serviceEntity);
    public Task<ServiceEntity?> UpdateService(ServiceEntity serviceEntity);
    public Task<bool> DeleteService(int serviceId);
}
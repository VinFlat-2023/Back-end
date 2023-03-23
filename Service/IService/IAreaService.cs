using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IAreaService
{
    public Task<PagedList<Area>?> GetAreaList(AreaFilter filters, CancellationToken token);
    public Task<Area?> GetAreaById(int? areaId);
    public Task<RepositoryResponse> AddArea(Area area);
    public Task<RepositoryResponse> UpdateArea(Area area);
    public Task<RepositoryResponse> DeleteArea(int areaId);
}
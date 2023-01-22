using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IAreaService
{
    public Task<PagedList<Area>?> GetAreaList(AreaFilter filters, CancellationToken token);
    public Task<Area?> GetAreaById(int? areaId);
    public Task<Area?> AddArea(Area area);
    public Task<Area?> UpdateArea(Area area);
    public Task<bool> ToggleAreaStatus(int areaId);
    public Task<bool> DeleteArea(int areaId);
}
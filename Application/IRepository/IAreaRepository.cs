using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IAreaRepository
{
    public IQueryable<Area> GetAreaList(AreaFilter filters);
    public Task<Area?> GetAreaDetail(int? areaId);
    public Task<Area> AddArea(Area area);
    public Task<Area?> UpdateArea(Area? area);
    public Task<bool> ToggleArea(int areaId);
    public Task<bool> DeleteArea(int areaId);
}
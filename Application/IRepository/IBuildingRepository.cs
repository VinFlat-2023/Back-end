using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IBuildingRepository
{
    public IQueryable<Building> GetBuildingList(BuildingFilter filter);
    public IQueryable<Building?> GetBuildingDetail(int? buildingId);
    public Task<Building?> AddBuilding(Building building);
    public Task<Building?> UpdateBuilding(Building? building);
    public Task<bool> DeleteBuilding(int id);
}
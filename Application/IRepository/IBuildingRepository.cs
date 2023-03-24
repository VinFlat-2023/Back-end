using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IBuildingRepository
{
    public IQueryable<Building> GetBuildingList(BuildingFilter filter);
    public IQueryable<Building?> GetBuildingDetail(int? buildingId);
    public Task<Building?> AddBuilding(Building building);
    public Task<RepositoryResponse> UpdateBuilding(Building building);
    public Task<RepositoryResponse> DeleteBuilding(int id);
}
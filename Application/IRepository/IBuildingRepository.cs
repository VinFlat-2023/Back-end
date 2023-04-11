using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IBuildingRepository
{
    public IQueryable<Building> GetBuildingList(BuildingFilter filter);
    public IQueryable<Building> GetBuildingListBySpareSlotWithTrue();
    public IQueryable<Building?> GetBuildingDetail(int? buildingId);
    public Task<RepositoryResponse> AddBuilding(Building building);
    public Task<RepositoryResponse> UpdateBuilding(Building building);
    public Task<RepositoryResponse> UpdateBuildingImages(Building building, int number);
    public Task<RepositoryResponse> DeleteBuilding(int id);
    public IQueryable<Building> GetBuildingListByAveragePrice(decimal amount);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IBuildingService
{
    public Task<PagedList<Building>?> GetBuildingList(BuildingFilter filters, CancellationToken token);
    public Task<Building?> GetBuildingById(int? buildingId);
    public Task<RepositoryResponse> AddBuilding(Building building);
    public Task<RepositoryResponse> UpdateBuilding(Building building);
    public Task<RepositoryResponse> UpdateBuildingImages(Building building);
    public Task<RepositoryResponse> DeleteBuilding(int buildingId);
}
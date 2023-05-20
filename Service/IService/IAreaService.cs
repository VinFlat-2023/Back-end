using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IAreaService
{
    public Task<(PagedList<Area>?, bool)> GetAreaList(AreaFilter filters, CancellationToken token);
    public Task<(Area?, bool)> GetAreaByIdWithCache(int? areaId, CancellationToken token);
    public Task<Area?> GetAreaById(int? areaId, CancellationToken token);

    public Task<RepositoryResponse> GetAreaByName(string? areaName, CancellationToken token);
    public Task<RepositoryResponse> GetAreaByName(string? areaName, int? areaId, CancellationToken token);
    public Task<Area?> AddArea(Area area);
    public Task<RepositoryResponse> UpdateArea(Area area);
    public Task<RepositoryResponse> DeleteArea(int areaId);
    public Task<RepositoryResponse> UpdateAreaImage(Area updateArea, int number);
    public Task<RepositoryResponse> ToggleAreaStatus(int areaId);
}
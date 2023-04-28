using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IFlatTypeService
{
    public Task<PagedList<FlatType>?> GetFlatTypeList(FlatTypeFilter filters, int buildingId, CancellationToken token);
    public Task<FlatType?> GetFlatTypeById(int? flatTypeId, CancellationToken cancellationToken);
    public Task<FlatType?> AddFlatType(FlatType flatType);
    public Task<RepositoryResponse> UpdateFlatType(FlatType flatType);
    public Task<RepositoryResponse> ToggleStatus(int id);
    public Task<RepositoryResponse> DeleteFlatType(int flatTypeId);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFlatTypeRepository
{
    public IQueryable<FlatType> GetFlatTypeList(FlatTypeFilter filters, int buildingId);
    public IQueryable<FlatType> GetFlatTypeDetail(int? flatTypeId);
    public Task<FlatType> AddFlatType(FlatType flatTypeId);
    public Task<RepositoryResponse> UpdateFlatType(FlatType flatTypeId);
    public Task<RepositoryResponse> DeleteFlatType(int flatTypeId);
    public Task<RepositoryResponse> ToggleStatus(int id);

    public Task<RepositoryResponse> IsAnyFlatIsInUseWithThisType(int? flatTypeId, int buildingId,
        CancellationToken token);

    public Task<RepositoryResponse> IsFlatTypeNameDuplicate(string flatTypeName, int buildingId,
        CancellationToken token);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IFlatTypeService
{
    public Task<PagedList<FlatType>?> GetFlatTypeList(FlatTypeFilter filters, CancellationToken token);
    public Task<FlatType?> GetFlatTypeById(int flatTypeId);
    public Task<FlatType?> AddFlatType(FlatType flatType);
    public Task<FlatType?> UpdateFlatType(FlatType flatType);
    public Task<bool> DeleteFlatType(int flatTypeId);
}
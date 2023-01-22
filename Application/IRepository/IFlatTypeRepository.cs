using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFlatTypeRepository
{
    public IQueryable<FlatType> GetFlatTypeList(FlatTypeFilter filters);
    public IQueryable<FlatType> GetFlatTypeDetail(int flatTypeId);
    public Task<FlatType> AddFlatType(FlatType flatTypeId);
    public Task<FlatType?> UpdateFlatType(FlatType flatTypeId);
    public Task<bool> DeleteFlatType(int flatTypeId);
}
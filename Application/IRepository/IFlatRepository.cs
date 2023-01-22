using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFlatRepository
{
    public IQueryable<Flat> GetFlatList(FlatFilter filters);
    public IQueryable<Flat> GetFlatDetail(int? flatId);
    public Task<Flat> AddFlat(Flat flat);
    public Task<Flat?> UpdateFlat(Flat flat);
    public Task<bool> DeleteFlat(int flatId);
}
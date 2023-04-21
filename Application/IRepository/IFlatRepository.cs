using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFlatRepository
{
    public IQueryable<Flat> GetFlatList(FlatFilter filters);
    public IQueryable<Flat> GetFlatDetail(int? flatId);
    public Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken cancellationToken);
    public Task<Flat> AddFlat(Flat flat);
    public Task<RepositoryResponse> UpdateFlat(Flat flat);
    public Task<RepositoryResponse> DeleteFlat(int flatId);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFlatRepository
{
    public IQueryable<Flat> GetFlatList(FlatFilter filters);
    public IQueryable<Flat> GetFlatList(FlatFilter filters, int buildingId);
    public IQueryable<Flat> GetFlatDetail(int? flatId, int buildingId);
    public Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken token);
    public Task<RepositoryResponse> AddFlat(Flat flat, List<int> roomTypeId, CancellationToken cancellationToken);
    public Task<RepositoryResponse> UpdateFlat(Flat flat);
    public Task<RepositoryResponse> DeleteFlat(int flatId);
    public IQueryable<Flat> GetFlatList(int buildingId);
}
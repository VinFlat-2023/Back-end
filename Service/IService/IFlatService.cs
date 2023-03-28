using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IFlatService
{
    public Task<PagedList<Flat>?> GetFlatList(FlatFilter filter, CancellationToken token);
    public Task<Flat?> GetFlatById(int? flatId);
    public Task<Flat?> AddFlat(Flat flat);
    public Task<RepositoryResponse> UpdateFlat(Flat flat);
    public Task<RepositoryResponse> DeleteFlat(int flatId);
    public Task<RepositoryResponse> GetRoomInAFlat(int flatId);
}
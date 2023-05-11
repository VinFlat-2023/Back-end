using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<RoomType> GetRoomList(RoomTypeFilter typeFilters, int buildingId);
    public Task<RoomType?> GetRoomDetail(int? roomId, int? buildingId, CancellationToken token);
    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token);
    public Task<RepositoryResponse> DeleteRoom(int roomId, int buildingId);
    public Task<RepositoryResponse> AddRoomType(RoomType roomType);
    public Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomTypeId, int? buildingId, CancellationToken token);
}
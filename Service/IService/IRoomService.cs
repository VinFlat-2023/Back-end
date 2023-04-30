using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomService
{
    public Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token);

    public Task<RepositoryResponse> AddRoom(Room room);

    public Task<Room?> GetRoomById(int? roomId, int? buildingId, CancellationToken token);

    public Task<RepositoryResponse> DeleteRoom(int roomId, int buildingId);
    public Task<PagedList<Room>?> GetRoomList(RoomFilter filters, int buildingId, CancellationToken token);
    public Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomId, int? buildingId, CancellationToken token);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomService
{
    public Task<RepositoryResponse> UpdateRoom(Room room, CancellationToken token);

    public Task<RepositoryResponse> AddRoom(Room room);

    public Task<Room?> GetRoomById(int? roomId, CancellationToken token);

    public Task<RepositoryResponse> DeleteRoom(int roomId);
    public Task<PagedList<Room>?> GetRoomList(RoomFilter filters, int buildingId, CancellationToken token);
}
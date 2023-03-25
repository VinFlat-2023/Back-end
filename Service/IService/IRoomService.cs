using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomService
{
    public Task<RepositoryResponse> UpdateRoom(Room room);

    public Task<RepositoryResponse> AddRoom(Room room, int flatId);

    public Task<List<Room>> GetRoomListByFlatId(int id, CancellationToken token);
    public Task<Room?> GetRoomById(int? roomId);

    public Task<RepositoryResponse> DeleteRoom(int roomId);
    public Task<PagedList<Room>?> GetRoomList(RoomFilter filters, CancellationToken token);
}
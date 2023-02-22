using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IRoomService
{
    Task<Room?> UpdateRoom(Room room);

    Task<Room?> AddRoom(Room room);

    Task<List<Room>> GetRoomListByFlatId(int id, CancellationToken token);
    Task<Room?> GetRoomById(int? id);
}
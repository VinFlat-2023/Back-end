using Domain.CustomEntities;
using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IRoomService
{
    Task<Room?> UpdateRoom(Room room);

    Task<RepositoryResponse> AddRoom(Room room, int flatId);

    Task<List<Room>> GetRoomListByFlatId(int id, CancellationToken token);
    Task<Room?> GetRoomById(int? roomId);

    Task<RepositoryResponse> DeleteRoom(int roomId);
}
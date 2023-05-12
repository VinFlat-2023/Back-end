using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomService
{
    Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token);

    Task<PagedList<Room>?> GetRoomList(RoomFilter filters, int buildingId,
        CancellationToken token);
}
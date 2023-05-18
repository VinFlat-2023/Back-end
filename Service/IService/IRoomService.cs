using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomService
{
    public Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token);

    public Task<PagedList<Room>?> GetRoomList(RoomFilter filters, int buildingId,
        CancellationToken token);

    public Task<RepositoryResponse>
        IsRoomExistAndAvailableInThisFlat(int? roomId, int? flatId, CancellationToken token);

    public Task<Room?> GetRoomById(int roomId, int buildingId, CancellationToken token);

    public Task<Room?> GetRoomInAFlatById(int? roomId, int? flatId, int? buildingId,
        CancellationToken cancellationToken);

    public Task<List<Room>?> GetRoomList(int flatId, int buildingId, CancellationToken token);
}
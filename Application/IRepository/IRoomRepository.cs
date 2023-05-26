using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId);

    public Task<RepositoryResponse>
        IsRoomExistAndAvailableInThisFlat(int? roomId, int? flatId, CancellationToken token);

    public Task<Room?> GetRoomById(int roomId, int buildingId, CancellationToken token);

    public Task<Room?> GetRoomInAFlatById(int? roomId, int? flatId, int? buildingId,
        CancellationToken cancellationToken);

    public IQueryable<Room> GetRoomList(int flatId, int buildingId);
    public IQueryable<int> GetTotalRoomInBuilding(MetricRoomFilter filter, int buildingId);
    public Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token);
}
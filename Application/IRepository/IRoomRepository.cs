using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId);
    Task<RepositoryResponse> IsRoomExistAndAvailableInThisFlat(int? roomId, int? flatId, CancellationToken token);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId);
    public Task<Room?> GetRoomDetail(int? roomId, CancellationToken token);
    public Task<RepositoryResponse> UpdateRoom(Room room, CancellationToken token);
    public Task<RepositoryResponse> DeleteRoom(int roomId);
    public Task<RepositoryResponse> AddRoom(Room room);
}
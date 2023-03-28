using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomListInAFlat(int flatId);
    public Task<RepositoryResponse> AddRoomToFlat(Room room, int flatId);
    public Task<Room?> GetRoomDetail(int? roomId);
    public Task<RepositoryResponse> UpdateRoom(Room room);
    public Task<RepositoryResponse> DeleteRoom(int roomId);
    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId);
}
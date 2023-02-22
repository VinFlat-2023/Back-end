using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomListInAFlat(int flatId);
    public Task<Room> AddRoomToFlat(Room room, int flatId);
    public Task<Room> GetRoomDetail(int roomId);
    public Task<Room> UpdateRoom(Room room);
    public Task<Room> DeleteRoom(int roomId);
}
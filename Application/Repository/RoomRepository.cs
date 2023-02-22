using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationContext _context;

    public RoomRepository(ApplicationContext context)
    {
        _context = context;
    }


    public IQueryable<Room> GetRoomListInAFlat(int flatId)
    {
        throw new NotImplementedException();
    }

    public Task<Room> AddRoomToFlat(Room room, int flatId)
    {
        throw new NotImplementedException();
    }

    public Task<Room> GetRoomDetail(int roomId)
    {
        throw new NotImplementedException();
    }

    public Task<Room> UpdateRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<Room> DeleteRoom(int roomId)
    {
        throw new NotImplementedException();
    }
}
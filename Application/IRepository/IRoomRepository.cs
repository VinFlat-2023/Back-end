using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId);
}
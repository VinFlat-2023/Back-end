using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId);
    public Task<Room?> GetRoomDetail(int? roomId, int? buildingId, CancellationToken token);
    public Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token);
    public Task<RepositoryResponse> DeleteRoom(int roomId, int buildingId);
    public Task<RepositoryResponse> AddRoom(Room room);
    public Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomId, int? buildingId, CancellationToken token);
}
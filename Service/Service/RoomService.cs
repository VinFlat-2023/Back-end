using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class RoomService : IRoomService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<RepositoryResponse> UpdateRoom(Room room)
    {
        return await _repositoryWrapper.Rooms.UpdateRoom(room);
    }

    public async Task<RepositoryResponse> AddRoom(Room room, int flatId)
    {
        return await _repositoryWrapper.Rooms.AddRoomToFlat(room, flatId);
    }

    public async Task<List<Room>> GetRoomListByFlatId(int id, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.GetRoomListInAFlat(id)
            .ToListAsync(token);
    }

    public async Task<Room?> GetRoomById(int? id)
    {
        return await _repositoryWrapper.Rooms.GetRoomDetail(id);
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomId)
    {
        return await _repositoryWrapper.Rooms.DeleteRoom(roomId);
    }
}
using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.Options;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RoomService : IRoomService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public Task<Room?> UpdateRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<Room?> AddRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<List<Room>> GetRoomListByFlatId(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Room?> GetRoomById(int? id)
    {
        throw new NotImplementedException();
    }
}
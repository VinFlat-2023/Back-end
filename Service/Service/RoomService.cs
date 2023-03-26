using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
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

    public async Task<PagedList<Room>?> GetRoomList(RoomFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Rooms.GetRoomList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Room>
            .Create(queryable, page, size, token);

        return pagedList;
    }
}
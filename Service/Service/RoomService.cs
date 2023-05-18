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

    public Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<Room>?> GetRoomList(RoomFilter filters, int buildingId, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Rooms.GetRoomList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Room>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<RepositoryResponse> IsRoomExistAndAvailableInThisFlat(int? roomId, int? flatId,
        CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.IsRoomExistAndAvailableInThisFlat(roomId, flatId, token);
    }

    public async Task<Room?> GetRoomById(int roomId, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.GetRoomById(roomId, buildingId, token);
    }

    public async Task<Room?> GetRoomInAFlatById(int? roomId, int? flatId, int? buildingId,
        CancellationToken cancellationToken)
    {
        return await _repositoryWrapper.Rooms.GetRoomInAFlatById(roomId, flatId, buildingId, cancellationToken);
    }

    public async Task<List<Room>?> GetRoomList(int flatId, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.GetRoomList(flatId, buildingId)
            .ToListAsync(token);
    }
}
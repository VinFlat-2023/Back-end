using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
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

    public async Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.UpdateRoom(room, buildingId, token);
    }

    public async Task<RepositoryResponse> AddRoom(Room room)
    {
        return await _repositoryWrapper.Rooms.AddRoom(room);
    }

    public async Task<Room?> GetRoomById(int? roomId, int? buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.GetRoomDetail(roomId, buildingId, token);
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomId, int buildingId)
    {
        return await _repositoryWrapper.Rooms.DeleteRoom(roomId, buildingId);
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

    public async Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomId, int? buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.IsAnyoneRentedCheck(roomId, buildingId, token);
    }
}
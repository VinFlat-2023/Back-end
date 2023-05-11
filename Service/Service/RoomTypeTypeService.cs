using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RoomTypeTypeService : IRoomTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomTypeTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.UpdateRoomType(roomType, buildingId, token);
    }

    public async Task<RepositoryResponse> AddRoomType(RoomType roomType)
    {
        return await _repositoryWrapper.Rooms.AddRoomType(roomType);
    }

    public async Task<RoomType?> GetRoomTypeById(int? roomTypeId, int? buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.GetRoomDetail(roomTypeId, buildingId, token);
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomTypeId, int buildingId)
    {
        return await _repositoryWrapper.Rooms.DeleteRoom(roomTypeId, buildingId);
    }

    public async Task<PagedList<RoomType>?> GetRoomTypeList(RoomTypeFilter typeFilters, int buildingId,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Rooms.GetRoomList(typeFilters, buildingId);

        if (!queryable.Any())
            return null;

        var page = typeFilters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = typeFilters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<RoomType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomTypeId, int? buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Rooms.IsAnyoneRentedCheck(roomTypeId, buildingId, token);
    }
}
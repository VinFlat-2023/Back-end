using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RoomTypeService : IRoomTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.RoomsTypes.UpdateRoomType(roomType, buildingId, token);
    }

    public async Task<RepositoryResponse> AddRoomType(RoomType roomType)
    {
        return await _repositoryWrapper.RoomsTypes.AddRoomType(roomType);
    }

    public async Task<RoomType?> GetRoomTypeById(int? roomTypeId, int? buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.RoomsTypes.GetRoomTypeDetail(roomTypeId, buildingId, token);
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomTypeId, int buildingId)
    {
        return await _repositoryWrapper.RoomsTypes.DeleteRoomType(roomTypeId, buildingId);
    }

    public async Task<PagedList<RoomType>?> GetRoomTypeList(RoomTypeFilter filters, int buildingId,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.RoomsTypes.GetRoomTypeList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<RoomType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<RepositoryResponse> IsAnyFlatInUseWithThisType(int? roomTypeId, int? buildingId,
        CancellationToken token)
    {
        return await _repositoryWrapper.RoomsTypes.IsAnyFlatInUseWithThisType(roomTypeId, buildingId, token);
    }
}
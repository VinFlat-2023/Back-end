using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class RoomService : IRoomService
{
    private readonly string _cacheKey = "room";
    private readonly string _cacheKeyPageNumber = "page-number-room";
    private readonly string _cacheKeyPageSize = "page-size-room";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<Room>?> GetRoomList(RoomFilter filters, int buildingId, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Room>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                var matches =
                    cacheDataList.Where(f =>
                        (filters.RoomName == null || f.RoomName.Contains(filters.RoomName.ToLower()))
                        && (filters.RoomTypeName == null ||
                            f.RoomType.RoomTypeName.Contains(filters.RoomTypeName.ToLower()))
                        && (filters.WaterAttribute == null || f.WaterAttribute == filters.WaterAttribute)
                        && (filters.ElectricityAttribute == null ||
                            f.ElectricityAttribute == filters.ElectricityAttribute)
                        && (filters.RoomTypeId == null || f.RoomTypeId == filters.RoomTypeId)
                        && (filters.FlatId == null || f.FlatId == filters.FlatId)
                        && (filters.FlatName == null || f.Flat.Name.ToLower().Contains(filters.FlatName.ToLower()))
                        && (filters.AvailableSlots == null || f.AvailableSlots == filters.AvailableSlots)
                        && (filters.TotalSlot == null || f.RoomType.TotalSlot == filters.TotalSlot)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.Rooms.GetRoomList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Room>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

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

    public async Task<int?> GetTotalRoomInBuilding(MetricRoomFilter filters, int buildingId,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Rooms.GetTotalRoomInBuilding(filters, buildingId);

        if (!queryable.Any())
            return null;

        return await queryable.SumAsync(token);
    }
}
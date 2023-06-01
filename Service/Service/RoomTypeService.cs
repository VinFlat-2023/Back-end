using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class RoomTypeService : IRoomTypeService
{
    private readonly string _cacheKey = "room-type";
    private readonly string _cacheKeyPageNumber = "page-number-room-type";
    private readonly string _cacheKeyPageSize = "page-size-room-type";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
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
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;
        /*
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<RoomType>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

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
                    cacheDataList.Where(x =>
                        (filters.RoomTypeId == null || x.RoomTypeId == filters.RoomTypeId)
                        && (filters.RoomTypeName == null ||
                            x.RoomTypeName.ToLower().Contains(filters.RoomTypeName.ToLower()))
                        && (filters.TotalSlot == null || x.TotalSlot == filters.TotalSlot)
                        && (filters.Status == null || x.Status.ToLower() == filters.Status.ToLower())
                        && (filters.RoomTypeName == null ||
                            x.RoomTypeName.ToLower().Contains(filters.RoomTypeName.ToLower()))
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }
        */
        var queryable = _repositoryWrapper.RoomsTypes.GetRoomTypeList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<RoomType>
            .Create(queryable, pageNumber, pageSize, token);
        /*
        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        */
        return pagedList;
    }

    public async Task<RepositoryResponse> IsAnyRoomInUseWithThisType(int? roomTypeId, int? buildingId,
        CancellationToken token)
    {
        return await _repositoryWrapper.RoomsTypes.IsAnyRoomInUseWithThisType(roomTypeId, buildingId, token);
    }
}
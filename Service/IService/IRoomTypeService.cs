using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomTypeService
{
    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token);

    public Task<RepositoryResponse> AddRoomType(RoomType roomType);

    public Task<RoomType?> GetRoomTypeById(int? roomTypeId, int? buildingId, CancellationToken token);

    public Task<RepositoryResponse> DeleteRoom(int roomTypeId, int buildingId);

    public Task<PagedList<RoomType>?> GetRoomTypeList(RoomTypeFilter filters, int buildingId,
        CancellationToken token);

    public Task<RepositoryResponse> IsAnyFlatInUseWithThisType(int? roomTypeId, int? buildingId,
        CancellationToken token);
}
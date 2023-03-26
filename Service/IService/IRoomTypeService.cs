using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRoomTypeService
{
    public Task<PagedList<RoomType>?> GetRoomTypes(RoomTypeFilter filters, CancellationToken token);
    public Task<RoomType?> GetRoomTypeDetail(int roomTypeId);
    public Task<RoomType?> AddRoomType(RoomType roomType);
    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType);
    public Task<RepositoryResponse> DeleteRoomType(int roomTypeId);
}
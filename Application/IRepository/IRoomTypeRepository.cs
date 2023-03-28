using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomTypeRepository
{
    public IQueryable<RoomType> GetRoomTypeList(RoomTypeFilter filter, int buildingId);
    public IQueryable<RoomType> GetRoomTypeDetail(int? roomTypeId, int buildingId);
    public Task<RoomType> CreateRoomType(RoomType roomType);
    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId);
    public Task<RepositoryResponse> DeleteRoomType(int roomTypeId, int buildingId);
}
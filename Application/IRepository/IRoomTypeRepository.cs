using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomTypeRepository
{
    public IQueryable<RoomType> GetRoomTypeList(RoomTypeFilter filter);
    public IQueryable<RoomType> GetRoomTypeDetail(int? roomTypeId);
    public Task<RoomType> CreateRoomType(RoomType roomType);
    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType);
    public Task<RepositoryResponse> DeleteRoomType(int roomTypeId);
}
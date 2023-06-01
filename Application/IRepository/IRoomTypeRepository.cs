using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRoomTypeRepository
{
    public IQueryable<RoomType> GetRoomTypeList(RoomTypeFilter filters, int buildingId);
    public Task<RoomType?> GetRoomTypeDetail(int? roomTypeId, int? buildingId, CancellationToken token);
    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token);
    public Task<RepositoryResponse> DeleteRoomType(int roomTypeId, int buildingId);
    public Task<RepositoryResponse> AddRoomType(RoomType roomType);

    public Task<RepositoryResponse> IsAnyRoomInUseWithThisType(int? roomTypeId, int? buildingId,
        CancellationToken token);
}
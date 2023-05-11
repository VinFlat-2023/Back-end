using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationContext _context;

    public RoomRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<RoomType> GetRoomList(RoomTypeFilter typeFilters, int buildingId)
    {
        return _context.Rooms
            .Where(x => x.BuildingId == buildingId)
            .Where(x =>
                (typeFilters.RoomTypeId == null || x.RoomTypeId == typeFilters.RoomTypeId)
                && (typeFilters.RoomTypeName == null ||
                    x.RoomTypeName.ToLower().Contains(typeFilters.RoomTypeName.ToLower()))
                && (typeFilters.TotalSlot == null || x.TotalSlot == typeFilters.TotalSlot)
                && (typeFilters.Status == null || x.Status.ToLower() == typeFilters.Status.ToLower())
                && (typeFilters.Description == null ||
                    x.Description.ToLower().Contains(typeFilters.Description.ToLower()))
                && (typeFilters.RoomTypeName == null ||
                    x.RoomTypeName.ToLower().Contains(typeFilters.RoomTypeName.ToLower())))
            .AsNoTracking();
    }

    public async Task<RepositoryResponse> AddRoomType(RoomType roomType)
    {
        await _context.Rooms.AddAsync(roomType);
        return await _context.SaveChangesAsync() > 0
            ? new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tạo phòng thành công"
            }
            : new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo phòng thất bại"
            };
    }

    public async Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomTypeId, int? buildingId, CancellationToken token)
    {
        var roomCheck = await _context.Rooms
            .Where(x => x.RoomTypeId == roomTypeId && x.BuildingId == buildingId)
            .ToListAsync(token);

        if (!roomCheck.Any())
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng không tồn tại"
            };

        // Get list of room flat id
        var roomFlatCheck = _context.RoomFlats
            .Where(x => x.RoomTypeId == roomTypeId)
            .Select(x => x.RoomId);

        if (!roomFlatCheck.Any())
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Loại phòng này chưa được sử dụng"
            };

        // Check if any active contract is using this room flat
        var isRoomFlatRented = _context.Contracts
            .Where(x => x.BuildingId == buildingId
                        && roomFlatCheck.Contains(x.RoomId)
                        && x.ContractStatus.ToLower() == "active".ToLower());

        if (isRoomFlatRented.Count() > 1 || !isRoomFlatRented.Any())
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Loại phòng này đang được sử dụng"
            };

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Loại phòng này chưa được sử dụng"
        };
    }

    public async Task<RoomType?> GetRoomDetail(int? roomId, int? buildingId, CancellationToken token)
    {
        return await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomId && x.BuildingId == buildingId, token);
    }

    public async Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token)
    {
        var roomData = await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomType.RoomTypeId
                                      && x.BuildingId == buildingId, token);

        if (roomData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng không tồn tại hoặc đã bị xóa"
            };

        roomData.RoomTypeName = roomType.RoomTypeName;
        roomData.Description = roomType.Description;
        roomData.Status = roomType.Status;
        roomData.TotalSlot = roomType.TotalSlot;

        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Phòng đã được cập nhật thành công"
        };
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomId, int buildingId)
    {
        var roomFound = await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomId && x.BuildingId == buildingId);
        switch (roomFound)
        {
            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Phòng không tồn tại hoặc đã bị xóa"
                };
            case not null:
                _context.Rooms.Remove(roomFound);
                await _context.SaveChangesAsync();
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "Phòng đã được xóa thành công"
                };
        }
    }
}
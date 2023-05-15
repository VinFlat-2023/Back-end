using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly ApplicationContext _context;

    public RoomTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<RoomType> GetRoomTypeList(RoomTypeFilter filters, int buildingId)
    {
        return _context.RoomTypes
            .Where(x => x.BuildingId == buildingId)
            .Where(x =>
                (filters.RoomTypeId == null || x.RoomTypeId == filters.RoomTypeId)
                && (filters.RoomTypeName == null ||
                    x.RoomTypeName.ToLower().Contains(filters.RoomTypeName.ToLower()))
                && (filters.TotalSlot == null || x.TotalSlot == filters.TotalSlot)
                && (filters.Status == null || x.Status.ToLower() == filters.Status.ToLower())
                && (filters.Description == null ||
                    x.Description.ToLower().Contains(filters.Description.ToLower()))
                && (filters.RoomTypeName == null ||
                    x.RoomTypeName.ToLower().Contains(filters.RoomTypeName.ToLower())))
            .AsNoTracking();
    }

    public async Task<RepositoryResponse> AddRoomType(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);
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

    public async Task<RepositoryResponse> IsAnyFlatInUseWithThisType(int? roomTypeId, int? buildingId,
        CancellationToken token)
    {
        var roomTypeCheck = await _context.RoomTypes
            .Where(x => x.RoomTypeId == roomTypeId && x.BuildingId == buildingId)
            .ToListAsync(token);

        if (!roomTypeCheck.Any())
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng không tồn tại"
            };

        // Get list of room flat id
        var roomCheck = _context.Rooms
            .Where(x => x.RoomTypeId == roomTypeId)
            .Select(x => x.RoomId);

        if (!roomCheck.Any())
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Loại phòng này chưa được sử dụng"
            };

        // Check if any active contract is using this room flat
        var isRoomRented = _context.Contracts
            .Where(x => x.BuildingId == buildingId
                        && roomCheck.Contains(x.RoomId)
                        && x.ContractStatus.ToLower() == "active".ToLower());

        if (isRoomRented.Count() > 1 || !isRoomRented.Any())
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

    public async Task<RoomType?> GetRoomTypeDetail(int? roomTypeId, int? buildingId, CancellationToken token)
    {
        return await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomTypeId && x.BuildingId == buildingId, token);
    }

    public async Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId, CancellationToken token)
    {
        var roomTypeData = await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomType.RoomTypeId
                                      && x.BuildingId == buildingId, token);

        if (roomTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Loại phòng không tồn tại hoặc đã bị xóa"
            };

        roomTypeData.RoomTypeName = roomType.RoomTypeName;
        roomTypeData.Status = roomType.Status;
        roomTypeData.TotalSlot = roomType.TotalSlot;

        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Loại phòng đã được cập nhật thành công"
        };
    }

    public async Task<RepositoryResponse> DeleteRoomType(int roomTypeId, int buildingId)
    {
        var roomTypeFound = await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomTypeId && x.BuildingId == buildingId);

        switch (roomTypeFound)
        {
            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Loại phòng không tồn tại hoặc đã bị xóa"
                };
            case not null:
                _context.RoomTypes.Remove(roomTypeFound);
                await _context.SaveChangesAsync();
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "Loại phòng đã được xóa thành công"
                };
        }
    }
}
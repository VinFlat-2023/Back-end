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

    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId)
    {
        return _context.Rooms
            .Where(x => x.BuildingId == buildingId)
            .Where(x =>
                (filters.RoomId == null || x.RoomId == filters.RoomId)
                && (filters.RoomSignName == null || x.RoomSignName.ToLower().Contains(filters.RoomSignName.ToLower()))
                && (filters.TotalSlot == null || x.TotalSlot == filters.TotalSlot)
                && (filters.Status == null || x.Status.ToLower() == filters.Status.ToLower())
                && (filters.Description == null || x.Description.ToLower().Contains(filters.Description.ToLower()))
                && (filters.RoomSignName == null || x.RoomSignName.ToLower().Contains(filters.RoomSignName.ToLower())))
            .AsNoTracking();
    }

    public async Task<RepositoryResponse> AddRoom(Room room)
    {
        await _context.Rooms.AddAsync(room);
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

    public async Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomId, int? buildingId, CancellationToken token)
    {
        var roomCheck = await _context.Rooms
            .Where(x => x.RoomId == roomId && x.BuildingId == buildingId)
            .ToListAsync(token);

        if (!roomCheck.Any())
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng không tồn tại"
            };

        // Get list of room flat id
        var roomFlatCheck = _context.RoomFlats
            .Where(x => x.RoomId == roomId)
            .Select(x => x.RoomFlatId);

        if (!roomFlatCheck.Any())
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Loại phòng này chưa được sử dụng"
            };

        // Check if any active contract is using this room flat
        var isRoomFlatRented = _context.Contracts
            .Where(x => x.BuildingId == buildingId
                        && roomFlatCheck.Contains(x.RoomFlatId)
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

    public async Task<Room?> GetRoomDetail(int? roomId, int? buildingId, CancellationToken token)
    {
        return await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomId == roomId && x.BuildingId == buildingId, token);
    }

    public async Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token)
    {
        var roomData = await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomId == room.RoomId
                                      && x.BuildingId == buildingId, token);

        if (roomData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng không tồn tại hoặc đã bị xóa"
            };

        roomData.RoomSignName = room.RoomSignName;
        roomData.Description = room.Description;
        roomData.Status = room.Status;
        roomData.TotalSlot = room.TotalSlot;

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
            .FirstOrDefaultAsync(x => x.RoomId == roomId && x.BuildingId == buildingId);
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
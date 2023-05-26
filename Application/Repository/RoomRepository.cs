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

    public IQueryable<Room> GetRoomList(int flatId, int buildingId)
    {
        return _context.Rooms
            .Include(x => x.RoomType)
            .Include(x => x.Flat)
            .Where(x => x.BuildingId == buildingId && x.FlatId == flatId && x.Status.ToLower() == "active")
            .AsNoTracking();
    }

    public IQueryable<int> GetTotalRoomInBuilding(MetricRoomFilter filter, int buildingId)
    {
        return _context.Rooms
            .Where(x => x.BuildingId == buildingId)
            .Where(f => filter.Status == null || f.Status == filter.Status)
            .Select(x => x.RoomId);
    }

    public async Task<RepositoryResponse> UpdateRoom(Room room, int buildingId, CancellationToken token)
    {
        var roomCheck = await _context.Rooms
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId && x.RoomId == room.RoomId, token);

        if (roomCheck == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng này không tồn tại trong tòa nhà đã chọn"
            };

        roomCheck.RoomName = room.RoomName;
        roomCheck.RoomTypeId = room.RoomTypeId;
        roomCheck.FlatId = room.FlatId;
        roomCheck.WaterAttribute = room.WaterAttribute;
        roomCheck.ElectricityAttribute = room.ElectricityAttribute;
        roomCheck.Status = room.Status;

        _context.Attach(roomCheck).State = EntityState.Modified;
        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Cập nhật phòng thành công"
        };
    }

    public IQueryable<Room> GetRoomList(RoomFilter filters, int buildingId)
    {
        return _context.Rooms
            .Include(x => x.RoomType)
            .Include(x => x.Flat)
            .Where(x => x.BuildingId == buildingId)
            .Where(f =>
                (filters.RoomName == null || f.RoomName.Contains(filters.RoomName.ToLower()))
                && (filters.RoomTypeName == null || f.RoomType.RoomTypeName.Contains(filters.RoomTypeName.ToLower()))
                && (filters.WaterAttribute == null || f.WaterAttribute == filters.WaterAttribute)
                && (filters.ElectricityAttribute == null || f.ElectricityAttribute == filters.ElectricityAttribute)
                && (filters.RoomTypeId == null || f.RoomTypeId == filters.RoomTypeId)
                && (filters.FlatId == null || f.FlatId == filters.FlatId)
                && (filters.FlatName == null || f.Flat.Name.ToLower().Contains(filters.FlatName.ToLower()))
                && (filters.AvailableSlots == null || f.AvailableSlots == filters.AvailableSlots)
                && (filters.TotalSlot == null || f.RoomType.TotalSlot == filters.TotalSlot))
            .AsNoTracking();
    }

    public async Task<RepositoryResponse> IsRoomExistAndAvailableInThisFlat(int? roomId, int? flatId,
        CancellationToken token)
    {
        var roomCheck = await _context.Rooms
            .FirstOrDefaultAsync(x => x.FlatId == flatId
                                      && x.RoomId == roomId
                                      && x.Status.ToLower() == "active", token);

        if (roomCheck == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng này không tồn tại trong căn hộ đã chọn"
            };

        if (roomCheck.AvailableSlots == 0)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng này đã đầy"
            };

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Phòng này tồn tại trong căn hộ đã chọn"
        };
    }

    public async Task<Room?> GetRoomById(int roomId, int buildingId, CancellationToken token)
    {
        var roomCheck = await _context.Rooms
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId && x.RoomId == roomId, token);

        return roomCheck ?? null;
    }

    public async Task<Room?> GetRoomInAFlatById(int? roomId, int? flatId, int? buildingId,
        CancellationToken cancellationToken)
    {
        var roomInAFlatCheck = await _context.Rooms
            .FirstOrDefaultAsync(x => x.FlatId == flatId
                                      && x.RoomId == roomId
                                      && x.BuildingId == buildingId, cancellationToken);
        return roomInAFlatCheck ?? null;
    }

    public async Task<int?> GetTotalRoomInBuilding(MetricRoomFilter metricRoomFilter, int buildingId,
        CancellationToken token)
    {
        return await _context.Rooms
            .Where(x => x.BuildingId == buildingId)
            .Select(x => x.RoomId)
            .SumAsync(x => x, token);
    }
}
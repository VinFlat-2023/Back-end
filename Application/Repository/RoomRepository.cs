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
            .FirstOrDefaultAsync(x => x.FlatId == flatId && x.RoomId == roomId, token);

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
}
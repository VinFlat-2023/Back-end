using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RoomFlatRepository : IRoomFlatRepository
{
    private readonly ApplicationContext _context;

    public RoomFlatRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Room> GetRoomFlatList(RoomFlatFilter filters, int buildingId)
    {
        return _context.RoomFlats
            .Include(x => x.RoomType)
            .Include(x => x.Flat)
            .Where(x => x.Flat.BuildingId == buildingId)
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
}
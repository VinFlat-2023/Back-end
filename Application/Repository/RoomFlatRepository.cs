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

    public IQueryable<RoomFlat> GetRoomFlatList(RoomFlatFilter filters, int buildingId)
    {
        return _context.RoomFlats
            .Include(x => x.Room)
            .Include(x => x.Flat)
            .Where(x => x.Flat.BuildingId == buildingId)
            .Where(f =>
                (filters.RoomName == null || f.RoomName.Contains(filters.RoomName.ToLower()))
                && (filters.RoomSignName == null || f.Room.RoomSignName.Contains(filters.RoomSignName.ToLower()))
                && (filters.WaterAttribute == null || f.WaterAttribute == filters.WaterAttribute)
                && (filters.ElectricityAttribute == null || f.ElectricityAttribute == filters.ElectricityAttribute)
                && (filters.RoomId == null || f.RoomId == filters.RoomId)
                && (filters.FlatId == null || f.FlatId == filters.FlatId)
                && (filters.FlatName == null || f.Flat.Name.ToLower().Contains(filters.FlatName.ToLower()))
                && (filters.AvailableSlots == null || f.AvailableSlots == filters.AvailableSlots)
                && (filters.TotalSlot == null || f.Room.TotalSlot == filters.TotalSlot))
            .AsNoTracking();
    }
}
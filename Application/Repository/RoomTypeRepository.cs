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

    public IQueryable<RoomType> GetRoomTypeList(RoomTypeFilter filter)
    {
        return _context.RoomTypes
            .Where(x =>
                (filter.RoomTypeName == null || x.RoomTypeName.Contains(filter.RoomTypeName) 
                    && (filter.Description == null || x.Description.Contains(filter.Description))
                    && (filter.NumberOfSlots == null || x.NumberOfSlots == filter.NumberOfSlots))
            ).AsNoTracking();
    }

    public IQueryable<RoomType> GetRoomTypeDetail(int? roomTypeId)
    {
        return _context.RoomTypes
            .Where(x => x.RoomTypeId == roomTypeId);
    }

    public async Task<RoomType> CreateRoomType(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);
        await _context.SaveChangesAsync();
        return roomType;
    }

    public async Task<RepositoryResponse> UpdateRoomType(RoomType roomType)
    {
        var roomTypeData = await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomType.RoomTypeId);

        if (roomTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Room type not found"
            };

        roomTypeData.RoomTypeName = roomTypeData.RoomTypeName;
        roomTypeData.Description = roomTypeData.Description;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Room type updated"
        };

    }

    public async Task<RepositoryResponse> DeleteRoomType(int roomTypeId)
    {
        var roomTypeFound = await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomTypeId);
        if (roomTypeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Room type not found"
            };

        _context.RoomTypes.Remove(roomTypeFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Room type deleted"
        };
    }
}
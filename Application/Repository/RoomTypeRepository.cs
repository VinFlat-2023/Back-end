/*
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

    public IQueryable<RoomType> GetRoomTypeList(RoomTypeFilter filter, int buildingId)
    {
        return _context.RoomTypes
            .Where(x => x.BuildingId == buildingId)
            .Where(x =>
                (filter.RoomTypeName == null || x.RoomTypeName.ToLower().Contains(filter.RoomTypeName.ToLower()))
                && (filter.Description == null || x.Description.ToLower().Contains(filter.Description.ToLower()))
                && (filter.NumberOfSlots == null || x.NumberOfSlots == filter.NumberOfSlots))
            .AsNoTracking();
    }

    public IQueryable<RoomType> GetRoomTypeDetail(int? roomTypeId, int buildingId)
    {
        return _context.RoomTypes
            .Where(x => x.RoomTypeId == roomTypeId && x.BuildingId == buildingId);
    }

    public async Task<RoomType> CreateRoomType(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);
        await _context.SaveChangesAsync();
        return roomType;
    }

    public async Task<RepositoryResponse> UpdateRoomType(RoomType roomType, int buildingId)
    {
        var roomTypeData = await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomType.RoomTypeId && x.BuildingId == buildingId);

        switch (roomTypeData)
        {
            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Room type not found"
                };
            case not null when roomTypeData.RoomTypeName == roomType.RoomTypeName:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Room type name already exists"
                };

            case not null when roomTypeData.BuildingId == 0 || roomTypeData.BuildingId != buildingId:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Building id not found"
                };

            case not null when roomTypeData.NumberOfSlots == roomType.NumberOfSlots:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "There is already a room type with the same number of slots"
                };
        }

        // Do not change building id
        roomTypeData.RoomTypeName = roomTypeData.RoomTypeName;
        roomTypeData.Description = roomTypeData.Description;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Room type updated"
        };
    }

    public async Task<RepositoryResponse> DeleteRoomType(int roomTypeId, int buildingId)
    {
        var roomTypeFound = await _context.RoomTypes
            .FirstOrDefaultAsync(x => x.RoomTypeId == roomTypeId && x.BuildingId == buildingId);
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
*/


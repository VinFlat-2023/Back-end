using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
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

    public IQueryable<Room> GetRoomListInAFlat(int flatId)
    {
        return _context.Rooms
            .Where(x => x.FlatId == flatId)
            .AsNoTracking();
    }

    public async Task<RepositoryResponse> AddRoomToFlat(Room room, int flatId)
    {
        var isRoomAvailableInFoundFlat = await _context.Flats
            .FirstOrDefaultAsync(x => x.FlatId == flatId);

        switch (isRoomAvailableInFoundFlat)
        {
            case { AvailableRoom: > 0 }:
                try
                {
                    await _context.Rooms.AddAsync(room);
                }
                catch
                {
                    return new RepositoryResponse
                    {
                        IsSuccess = false,
                        Message = "Failed to add new room to flat"
                    };
                }

                // reduce number of available room
                isRoomAvailableInFoundFlat.AvailableRoom--;

                await _context.SaveChangesAsync();

                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = ""
                };

            case { AvailableRoom: <= 0 }:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "No available room slots left"
                };

            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Room not found or does not exist"
                };
        }
    }

    public async Task<Room?> GetRoomDetail(int? roomId)
    {
        return await _context.Rooms
            .Include(x => x.RoomType)
            .FirstOrDefaultAsync(x => x.RoomId == roomId);
    }

    public async Task<RepositoryResponse> UpdateRoom(Room room)
    {
        var roomData = await _context.Rooms
            .Include(x => x.RoomType)
            .FirstOrDefaultAsync(x => x.RoomId == room.RoomId);

        if (roomData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Room not found or does not exist"
            };

        roomData.AvailableSlots = room?.AvailableSlots ?? roomData.AvailableSlots;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Room updated successfully"
        };
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomId)
    {
        var roomFound = await _context.Rooms
            .Include(x => x.RoomType)
            .FirstOrDefaultAsync(x => x.RoomId == roomId);
        switch (roomFound)
        {
            case { AvailableSlots: > 0 }:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "There is / are room still in rental"
                };
            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Room not found or does not exist"
                };
            case not null:
                _context.Rooms.Remove(roomFound);
                await _context.SaveChangesAsync();
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "Room deleted successfully"
                };
        }
    }
}
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
                        ErrorMessage = "Failed to add new room to flat"
                    };
                }

                // reduce number of available room
                isRoomAvailableInFoundFlat.AvailableRoom--;

                await _context.SaveChangesAsync();

                return new RepositoryResponse
                {
                    IsSuccess = true,
                    ErrorMessage = ""
                };

            case { AvailableRoom: <= 0 }:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "No available room slots left"
                };

            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Room not found or does not exist"
                };
        }
    }

    public async Task<Room?> GetRoomDetail(int? roomId)
    {
        return await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomId == roomId);
    }

    public async Task<Room?> UpdateRoom(Room? room)
    {
        var roomData = await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomId == room.RoomId);

        if (roomData == null)
            return null;

        roomData.AvailableSlots = room?.AvailableSlots ?? roomData.AvailableSlots;

        await _context.SaveChangesAsync();

        return roomData;
    }

    public async Task<RepositoryResponse> DeleteRoom(int roomId)
    {
        var roomFound = await _context.Rooms
            .FirstOrDefaultAsync(x => x.RoomId == roomId);
        switch (roomFound)
        {
            case { AvailableSlots: > 0 }:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "There is / are room still in rental"
                };
            case null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Room not found or does not exist"
                };
            case not null:
                _context.Rooms.Remove(roomFound);
                await _context.SaveChangesAsync();
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    ErrorMessage = ""
                };
        }
    }
}
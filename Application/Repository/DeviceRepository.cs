/*
using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class DeviceRepository : IDeviceRepository
{
    private readonly ApplicationContext _context;

    public DeviceRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<UserDevice> AddUserDeviceInfo(UserDevice ud)
    {
        await _context.UserDevices.AddAsync(ud);
        await _context.SaveChangesAsync();
        return ud;
    }

    public async Task DeleteUserDevice(List<UserDevice> userDevices)
    {
        _context.UserDevices.RemoveRange(userDevices);
        await _context.SaveChangesAsync();
    }

    public async Task<List<UserDevice>> GetDeviceByUserName(string? userName)
    {
        var udList = await _context.UserDevices.Where(u => u.UserName.Equals(userName)).ToListAsync();
        return udList;
    }

    public async Task<List<UserDevice>> GetListUserDeviceByToken(string deviceToken)
    {
        var result = await _context.UserDevices
            .Where(u => u.DeviceToken.Equals(deviceToken))
            .ToListAsync();
        return result;
    }

    public async Task<UserDevice> GetUDByDeviceToken(string? deviceToken)
    {
        var userDevice = await _context.UserDevices.Where(u => u.DeviceToken.Equals(deviceToken)).FirstOrDefaultAsync();
        return userDevice;
    }

    public async Task<UserDevice> UpdateUserDeviceInfo(UserDevice ud)
    {
        _context.UserDevices.Update(ud);
        await _context.SaveChangesAsync();
        return ud;
    }
}
*/


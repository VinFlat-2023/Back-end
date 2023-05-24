/*
using Application.IRepository;
using Domain.EntitiesForManagement;
using Service.IService;

namespace Service.Service;

public class DeviceService : IDeviceService
{
    private readonly IRepositoryWrapper _wrapper;

    public DeviceService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }

    public async Task<UserDevice> AddUserDeviceInfo(UserDevice ud)
    {
        return await _wrapper.Devices.AddUserDeviceInfo(ud);
    }

    public async Task DeleteUserDevice(List<UserDevice> userDevices)
    {
        await _wrapper.Devices.DeleteUserDevice(userDevices);
    }

    public async Task<List<UserDevice>> GetDeviceByUserName(string? userName)
    {
        return await _wrapper.Devices.GetDeviceByUserName(userName);
    }

    public async Task<List<UserDevice>> GetListUserDeviceByToken(string deviceToken)
    {
        return await _wrapper.Devices.GetListUserDeviceByToken(deviceToken);
    }

    public async Task<UserDevice> GetUdByDeviceToken(string? deviceToken)
    {
        return await _wrapper.Devices.GetUDByDeviceToken(deviceToken);
    }

    public async Task<UserDevice> UpdateUserDeviceInfo(UserDevice ud)
    {
        return await _wrapper.Devices.UpdateUserDeviceInfo(ud);
    }
}
*/


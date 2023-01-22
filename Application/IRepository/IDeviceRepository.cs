using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IDeviceRepository
{
    public Task<UserDevice> UpdateUserDeviceInfo(UserDevice ud);
    public Task<UserDevice> AddUserDeviceInfo(UserDevice ud);
    public Task DeleteUserDevice(List<UserDevice> userDevices);
    public Task<List<UserDevice>> GetDeviceByUserName(string? userName);
    public Task<UserDevice> GetUDByDeviceToken(string? deviceToken);
    public Task<List<UserDevice>> GetListUserDeviceByToken(string deviceToken);
}
namespace Domain.EntitiesForManagement;

public class UserDevice
{
    public int UserDeviceId { get; set; }
    public string? UserName { get; set; } = null!;
    public string? DeviceToken { get; set; } = null!;
}
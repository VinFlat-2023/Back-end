namespace Domain.EntitiesDTO.UserDeviceDTO;

public class UserDeviceDto
{
    public int UserDeviceId { get; set; }
    public string UserName { get; set; } = null!;
    public string DeviceToken { get; set; } = null!;
}
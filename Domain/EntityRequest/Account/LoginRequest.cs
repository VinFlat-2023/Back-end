namespace Domain.EntityRequest.Employee;

public class LoginRequest
{
    public string AccessToken { get; set; }
    public string DeviceToken { get; set; }
}
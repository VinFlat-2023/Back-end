namespace Domain.EntityRequest.Account;

public class LoginRequest
{
    public string AccessToken { get; set; }
    public string DeviceToken { get; set; }
}
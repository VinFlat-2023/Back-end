namespace Domain.EntityRequest.Renter;

public class RegisterRequest
{
    public RenterCreateRequest RenterCreateRequest { get; set; }
    public string AccessToken { get; set; }
    public string DeviceToken { get; set; }
}
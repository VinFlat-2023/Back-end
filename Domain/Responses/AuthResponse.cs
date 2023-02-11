using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesDTO.RenterDTO;

namespace Domain.Responses;

public class AuthResponse
{
    public RenterDto Renter { get; set; }
    public AccountDto Account { get; set; }
    public string AccessToken { get; set; }
}
using Domain.EntitiesForManagement;

namespace Service.IService;

public interface ITokenService
{
    string CreateTokenForRenter(Renter renter);
    string CreateTokenForAccount(Account account);
}
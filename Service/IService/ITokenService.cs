using Domain.EntitiesForManagement;

namespace Service.IService;

public interface ITokenService
{
    string CreateTokenForRenter(Renter renter);
    string CreateTokenForEmployee(Employee employee);
}
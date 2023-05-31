using Domain.EntitiesForManagement;
using Domain.EnumEntities;

namespace Service.IService;

public interface ITokenService
{
    string CreateTokenForRenter(Renter renter, TokenType type);
    string CreateTokenForEmployee(Employee employee, TokenType type);
}
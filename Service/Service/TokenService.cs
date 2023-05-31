using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace Service.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateTokenForRenter(Renter user, TokenType tokenType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, "Renter"),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Actor, user.Username),
            new(ClaimTypes.Name, user.RenterId.ToString()),
            new(ClaimTypes.NameIdentifier, tokenType.ToString())
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));

        var credential = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            _configuration["JwtToken:Issuer"],
            _configuration["JwtToken:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(21),
            signingCredentials: credential);

        return tokenHandler.WriteToken(token);
    }

    public string CreateTokenForEmployee(Employee employee, TokenType tokenType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, employee.Role.RoleName),
            new(ClaimTypes.Email, employee.Email),
            new(ClaimTypes.Actor, employee.Username),
            new(ClaimTypes.Name, employee.EmployeeId.ToString()),
            new(ClaimTypes.NameIdentifier, tokenType.ToString())
        };
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));

        var credential = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            _configuration["JwtToken:Issuer"],
            _configuration["JwtToken:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(21),
            signingCredentials: credential);

        return tokenHandler.WriteToken(token);
    }
}
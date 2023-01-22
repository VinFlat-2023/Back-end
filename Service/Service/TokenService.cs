using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.EntitiesForManagement;
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

    public string CreateTokenForRenter(Renter user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, "Renter"),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Actor, user.Username),
            new(ClaimTypes.Name, user.RenterId.ToString())
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));

        var credential = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            _configuration["JwtToken:Issuer-Local"],
            _configuration["JwtToken:Audience-Local"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credential);

        return tokenHandler.WriteToken(token);
    }

    public string CreateTokenForAccount(Account account)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, account.Role.RoleName),
            new(ClaimTypes.Email, account.Email),
            new(ClaimTypes.Actor, account.Username),
            new(ClaimTypes.Name, account.AccountId.ToString())
        };
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));

        var credential = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            _configuration["JwtToken:Issuer-Local"],
            _configuration["JwtToken:Audience-Local"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credential);

        return tokenHandler.WriteToken(token);
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Utilities.ServiceExtensions;

public static class JwtAuthenticationService
{
    public static IServiceCollection AddJwtAuthenticationService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Remember to set to true on production
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                        (configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"])),
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtToken:Issuer"],
                    ValidAudience = configuration["JwtToken:Audience"]
                };
            });
        return services;
    }
}
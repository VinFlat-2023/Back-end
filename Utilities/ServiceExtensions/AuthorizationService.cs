using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class AuthorizationService
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {
        services.AddAuthorization(o =>
        {
            o.AddPolicy("SuperAdmin", policy => policy.RequireClaim("SuperAdmin"));
            o.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
            o.AddPolicy("Supervisor", policy => policy.RequireClaim("Supervisor"));
            o.AddPolicy("Technician", policy => policy.RequireClaim("Technician"));
            o.AddPolicy("Renter", policy => policy.RequireClaim("Renter"));
        });
        return services;
    }
}
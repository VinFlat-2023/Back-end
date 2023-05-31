using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class RateLimitingService
{
    public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        // Used to store rate limit counters and ip rules
        services.AddMemoryCache();


        // Load in general configuration from appsettings.json
        services.Configure<IpRateLimitOptions>(options
            => configuration.GetSection("IpRateLimitingSettings").Bind(options));

        services.Configure<IpRateLimitPolicies>(options
            => configuration.GetSection("IpRateLimitingPolicies").Bind(options));

        services.Configure<ClientRateLimitOptions>(options
            => configuration.GetSection("ClientRateLimitingSettings").Bind(options));

        // Inject Counter and Store Rules
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();

        // Return the services
        return services;
    }
}
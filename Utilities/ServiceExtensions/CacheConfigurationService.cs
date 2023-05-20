using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class CacheConfigurationService
{
    public static IServiceCollection AddCacheConfigurationService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));
        return services;
    }
}
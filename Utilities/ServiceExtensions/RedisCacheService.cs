using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class RedisCacheService
{
    public static IServiceCollection AddRedisCacheService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("AzureRedisUrl");
            options.InstanceName = "master";
        });
        return services;
    }
}
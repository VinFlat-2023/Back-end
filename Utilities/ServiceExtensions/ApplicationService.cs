using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(
            option => option.UseSqlServer(
                configuration["TotallyNotConnectionString:Secret"]));
        return services;
    }
}
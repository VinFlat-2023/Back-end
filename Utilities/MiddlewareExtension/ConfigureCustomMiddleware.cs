using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Utilities.Middleware;

namespace Utilities.MiddlewareExtension;

public static class ConfigureCustomMiddleware
{
    public static IApplicationBuilder ConfigMiddleware(this IApplicationBuilder app, IConfiguration configuration)
    {
        var isEnabled = configuration.GetSection("LogSettings:IsLoggerEnabled").Value;
        if (isEnabled == "True")
            app.UseMiddleware<LoggingMiddleware>();

        return app;
    }
}
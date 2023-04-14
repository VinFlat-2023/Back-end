using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Utilities.Middleware;

namespace Utilities.MiddlewareExtension;

public static class ConfigureCustomMiddleware
{
    public static IApplicationBuilder ConfigMiddleware(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    }
}
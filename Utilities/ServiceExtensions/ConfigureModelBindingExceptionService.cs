using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class ConfigureModelBindingExceptionService
{
    public static IServiceCollection ConfigureModelBindingExceptionHandling(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var error = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new ValidationProblemDetails(actionContext.ModelState)).FirstOrDefault();

                // Here you can add logging to you log file or to your Application Insights.
                // For example, using Serilog:
                // Log.Error($"{{@RequestPath}} received invalid message format: {{@Exception}}", 
                //   actionContext.HttpContext.Request.Path.Value, 
                //   error.Errors.Values);
                return new BadRequestObjectResult(new
                {
                    status = "Bad Request",
                    message = error,
                    data = ""
                });
            };
        });
        return services;
    }
}
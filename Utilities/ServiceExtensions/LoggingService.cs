using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Utilities.ServiceExtensions;

public static class LoggingService
{
    public static ILoggingBuilder AddLoggerConfig(this ILoggingBuilder builder)
    {
        builder.Services.AddLogging();
        builder.ClearProviders();
        builder.AddConsole();
        return builder;
    }
}
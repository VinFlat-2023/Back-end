using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Utilities.ServiceExtensions.Scheduler.Jobs;
using Utilities.ServiceExtensions.Scheduler.Lib;

namespace Utilities.ServiceExtensions.Scheduler;

public static class SchedulerService
{
    public static IServiceCollection AddSchedulerService(this IServiceCollection services)
    {
        services.AddHostedService<QuarztHostedService>();
        services.AddSingleton<IJobFactory, CustomeJobFactory>();
        services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
        services.AddSingleton<DailyJob>();
        services.AddSingleton<MonthlyJob>();
        services.AddSingleton(new ScheduledJob(typeof(DailyJob), DailyJob.schedule));
        services.AddSingleton(new ScheduledJob(typeof(MonthlyJob), MonthlyJob.schedule));
        return services;
    }
}
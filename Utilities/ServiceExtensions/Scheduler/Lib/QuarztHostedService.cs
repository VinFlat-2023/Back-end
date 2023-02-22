using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;

namespace Utilities.ServiceExtensions.Scheduler.Lib;

public class QuarztHostedService : IHostedService
{
    private readonly IJobFactory jobFactory;
    private readonly IEnumerable<ScheduledJob> scheduledJobs;
    private readonly ISchedulerFactory schedulerFactory;


    public QuarztHostedService(IJobFactory jobFactory, IEnumerable<ScheduledJob> scheduledJobs,
        ISchedulerFactory schedulerFactory)
    {
        Console.WriteLine("Scheduler Service Started");
        this.jobFactory = jobFactory;
        this.scheduledJobs = scheduledJobs;
        this.schedulerFactory = schedulerFactory;
    }

    public IScheduler Scheduler { get; set; }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Scheduler = await schedulerFactory.GetScheduler(cancellationToken);
        Scheduler.JobFactory = jobFactory;
        foreach (var scheduledJob in scheduledJobs)
        {
            var job = CreateJob(scheduledJob);
            var trigger = CreateTrigger(scheduledJob);
            await Scheduler.ScheduleJob(job, trigger, cancellationToken);
        }

        await Scheduler.Start(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Scheduler.Shutdown(cancellationToken);
    }

    private static IJobDetail CreateJob(ScheduledJob scheduledJob)
    {
        var type = scheduledJob.Type;
        Console.WriteLine($"Create {type.Name} Job");
        return JobBuilder.Create(type)
            .WithIdentity(type.FullName ?? string.Empty)
            .WithDescription(type.Name)
            .Build();
    }

    private static ITrigger CreateTrigger(ScheduledJob scheduledJob)
    {
        var type = scheduledJob.Type;
        Console.WriteLine($"Create {type.Name} Trigger");
        return TriggerBuilder.Create().WithIdentity($"{type.FullName}.trigger")
            .WithCronSchedule(scheduledJob.ScheduleExpression)
            .WithDescription(scheduledJob.ScheduleExpression)
            .Build();
    }
}
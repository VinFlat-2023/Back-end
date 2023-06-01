using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Service.IService;
using Utilities.ServiceExtensions.Scheduler.Lib;

namespace Utilities.ServiceExtensions.Scheduler.Jobs;

public class DailyJob : IJob
{
    public static readonly string schedule = CronScheduleExpression.Daily;
    private readonly ICustomerMailService mailService;


    public DailyJob(IServiceProvider service)
    {
        var scope = service.CreateScope();
        mailService = scope.ServiceProvider.GetRequiredService<IServiceWrapper>().Mails;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await mailService.SendEmailWithDefaultTemplateAsync(
            new[] { "trankhaiminhkhoi@gmail.com", "trankhaiminhkhoi10a3@gmail.com" },
            "Test Daily Job Scheduler",
            $"Email sent at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}",
            null
        );
        await mailService.SendPaymentReminderAsync(0, CancellationToken.None);
        Console.WriteLine($"Daily Task completed at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}");
        //return Task.CompletedTask;
    }
}
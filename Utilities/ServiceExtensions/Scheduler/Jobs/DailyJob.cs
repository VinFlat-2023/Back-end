using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Service.IService;
using Utilities.ServiceExtensions.Scheduler.Lib;

namespace Utilities.ServiceExtensions.Scheduler.Jobs;

public class DailyJob : IJob
{
    public static readonly string schedule = CronScheduleExpression.Daily;
    private readonly ICustomeMailService mailService;


    public DailyJob(IServiceProvider service)
    {
        var scope = service.CreateScope();
        mailService = scope.ServiceProvider.GetRequiredService<IServiceWrapper>().Mails;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        //var receivers = new[]
        //    { "trankhaiminhkhoi@gmail.com", "trankhaiminhkhoi10a3@gmail.com", "tramdbse140878@fpt.edu.vn" };
        //var subject = "Test Daily Scheduler";
        //var content = $"Email sent at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}";
        //IFormFileCollection attachments = null;
        await mailService.SendEmailWithDefaultTemplateAsync(
            new[] { "trankhaiminhkhoi@gmail.com", "trankhaiminhkhoi10a3@gmail.com", "tramdbse140878@fpt.edu.vn" },
            "Test Daily Scheduler",
            $"Email sent at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}",
            null
        );
        await mailService.SendPaymentReminderAsync();
        Console.WriteLine($"Daily Task completed at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}");
        //return Task.CompletedTask;
    }
}
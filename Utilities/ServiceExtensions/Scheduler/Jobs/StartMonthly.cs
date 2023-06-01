using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Service.IService;
using Utilities.ServiceExtensions.Scheduler.Lib;

namespace Utilities.ServiceExtensions.Scheduler.Jobs;

public class StartMonthlyJob : IJob
{
    public static readonly string schedule = CronScheduleExpression.StartMonthly;
    private readonly IInvoiceService invoiceService;
    private readonly ICustomerMailService mailService;

    public StartMonthlyJob(IServiceProvider service)
    {
        var scope = service.CreateScope();
        mailService = scope.ServiceProvider.GetRequiredService<IServiceWrapper>().Mails;
        invoiceService = scope.ServiceProvider.GetRequiredService<IServiceWrapper>().Invoices;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await mailService.SendEmailWithDefaultTemplateAsync(
            new[] { "trankhaiminhkhoi@gmail.com", "trankhaiminhkhoi10a3@gmail.com" },
            "Test Start Monthly Job Scheduler",
            $"Email sent at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}",
            null
        );
        try
        {
            await invoiceService.AutoFinishInvoice();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        await mailService.SendPaymentReminderAsync(0, CancellationToken.None);
        Console.WriteLine($"Monthly Task completed at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}");
        //return Task.CompletedTask;
    }
}
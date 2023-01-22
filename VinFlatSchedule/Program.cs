using System.Reflection;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace VinFlatSchedule;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                using var json = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("VinFlatSchedule.Firebase.firebase_config.json");
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromStream(json)
                });
                services.AddDbContext<ApplicationContext>(
                    options =>
                    {
                        options.UseSqlServer(args.Length > 0
                            ? args[0]
                            : hostContext.Configuration.GetConnectionString("Secret"));
                    }, ServiceLifetime.Transient);
                services.AddMemoryCache();
                services.AddHttpClient();
                // Message queue
            });
    }
}
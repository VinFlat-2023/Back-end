using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Options;
using Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Utilities.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

//AddExpenseHistory odata to api
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(
        new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            ReferenceHandler = ReferenceHandler.Preserve
        }));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var config = builder.Configuration;

builder.Services.AddJwtAuthenticationService(config);

builder.Services.AddApplicationService(config);

builder.Services.AddRegisteredService(config);

builder.Services.ConfigureModelBindingExceptionHandling();

builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 2048;
    options.UseCaseSensitivePaths = true;
});
;

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAnyOrigin", corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .SetIsOriginAllowed(x => _ = true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

/*
using var json = Assembly.GetExecutingAssembly()
    .GetManifestResourceStream("API.Firebase.firebase_config.json");
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromStream(json)
});
*/

builder.Logging.AddLoggerConfig();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerService();

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = 50 * 1024 * 1024;
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // if don't set default value is: 128 MB
    options.MultipartHeadersLengthLimit = 50 * 1024 * 1024;
});

builder.Services.AddAuthorizationService();

builder.Services.AddRedisCacheService(config);

//builder.Services.AddRateLimiting(config);

builder.Services.Configure<PaginationOption>(config.GetSection("Pagination"));

//Add Scheduler service
//builder.Services.AddSchedulerService(builder.Environment);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver =
            new DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling =
            ReferenceLoopHandling.Ignore;
    })
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("AllowAnyOrigin");

app.UseResponseCaching();

/*

app.UseExceptionHandler("/error");

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()?
        .Error;
    var response = new { error = exception?.Message };
    await context.Response.WriteAsJsonAsync(response);
}));

*/

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

//app.UseIpRateLimiting();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

// app.ConfigMiddleware(config);

app.MapControllers();

app.Run();
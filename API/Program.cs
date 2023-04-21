using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Options;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Utilities.MiddlewareExtension;
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

app.UseAuthentication();

app.UseAuthorization();

app.ConfigMiddleware(config);

app.MapControllers();

app.Run();
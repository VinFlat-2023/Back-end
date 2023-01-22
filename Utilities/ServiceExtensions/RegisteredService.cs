using Application.IRepository;
using Application.Repository;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Service.Helper;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Service.Service;
using Service.Validator;

namespace Utilities.ServiceExtensions;

public static class RegisteredService
{
    public static IServiceCollection AddRegisteredService(this IServiceCollection services,
        IConfiguration configuration)
    {
        // RecyclableMemoryStreamManager serviceEntity register 
        services.AddScoped<RecyclableMemoryStreamManager>();

        // wrapper services register
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        // condition and jwt helper
        services.AddScoped<IJwtRoleCheckerHelper, JwtRoleCheckHelper>();
        services.AddScoped<IConditionCheckHelper, ConditionCheckHelper>();

        // add validator service
        services.AddScoped<IAccountValidator, AccountValidator>();
        services.AddScoped<IAreaValidator, AreaValidator>();
        services.AddScoped<IBuildingValidator, BuildingValidator>();
        services.AddScoped<IContractValidator, ContractValidator>();
        services.AddScoped<IFeedbackValidator, FeedbackValidator>();
        services.AddScoped<IFlatValidator, FlatValidator>();
        services.AddScoped<IInvoiceValidator, InvoiceValidator>();
        services.AddScoped<IMajorValidator, MajorValidator>();
        services.AddScoped<IRenterValidator, RenterValidator>();
        services.AddScoped<IRequestValidator, RequestValidator>();
        services.AddScoped<IRoleValidator, RoleValidator>();
        services.AddScoped<IServiceValidator, ServiceValidator>();
        services.AddScoped<IUniversityValidator, UniversityValidator>();

        //Add Mail services
        //Added in ServiceWrapper 

        services.Configure<FormOptions>(o =>
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = int.MaxValue;
            o.MemoryBufferThreshold = int.MaxValue;
        });

        return services;
    }
}
using Domain.ErrorEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("error")]
    public async Task<ControllerErrorResponse> Error([FromServices] IWebHostEnvironment webHostEnvironment)
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;
        var exceptionType = exception?.GetType();

        var code = exception switch
        {
            _ when exceptionType == typeof(BadRequestResult) => 400,
            _ when exceptionType == typeof(UnauthorizedResult) => 401,
            _ when exceptionType == typeof(ForbidResult) => 403,
            _ when exceptionType == typeof(NotFoundResult) => 404,
            _ when exceptionType == typeof(ConflictResult) => 409,
            _ when exceptionType == typeof(UnsupportedMediaTypeResult) => 415,
            _ => 500
        };

        Response.StatusCode = code;

        return await Task.FromResult(new ControllerErrorResponse(exception)); // Your error model
    }
}
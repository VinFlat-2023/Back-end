using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/payment")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IPaymentValidator _validator;

    public PaymentController(IMapper mapper, IServiceWrapper serviceWrapper, IPaymentValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpGet("user/history")]
    [Authorize("Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get payment history list for user")]
    public async Task<IActionResult> GetPaymentHistoryForUser(CancellationToken token)
    {
        return Ok("Not implemented yet");
    }

    [HttpGet("user/history/{invoiceId:int}")]
    [Authorize("Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get a specific payment history for user")]
    public async Task<IActionResult> GetPaymentHistoryForUser(int invoiceId, CancellationToken token)
    {
        // get transaction id from invoice id to proceed to payment history, make sure invoice is paid
        return Ok("Not implemented yet");
    }
}
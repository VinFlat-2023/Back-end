using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/finance")]
[ApiController]
public class FinanceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public FinanceController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Finance
    [HttpGet("building/{buildingId:int}")]
    [Authorize("Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get finance for building")]
    public async Task<IActionResult> GetFinanceForBuilding(int buildingId, CancellationToken token)
    {
        return Ok("Not implemented yet");
    }

    [HttpGet("buildings")]
    [Authorize("Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get finance for all owned buildings")]
    public async Task<IActionResult> GetFinanceForAllBuildings(CancellationToken token)
    {
        return Ok("Not implemented yet");
    }
}
using AutoMapper;
using Domain.CustomEntities.MomoEntities;
using Domain.FilterRequests;
using Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/third-parties")]
[ApiController]
public class ThirdPartyController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMoMoService _momoService;

    public ThirdPartyController(IMoMoService moMoService, IMapper mapper)
    {
        _momoService = moMoService;
        _mapper = mapper;
    }

    [HttpPost("momo")]
    [Authorize]
    [SwaggerOperation(Summary = "Create a request for MoMo payment")]
    public async Task<IActionResult> CreateMomoRequest([FromBody] MomoRequest momoRequest)
    {
        var request = _mapper.Map<MomoEntity>(momoRequest);

        try
        {
            var response = await _momoService.GetMomoResponseEntity(request);

            var result = _mapper.Map<MomoResponse>(response);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Lỗi xử lí, vui lòng thử lại");
        }
    }
}
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Area;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.AreaEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/areas")]
[ApiController]
public class AreasController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IAreaValidator _validator;

    public AreasController(IMapper mapper, IServiceWrapper serviceWrapper,
        IAreaValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Areas
    [HttpGet]
    [SwaggerOperation(Summary = "[Authorize] Get area list (For management and renter))")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetAreas([FromQuery] AreaFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<AreaFilter>(request);

        var list = await _serviceWrapper.Areas.GetAreaList(filter, token);

        var resultList = _mapper.Map<IEnumerable<AreaDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Area list is empty",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "List found",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/Areas/5
    [SwaggerOperation(Summary = "[Authorize] Get area using id (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetArea(int id)
    {
        var entity = await _serviceWrapper.Areas.GetAreaById(id);

        if (entity == null)

            return NotFound(new
            {
                status = "Not Found",
                message = "Area not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Area found",
            data = _mapper.Map<AreaDetailEntity>(entity)
        });
    }

    // PUT: api/Areas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update area info using id (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutArea(int id, [FromBody] AreaUpdateRequest area)
    {
        var updateArea = new Area
        {
            AreaId = id,
            Name = area.Name,
            Location = area.Location
        };

        var validation = await _validator.ValidateParams(updateArea, id);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Areas.UpdateArea(updateArea);

        return result.IsSuccess switch
        {
            true => Ok(new
            {
                status = "Success",
                message = result.Message,
                data = ""
            }),
            false => NotFound(new
            {
                status = "Not Found",
                message = result.Message,
                data = ""
            })
        };
    }


    // POST: api/Areas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create area (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostArea([FromBody] AreaCreateRequest area)
    {
        var newArea = new Area
        {
            Name = area.Name,
            Location = area.Location,
            Status = area.Status
        };

        var validation = await _validator.ValidateParams(newArea, null);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Areas.AddArea(newArea);

        return result.IsSuccess switch
        {
            true => Ok(new
            {
                status = "Success",
                message = result.Message,
                data = ""
            }),
            false => NotFound(new
            {
                status = "Not Found",
                message = result.Message,
                data = ""
            })
        };
    }

    // DELETE: api/Areas/5
    [SwaggerOperation(Summary = "[Authorize] Delete area using id (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteArea(int id)
    {
        var result = await _serviceWrapper.Areas.DeleteArea(id);

        return result.IsSuccess switch
        {
            true => Ok(new
            {
                status = "Success",
                message = result.Message,
                data = ""
            }),
            false => NotFound(new
            {
                status = "Not Found",
                message = result.Message,
                data = ""
            })
        };
    }
}
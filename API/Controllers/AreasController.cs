using AutoMapper;
using Domain.EntitiesDTO.AreaDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Area;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/areas")]
[ApiController]
public class AreasController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IAreaValidator _validator;

    public AreasController(IMapper mapper, IServiceWrapper serviceWrapper, IJwtRoleCheckerHelper jwtRoleCheckHelper,
        IAreaValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Areas
    [HttpGet]
    [SwaggerOperation(Summary = "Get Area List")]
    public async Task<IActionResult> GetAreas([FromQuery] AreaFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<AreaFilter>(request);

        var list = await _serviceWrapper.Areas.GetAreaList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No area available");

        var resultList = _mapper.Map<IEnumerable<AreaDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Area list is not initialized");
    }

    // GET: api/Areas/5
    [SwaggerOperation(Summary = "Get Area")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetArea(int id)
    {
        var entity = await _serviceWrapper.Areas.GetAreaById(id);
        if (entity == null)
            return NotFound("Area not found");
        return Ok(new
        {
            status = "Success",
            message = "Area found",
            data = _mapper.Map<AreaDto>(entity)
        });
    }

    // PUT: api/Areas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Area info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutArea(int id, [FromForm] AreaUpdateRequest area)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateArea = new Area
        {
            AreaId = id,
            Name = area.Name,
            Location = area.Location
        };

        var validation = await _validator.ValidateParams(updateArea, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Areas.UpdateArea(updateArea);
        if (result == null)
            return NotFound("Area not found");

        return Ok("Area updated successfully");
    }

    // POST: api/Areas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Area")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostArea([FromForm] AreaCreateRequest area)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newArea = new Area
        {
            Name = area.Name,
            Location = area.Location,
            Status = area.Status
        };

        var validation = await _validator.ValidateParams(newArea, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Areas.AddArea(newArea);
        if (result == null)
            return NotFound("Area failed to create");

        return CreatedAtAction("GetArea", new { id = result.AreaId }, result);
    }

    // DELETE: api/Areas/5
    [SwaggerOperation(Summary = "[Authorize] Delete Area")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteArea(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Areas.DeleteArea(id);
        if (!result)
            return NotFound("Area not found");

        return Ok("Area deleted successfully");
    }
}
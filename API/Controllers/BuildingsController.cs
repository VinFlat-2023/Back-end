using AutoMapper;
using Domain.EntitiesDTO.BuildingDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Building;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/buildings")]
[ApiController]
public class BuildingsController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IBuildingValidator _validator;

    public BuildingsController(IMapper mapper, IServiceWrapper serviceWrapper, IJwtRoleCheckerHelper jwtRoleCheckHelper,
        IBuildingValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Buildings
    [SwaggerOperation(Summary = "Get Building List")]
    [HttpGet]
    public async Task<IActionResult> GetBuildings([FromQuery] BuildingFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<BuildingFilter>(request);

        var list = await _serviceWrapper.Buildings.GetBuildingList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No building available");

        var resultList = _mapper.Map<IEnumerable<BuildingDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Building list is not initialized");
    }

    // GET: api/Buildings/5
    [SwaggerOperation(Summary = "Get Building")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBuilding(int id)
    {
        var entity = await _serviceWrapper.Buildings.GetBuildingById(id);
        if (entity == null)
            return NotFound("Building not found");
        return Ok(new
        {
            status = "Success",
            message = "Building found",
            data = _mapper.Map<BuildingDto>(entity)
        });
    }

    // PUT: api/Buildings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Building info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBuilding(int id, [FromForm] BuildingUpdateRequest building)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        if (id != building.BuildingId)
            return BadRequest("Building id does not match");

        var updateBuilding = new Building
        {
            BuildingId = id,
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            TotalFloor = building.TotalFloor ?? 0,
            TotalRooms = building.TotalRooms ?? 0,
            AreaId = building.AreaId
        };

        var validation = await _validator.ValidateParams(updateBuilding, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Buildings.UpdateBuilding(updateBuilding);

        if (result == null)
            return NotFound("Building not found");

        return Ok(new
        {
            status = "Success",
            message = "Update building successfully",
            data = ""
        });
    }

    // POST: api/Buildings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Building")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostBuilding([FromForm] BuildingCreateRequest building)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newBuilding = new Building
        {
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            TotalFloor = building.TotalFloor ?? 0,
            TotalRooms = building.TotalRooms ?? 0,
            Status = building.Status,
            AreaId = building.AreaId
        };

        var validation = await _validator.ValidateParams(newBuilding, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Buildings.AddBuilding(newBuilding);
        if (result == null)
            return NotFound("Create new building failed");

        return CreatedAtAction("GetBuilding", new { id = result.BuildingId }, result);
    }

    // DELETE: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Remove Building")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Buildings.DeleteBuilding(id);

        return !result
            ? NotFound("Building not found")
            : Ok(
                new
                {
                    status = "Success",
                    message = "Building deleted",
                    data = ""
                });
    }
}
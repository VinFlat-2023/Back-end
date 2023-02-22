using AutoMapper;
using Domain.EntitiesDTO.BuildingDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Building;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/buildings")]
[ApiController]
public class BuildingsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IBuildingValidator _validator;

    public BuildingsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IBuildingValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
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
            return NotFound(new
            {
                status = "Not Found",
                message = "Building list is empty",
                data = ""
            });
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
            : BadRequest("Building list is empty");
    }

    // GET: api/Buildings/5
    [SwaggerOperation(Summary = "Get Building")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBuilding(int id)
    {
        var entity = await _serviceWrapper.Buildings.GetBuildingById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });
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
        var updateBuilding = new Building
        {
            BuildingId = id,
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            AreaId = building.AreaId
        };

        var validation = await _validator.ValidateParams(updateBuilding, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Buildings.UpdateBuilding(updateBuilding);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Building failed to update",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Building updated",
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
        var newBuilding = new Building
        {
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            TotalRooms = 0,
            AccountId = Convert.ToInt32(User.Identity?.Name),
            Status = building.Status,
            AreaId = building.AreaId
        };

        var validation = await _validator.ValidateParams(newBuilding, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Buildings.AddBuilding(newBuilding);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Building failed to create",
                data = ""
            });

        return CreatedAtAction("GetBuilding", new { id = result.BuildingId }, result);
    }

    // DELETE: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Remove Building")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        var result = await _serviceWrapper.Buildings.DeleteBuilding(id);

        return !result
            ? NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            })
            : Ok(
                new
                {
                    status = "Success",
                    message = "Building deleted",
                    data = ""
                });
    }
}
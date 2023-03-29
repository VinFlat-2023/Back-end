using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Building;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.BuildingEntity;
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
    [SwaggerOperation(Summary = "[Authorize] Get building list (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet]
    public async Task<IActionResult> GetBuildings([FromQuery] BuildingFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<BuildingFilter>(request);

        var list = await _serviceWrapper.Buildings.GetBuildingList(filter, token);

        var resultList = _mapper.Map<IEnumerable<BuildingDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Building list is empty",
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

    // GET: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Get building info (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
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
            data = _mapper.Map<BuildingDetailEntity>(entity)
        });
    }

    // PUT: api/Buildings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Building info (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBuilding(int id, [FromBody] BuildingUpdateRequest building)
    {
        var updateBuilding = new Building
        {
            BuildingId = id,
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            AreaId = building.AreaId,
            Status = building.Status,
            BuildingPhoneNumber = building.BuildingPhoneNumber
            // ImageUrl = building.ImageUrl
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

    // POST: api/Buildings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create building (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostBuilding([FromBody] BuildingCreateRequest building)
    {
        var newBuilding = new Building
        {
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            TotalRooms = 0,
            AccountId = Convert.ToInt32(User.Identity?.Name),
            Status = building.Status ?? true,
            AreaId = building.AreaId,
            BuildingPhoneNumber = building.BuildingPhoneNumber
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

        return Ok(new
        {
            status = "Success",
            message = "Building created",
            data = ""
        });
    }

    // DELETE: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Remove building (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        var result = await _serviceWrapper.Buildings.DeleteBuilding(id);

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
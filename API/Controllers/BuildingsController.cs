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
    [SwaggerOperation(Summary = "[Authorize] Get building list using query")]
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

    [SwaggerOperation(Summary = "[Authorize] Get current building (For management (Supervisor only)")]
    [Authorize(Roles = "Supervisor")]
    [HttpGet("current")]
    public async Task<IActionResult> GetBuildingBasedOnSupervisor(CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Supervisor has no building",
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Supervisor has more than 1 building",
                    data = ""
                });
        }

        var entity = await _serviceWrapper.Buildings.GetBuildingById(buildingId);

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

    // GET: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Get building info (For management and renter)")]
    [Authorize(Roles = "Admin")]
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
        var validation = await _validator.ValidateParams(building, id);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateBuilding = new Building
        {
            BuildingId = id,
            BuildingName = building.BuildingName,
            BuildingAddress = building.BuildingAddress,
            Description = building.Description,
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            BuildingPhoneNumber = building.BuildingPhoneNumber,
            AveragePrice = building.AveragePrice ?? 0,
            Status = building.Status,
            AreaId = building.AreaId
        };

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
    [Authorize(Roles = "Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostBuilding([FromBody] BuildingCreateRequest building)
    {
        var employeeId = int.Parse(User.Identity.Name);

        var supervisor = await _serviceWrapper.Employees.GetEmployeeById(employeeId);

        if (supervisor == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Supervisor not found",
                data = ""
            });

        var validation = await _validator.ValidateParams(building);

        var newBuilding = new Building
        {
            BuildingName = building.BuildingName ?? "Building created by " + supervisor.FullName,
            BuildingAddress = building.BuildingAddress ?? "To be filled",
            Description = building.Description ?? "Building description",
            CoordinateX = building.CoordinateX ?? 0,
            CoordinateY = building.CoordinateY ?? 0,
            TotalFlats = 0,
            AveragePrice = building.AveragePrice ?? 0,
            EmployeeId = employeeId,
            Status = building.Status ?? true,
            AreaId = building.AreaId,
            BuildingPhoneNumber = building.BuildingPhoneNumber ?? "0"
        };

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Buildings.AddBuilding(newBuilding);

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

    // DELETE: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Remove building (For management)")]
    [Authorize(Roles = "Admin")]
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
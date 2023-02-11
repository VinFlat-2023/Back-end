using AutoMapper;
using Domain.EntitiesDTO.FlatDTO;
using Domain.EntitiesDTO.FlatTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/flats")]
[ApiController]
public class FlatsController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IFlatValidator _validator;

    // GET: api/Flats
    public FlatsController(IMapper mapper, IServiceWrapper serviceWrapper, IJwtRoleCheckerHelper jwtRoleCheckHelper,
        IFlatValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "[Authorize] Get Flat list by filter")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFlats([FromQuery] FlatFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<FlatFilter>(request);
        var list = await _serviceWrapper.Flats.GetFlatList(filter, token);
        if (list != null && !list.Any())
            return NotFound("Flat list is empty!");

        var resultList = _mapper.Map<IEnumerable<FlatDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Flat list is not initialized");
    }

    // GET: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Get Flat")]
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFlat(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Flats.GetFlatById(id);
        if (entity == null)
            return NotFound("Flat not found");
        return Ok(
            new
            {
                status = "Success",
                message = "Flat found",
                data = _mapper.Map<FlatDto>(entity)
            });
    }

    // PUT: api/Flats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Flat info")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> PutFlat(int id, [FromForm] FlatUpdateRequest flat)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateFlat = new Flat
        {
            FlatId = id,
            Name = flat.Name,
            Description = flat.Description ?? "No description",
            Status = flat.Status,
            WaterMeter = flat.WaterMeter ?? 0,
            ElectricityMeter = flat.ElectricityMeter ?? 0,
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };

        var validation = await _validator.ValidateParams(updateFlat, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Flats.UpdateFlat(updateFlat);
        if (result == null)
            return NotFound("Flat not found");

        return Ok("Flat updated");
    }

    // POST: api/Flats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Flat")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostFlat([FromForm] FlatCreateRequest flat)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newFlat = new Flat
        {
            Name = flat.Name,
            Description = flat.Description ?? "No description",
            Status = flat.Status,
            WaterMeter = flat.WaterMeter ?? 0,
            ElectricityMeter = flat.ElectricityMeter ?? 0,
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };

        var validation = await _validator.ValidateParams(newFlat, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Flats.AddFlat(newFlat);
        if (result == null)
            return NotFound("Flat not found");
        return CreatedAtAction("GetFlat", new { id = result.FlatId }, result);
    }

    // DELETE: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Remove Flat")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFlat(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Flats.DeleteFlat(id);
        if (!result)
            return NotFound("Flat not found");
        return Ok("Flat deleted");
    }

    [SwaggerOperation(Summary = "[Authorize] Get Flat Type List")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("type")]
    public async Task<IActionResult> GetFlatTypes([FromQuery] FlatTypeFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<FlatTypeFilter>(request);
        var list = await _serviceWrapper.FlatTypes.GetFlatTypeList(filter, token);
        if (list != null && !list.Any())
            return NotFound("Flat type list is empty!");

        var resultList = _mapper.Map<IEnumerable<FlatTypeDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Flat type list is not initialized");
    }

    // GET: api/FlatTypes/5
    [SwaggerOperation(Summary = "[Authorize] Get Flat Type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("type/{id:int}")]
    public async Task<IActionResult> GetFlatType(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.FlatTypes.GetFlatTypeById(id);
        return entity == null
            ? NotFound("No flat type found")
            : Ok(new
            {
                status = "Success",
                message = "Flat type found",
                data = _mapper.Map<FlatTypeDto>(entity)
            });
    }

    // PUT: api/FlatTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Flat Type info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("type/{id:int}")]
    public async Task<IActionResult> PutFlatType(int id, [FromForm] FlatTypeUpdateRequest flatType)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        if (id != flatType.FlatTypeId)
            return BadRequest("Id mismatch");
        var updateFlatType = new FlatType
        {
            FlatTypeId = id,
            RoomCapacity = flatType.Capacity,
            Status = flatType.Status
        };

        var validation = await _validator.ValidateParams(updateFlatType, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.FlatTypes.UpdateFlatType(updateFlatType);
        if (result == null)
            return NotFound("Flat type not found");
        return Ok("Flat type updated");
    }

    // POST: api/FlatTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Flat Type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost("type")]
    public async Task<IActionResult> PostFlatType([FromForm] FlatTypeCreateRequest flatType)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newFlatType = new FlatType
        {
            RoomCapacity = flatType.Capacity,
            Status = flatType.Status
        };

        var validation = await _validator.ValidateParams(newFlatType, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.FlatTypes.AddFlatType(newFlatType);
        if (result == null)
            return NotFound("Flat type not found");

        return CreatedAtAction("GetFlatType", new { id = result.FlatTypeId }, result);
    }

    // DELETE: api/FlatTypes/5
    [SwaggerOperation(Summary = "Remove Flat Type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("type/{id:int}")]
    public async Task<IActionResult> DeleteFlatType(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.FlatTypes.DeleteFlatType(id);
        if (!result)
            return NotFound("FlatType not found");

        return Ok("FlatType deleted");
    }

    [SwaggerOperation(Summary = "Check total available room")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("room/{id:int}/slot-available")]
    public async Task<IActionResult> GetTotalAvailableRoom(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Flats.GetFlatById(id);
        return result == null
            ? NotFound("Flat not found")
            : Ok(new
            {
                status = "Success",
                message = "Flat found",
                data = result.Rooms
                    .Count(x => x.RoomType.NumberOfSlotsAvailable >= 1)
            });
    }
}
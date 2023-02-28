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
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/flats")]
[ApiController]
public class FlatsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IFlatValidator _validator;

    // GET: api/Flats
    public FlatsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IFlatValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "[Authorize] Get Flat list by filter")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFlats([FromQuery] FlatFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<FlatFilter>(request);
        var list = await _serviceWrapper.Flats.GetFlatList(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat list is empty",
                data = ""
            });

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
            : NotFound(new
            {
                status = "Not Found",
                message = "Flat list is empty",
                data = ""
            });
    }

    // GET: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Get Flat")]
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFlat(int id)
    {
        var entity = await _serviceWrapper.Flats.GetFlatById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat not found",
                data = ""
            });
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
    public async Task<IActionResult> PutFlat(int id, [FromBody] FlatUpdateRequest flat)
    {
        var updateFlat = new Flat
        {
            FlatId = id,
            Name = flat.Name,
            Description = flat.Description ?? "No description",
            Status = flat.Status,
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };

        var validation = await _validator.ValidateParams(updateFlat, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Flats.UpdateFlat(updateFlat);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Flat updated",
            data = ""
        });
    }

    // POST: api/Flats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Flat")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostFlat([FromBody] FlatCreateRequest flat)
    {
        var newFlat = new Flat
        {
            Name = flat.Name,
            Description = flat.Description ?? "No description",
            Status = flat.Status,
            WaterMeterBefore = 0,
            ElectricityMeterBefore = 0,
            WaterMeterAfter = 0,
            ElectricityMeterAfter = 0,
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };

        var validation = await _validator.ValidateParams(newFlat, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Flats.AddFlat(newFlat);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Flat failed to create",
                data = ""
            });
        return CreatedAtAction("GetFlat", new { id = result.FlatId }, result);
    }

    // DELETE: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Remove Flat")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFlat(int id)
    {
        var result = await _serviceWrapper.Flats.DeleteFlat(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat failed to create",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Flat deleted",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Flat Type List")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("type")]
    public async Task<IActionResult> GetFlatTypes([FromQuery] FlatTypeFilterRequest request, CancellationToken token)
    {
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
            : BadRequest(new
            {
                status = "Bad Request",
                message = "Flat type list is empty",
                data = ""
            });
    }

    // GET: api/FlatTypes/5
    [SwaggerOperation(Summary = "[Authorize] Get Flat Type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("type/{id:int}")]
    public async Task<IActionResult> GetFlatType(int id)
    {
        var entity = await _serviceWrapper.FlatTypes.GetFlatTypeById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Flat type not found",
                data = ""
            })
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
    public async Task<IActionResult> PutFlatType(int id, [FromBody] FlatTypeUpdateRequest flatType)
    {
        var updateFlatType = new FlatType
        {
            FlatTypeId = id,
            RoomCapacity = flatType.RoomCapacity,
            Status = flatType.Status
        };

        var validation = await _validator.ValidateParams(updateFlatType, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.FlatTypes.UpdateFlatType(updateFlatType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat type not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Flat type updated",
            data = ""
        });
    }

    // POST: api/FlatTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Flat Type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost("type")]
    public async Task<IActionResult> PostFlatType([FromBody] FlatTypeCreateRequest flatType)
    {
        var newFlatType = new FlatType
        {
            RoomCapacity = flatType.RoomCapacity,
            Status = flatType.Status
        };

        var validation = await _validator.ValidateParams(newFlatType, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.FlatTypes.AddFlatType(newFlatType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat type not found",
                data = ""
            });
        return CreatedAtAction("GetFlatType", new { id = result.FlatTypeId }, result);
    }

    // DELETE: api/FlatTypes/5
    [SwaggerOperation(Summary = "Remove Flat Type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("type/{id:int}")]
    public async Task<IActionResult> DeleteFlatType(int id)
    {
        var result = await _serviceWrapper.FlatTypes.DeleteFlatType(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat type not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Flat type deleted",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "Check total available slots")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("room/{id:int}/slot-available")]
    public async Task<IActionResult> GetTotalAvailableRoom(int id)
    {
        var result = await _serviceWrapper.Flats.GetFlatById(id);

        return result switch
        {
            null => NotFound(new { status = "Not Found", message = "Flat not found", data = "" }),
            { } when result.Rooms.Any(x => x.AvailableSlots == 0) => Ok(new
            {
                status = "Success", message = "This flat is not available", data = ""
            }),
            { } when result.Rooms.Any(x => x.AvailableSlots >= 1) => Ok(new
            {
                status = "Success", message = "This flat is still available", data = ""
            }),
            _ => BadRequest(new { status = "Success", message = "Flat service is unavailable", data = "" })
        };
    }

    [SwaggerOperation(Summary = "Move a renter in inside available slot in a room (Not yet finished)")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost("{flatId:int}/room/{roomId:int}/slots")]
    public async Task<IActionResult> MoveNewRenterIn(int flatId, int roomId, int renterId, CancellationToken token)
    {
        var entity = await _serviceWrapper.Flats.GetFlatById(flatId);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Renter moved in",
            data = ""
        });
    }
}
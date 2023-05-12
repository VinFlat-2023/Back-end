using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.FlatTypeEntity;
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
    [SwaggerOperation(Summary = "[Authorize] Get flat list by filter request (For management)")]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> GetFlats([FromQuery] FlatFilterRequest request, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var filter = _mapper.Map<FlatFilter>(request);

        var list = await _serviceWrapper.Flats.GetFlatList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<FlatDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách căn hộ hiện đang trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Get flat (For management and renter)")]
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> GetFlat(int id, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var entity = await _serviceWrapper.Flats.GetFlatById(id, buildingId, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Căn hộ này không tồn tại",
                data = ""
            });
        return Ok(
            new
            {
                status = "Success",
                message = "Căn hộ đã được tìm thấy",
                data = _mapper.Map<FlatDetailEntity>(entity)
            });
    }

    // PUT: api/Flats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update flat info (For management)")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> PutFlat(int id, [FromBody] FlatUpdateRequest request, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                    data = ""
                });
            case -1:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Người quản lý không quản lý tòa nhà nào",
                    data = ""
                });
        }

        var validation = await _validator.ValidateParams(request, id, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateFlat = new Flat
        {
            FlatId = id,
            Name = request.Name,
            Description = request.Description ?? "No description",
            Status = request.Status,
            FlatTypeId = request.FlatTypeId,
            BuildingId = request.BuildingId,
            FlatImageUrl1 = request.ImageUrl,
            FlatImageUrl2 = request.ImageUrl2,
            FlatImageUrl3 = request.ImageUrl3,
            FlatImageUrl4 = request.ImageUrl4,
            FlatImageUrl5 = request.ImageUrl5,
            FlatImageUrl6 = request.ImageUrl6
        };

        var result = await _serviceWrapper.Flats.UpdateFlat(updateFlat);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = "Renter failed to update",
                data = ""
            }),
            true => Ok(
                new
                {
                    status = "Success",
                    message = "Renter updated",
                    data = ""
                })
        };
    }

    // POST: api/Flats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create flat (For management)")]
    [Authorize(Roles = "Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostFlat([FromBody] FlatCreateRequest flat, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var validation = await _validator.ValidateParams(flat, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        foreach (var roomId in flat.RoomIds)
        {
        }


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
            BuildingId = buildingId,
            FlatImageUrl1 = flat.FlatImageUrl1,
            FlatImageUrl2 = flat.FlatImageUrl2,
            FlatImageUrl3 = flat.FlatImageUrl3,
            FlatImageUrl4 = flat.FlatImageUrl4,
            FlatImageUrl5 = flat.FlatImageUrl5,
            FlatImageUrl6 = flat.FlatImageUrl6
        };

        var flatType = await _serviceWrapper.FlatTypes.GetFlatTypeById(flat.FlatTypeId, buildingId, token);

        newFlat.MaxRoom = flatType?.RoomCapacity ?? 1;
        newFlat.AvailableRoom = flatType?.RoomCapacity ?? 1;

        var totalRooms = newFlat.MaxRoom;

        ICollection<Room> Rooms = new List<Room>();

        for (var i = 0; i < totalRooms; i++)
        {
        }

        var result = await _serviceWrapper.Flats.AddFlat(newFlat);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tạo căn hộ thất bại",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Tạo căn hộ thành công",
            data = _mapper.Map<FlatDetailEntity>(result)
        });
    }

    // DELETE: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Remove flat (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFlat(int id)
    {
        var result = await _serviceWrapper.Flats.DeleteFlat(id);

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

    [SwaggerOperation(Summary = "[Authorize] Get flat type list by filter request (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("type")]
    public async Task<IActionResult> GetFlatTypes([FromQuery] FlatTypeFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<FlatTypeFilter>(request);

        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var list = await _serviceWrapper.FlatTypes.GetFlatTypeList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<FlatTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Flat type list is empty",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/FlatTypes/5
    [SwaggerOperation(Summary = "[Authorize] Get flat type by id (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("type/{id:int}")]
    public async Task<IActionResult> GetFlatType(int id, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var entity = await _serviceWrapper.FlatTypes.GetFlatTypeById(id, buildingId, token);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Loại căn hộ không tìm thấy",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Flat type found",
                data = _mapper.Map<FlatTypeDetailEntity>(entity)
            });
    }

    // PUT: api/FlatTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update flat type info (For management)")]
    [Authorize(Roles = " Admin, Supervisor")]
    [HttpPut("type/{id:int}")]
    public async Task<IActionResult> PutFlatType(int id, [FromBody] FlatTypeUpdateRequest flatType,
        CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                    data = ""
                });
            case -1:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Người quản lý không quản lý tòa nhà nào",
                    data = ""
                });
        }

        var validation = await _validator.ValidateParams(flatType, id, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateFlatType = new FlatType
        {
            FlatTypeId = id,
            FlatTypeName = flatType.FlatTypeName,
            RoomCapacity = flatType.RoomCapacity,
            Status = flatType.Status
        };

        var result = await _serviceWrapper.FlatTypes.UpdateFlatType(updateFlatType);

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

    [SwaggerOperation(Summary = "[Authorize] Toggle flat type status (For management)")]
    [Authorize(Roles = "Supervisor")]
    [HttpPut("type/{id:int}/toggle-status")]
    public async Task<IActionResult> PutFlatType(int id, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var flatTypeCheck = await _serviceWrapper.FlatTypes.GetFlatTypeById(id, buildingId, token);

        if (flatTypeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy loại căn hộ này",
                data = ""
            });

        var result = await _serviceWrapper.FlatTypes.ToggleStatus(id);

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

    // POST: api/FlatTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create flat type (For management)")]
    [Authorize(Roles = "Supervisor")]
    [HttpPost("type")]
    public async Task<IActionResult> PostFlatType([FromBody] FlatTypeCreateRequest flatType, CancellationToken token)
    {
        var userId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = -1
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var validation = await _validator.ValidateParams(flatType, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newFlatType = new FlatType
        {
            FlatTypeName = flatType.FlatTypeName,
            RoomCapacity = flatType.RoomCapacity,
            Status = flatType.Status,
            BuildingId = buildingId
        };

        var result = await _serviceWrapper.FlatTypes.AddFlatType(newFlatType);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Loại căn hộ không tìm thấy",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Flat type created",
            data = ""
        });
    }

    // DELETE: api/FlatTypes/5
    [SwaggerOperation(Summary = "[Authorize] Remove flat type (For management)")]
    [Authorize(Roles = " Admin, Supervisor")]
    [HttpDelete("type/{id:int}")]
    public async Task<IActionResult> DeleteFlatType(int id)
    {
        var result = await _serviceWrapper.FlatTypes.DeleteFlatType(id);
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

    [SwaggerOperation(Summary = "[Authorize] Check total available slots in a flat (For management)")]
    [Authorize(Roles = " Admin, Supervisor")]
    [HttpDelete("room/{id:int}/slot-available")]
    public async Task<IActionResult> GetTotalAvailableRoom(int id, CancellationToken token)
    {
        var result = await _serviceWrapper.Flats.GetRoomInAFlat(id, token);

        return result.IsSuccess switch
        {
            true => Ok(new { status = "Success", message = result.Message, data = "" }),
            false => BadRequest(new { status = "Bad Request", message = result.Message, data = "" })
        };
    }
}
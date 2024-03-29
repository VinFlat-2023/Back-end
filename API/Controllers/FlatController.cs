﻿using AutoMapper;
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
public class FlatController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IFlatValidator _validator;

    // GET: api/Flats
    public FlatController(IMapper mapper, IServiceWrapper serviceWrapper,
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
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

    [HttpGet("type/active")]
    [SwaggerOperation(Summary = "[Authorize] Get flat type list by filter request (For management)")]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> GetFlatTypeActiveInBuilding(CancellationToken token)
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
                });
        }

        var list = await _serviceWrapper.FlatTypes.GetFlatTypeList(buildingId, token);

        var resultList = _mapper.Map<IEnumerable<FlatTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách loại căn hộ hiện đang trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList
        });
    }

    [HttpGet("active")]
    [SwaggerOperation(Summary = "[Authorize] Get flat list by filter request (For management)")]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> GetFlatActiveInBuilding(CancellationToken token)
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
                });
        }

        var list = await _serviceWrapper.Flats.GetFlatList(buildingId, token);

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
            data = resultList
        });
    }


    // GET: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Get flat (For management)")]
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
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

        var result = _mapper.Map<FlatDetailEntity>(entity);

        return Ok(
            new
            {
                status = "Success",
                message = "Căn hộ đã được tìm thấy",
                data = result
            });
    }

    // PUT: api/Flats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update flat info (For management)")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Supervisor")]
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
            false => BadRequest(
                new
                {
                    status = "Bad Request",
                    message = result.Message,
                    data = ""
                }),
            true => Ok(
                new
                {
                    status = "Success",
                    message = result.Message,
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
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

        var newFlat = new Flat
        {
            Name = flat.Name,
            Description = flat.Description ?? "No description",
            Status = flat.Status ?? "Active",
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

        if (flatType == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Loại căn hộ này không tồn tại",
                data = ""
            });

        newFlat.MaxRoom = flatType.RoomCapacity;
        newFlat.AvailableRoom = flatType.RoomCapacity;

        var flatMaxRoom = newFlat.MaxRoom;

        var totalRoomCreatedTypeInRequest = flat.RoomTypeId.Count;

        if (totalRoomCreatedTypeInRequest > flatMaxRoom)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tổng số phòng không được quá giới hạn của loại căn hộ",
                data = ""
            });

        if (totalRoomCreatedTypeInRequest < flatMaxRoom)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tổng số phòng không được nhỏ hơn giới hạn của loại căn hộ",
                data = ""
            });

        var result = await _serviceWrapper.Flats.AddFlat(newFlat, flat.RoomTypeId, token);

        return result.IsSuccess switch
        {
            true => Ok(new
            {
                status = "Success",
                message = result.Message,
                data = ""
            }),
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            })
        };
    }

    // DELETE: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Remove flat (For management)")]
    [Authorize(Roles = "Supervisor")]
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

    [SwaggerOperation(Summary = "[Authorize] Get flat type list by filter request (For management)")]
    [Authorize(Roles = "Supervisor")]
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
                });
        }

        var list = await _serviceWrapper.FlatTypes.GetFlatTypeList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<FlatTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách loại căn hộ hiện đang trống",
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
    [Authorize(Roles = "Supervisor, Renter")]
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
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
                message = "Hiện thị thông tin loại căn hộ",
                data = _mapper.Map<FlatTypeDetailEntity>(entity)
            });
    }

    // PUT: api/FlatTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update flat type info (For management)")]
    [Authorize(Roles = "Supervisor")]
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
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
            message = "Tạo loại căn hộ thành công",
            data = ""
        });
    }

    // DELETE: api/FlatTypes/5
    [SwaggerOperation(Summary = "[Authorize] Remove flat type (For management)")]
    [Authorize(Roles = "Supervisor")]
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
    [Authorize(Roles = "Supervisor")]
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
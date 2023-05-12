using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.RoomType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.RoomTypeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/building/room-type")]
[ApiController]
public class RoomTypeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IRoomTypeValidator _validator;

    public RoomTypeController(IMapper mapper, IServiceWrapper serviceWrapper, IRoomTypeValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpGet]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get all room types in building(s) managed by supervisor Id")]
    public async Task<IActionResult> GetAllRoomTypes([FromQuery] RoomTypeFilterRequest request, CancellationToken token)
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

        var filter = _mapper.Map<RoomTypeFilter>(request);

        var list = await _serviceWrapper.RoomTypes.GetRoomTypeList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<RoomTypeBasicDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách phòng trống",
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

    [HttpGet("{roomTypeId:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get room types in building managed by supervisor")]
    public async Task<IActionResult> GetSpecificRoomType(int roomTypeId, CancellationToken token)
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

        var room = await _serviceWrapper.RoomTypes.GetRoomTypeById(roomTypeId, buildingId, token);

        if (room == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy phòng",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị thông tin phòng",
            data = _mapper.Map<RoomTypeBasicDetailEntity>(room)
        });
    }

    [HttpPost]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Add room types in building(s) managed by supervisor Id")]
    public async Task<IActionResult> CreateRoomType(RoomTypeCreateRequest request, CancellationToken token)
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

        var validation = await _validator.ValidateParams(request, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var addRoom = new RoomType
        {
            RoomTypeName = request.RoomTypeName,
            TotalSlot = request.TotalSlot,
            BuildingId = buildingId,
            Status = request.Status ?? "Active"
        };

        var result = await _serviceWrapper.RoomTypes.AddRoomType(addRoom);

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

    [HttpPut("{roomTypeId:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Update room types in building(s) managed by supervisor Id")]
    public async Task<IActionResult> UpdateRoomType(int roomTypeId, RoomTypeUpdateRequest request,
        CancellationToken token)
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

        var validation = await _validator.ValidateParams(request, roomTypeId, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateRoom = new RoomType
        {
            RoomTypeId = roomTypeId,
            RoomTypeName = request.RoomTypeName,
            TotalSlot = request.TotalSlot,
            BuildingId = buildingId,
            Status = request.Status
        };

        var result = await _serviceWrapper.RoomTypes.UpdateRoomType(updateRoom, buildingId, token);

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

    /*
    [HttpGet("{roomId:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get rooms in building managed by supervisor")]
    public async Task<IActionResult> GetRoomBasedOnId(int roomId, CancellationToken token)
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

        var room = await _serviceWrapper.Rooms.GetRoomById(roomId, buildingId, token);
        if (room == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy phòng",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Hiển thị thông tin phòng",
            data = _mapper.Map<RoomBasicDetailEntity>(room)
        });
    }
    */
}
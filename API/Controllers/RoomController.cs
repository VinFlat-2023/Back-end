using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Room;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.RoomEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/building/room")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IRoomValidator _validator;

    public RoomController(IMapper mapper, IServiceWrapper serviceWrapper, IRoomValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpPut("{roomId}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Update room from a flat in building managed by supervisor")]
    public async Task<IActionResult> UpdateRoomInAFlat(int roomId, RoomUpdateRequest request, CancellationToken token)
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

        var roomCheck = await _serviceWrapper.Rooms.GetRoomById(roomId, buildingId, token);

        if (roomCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Phòng không tồn tại",
                data = ""
            });

        var updateRoom = new Room
        {
            RoomId = roomId,
            RoomName = request.RoomName,
            ElectricityAttribute = request.ElectricityAttribute,
            WaterAttribute = request.WaterAttribute,
            Status = request.Status,
            RoomTypeId = request.RoomTypeId,
            FlatId = request.FlatId,
            RoomImageUrl1 = request.RoomImageUrl1 ?? roomCheck.RoomImageUrl1,
            RoomImageUrl2 = request.RoomImageUrl2 ?? roomCheck.RoomImageUrl2,
            RoomImageUrl3 = request.RoomImageUrl3 ?? roomCheck.RoomImageUrl3,
            RoomImageUrl4 = request.RoomImageUrl4 ?? roomCheck.RoomImageUrl4,
            RoomImageUrl5 = request.RoomImageUrl5 ?? roomCheck.RoomImageUrl5,
            RoomImageUrl6 = request.RoomImageUrl6 ?? roomCheck.RoomImageUrl6
        };

        var roomTypeCheck = await _serviceWrapper.RoomTypes.GetRoomTypeById(roomCheck.RoomTypeId, buildingId, token);

        if (roomTypeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Loại phòng không tồn tại",
                data = ""
            });

        switch (roomTypeCheck.Status.ToLower())
        {
            case "inactive":
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Loại phòng đang không hoạt động",
                    data = ""
                });
            case "maintenance":
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Loại phòng đang bảo trì",
                    data = ""
                });
        }

        if (roomCheck.AvailableSlots == roomTypeCheck.TotalSlot
            && request.Status.ToLower() == "active")
        {
            updateRoom.RoomTypeId = request.RoomTypeId;
            updateRoom.FlatId = roomCheck.FlatId;
        }

        if (roomCheck.AvailableSlots == roomTypeCheck.TotalSlot
            && request.Status.ToLower() == "maintenance")
        {
            updateRoom.RoomTypeId = request.RoomTypeId;
            updateRoom.FlatId = roomCheck.FlatId;
        }

        if (roomCheck.AvailableSlots == roomTypeCheck.TotalSlot
            && request.Status.ToLower() == "inactive")
        {
            updateRoom.FlatId = request.FlatId;
            updateRoom.RoomTypeId = request.RoomTypeId;
        }

        if (request.Status.ToLower() == "active" && request.RoomTypeId != roomTypeCheck.RoomTypeId)
            if (roomCheck.AvailableSlots != roomTypeCheck.TotalSlot)
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Phòng đang có người ở, không thể cập nhật loại phòng",
                    data = ""
                });

        if (request.Status.ToLower() != "active")
        {
            if (roomCheck.AvailableSlots != roomTypeCheck.TotalSlot)
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Phòng đang có người ở, không thể cập nhật trạng thái của phòng",
                    data = ""
                });
            if (request.RoomTypeId != roomTypeCheck.RoomTypeId && roomCheck.AvailableSlots != roomTypeCheck.TotalSlot)
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Phòng đang có người ở, không thể cập nhật loại phòng cùa căn hộ",
                    data = ""
                });
            if (request.FlatId != roomCheck.FlatId && roomCheck.AvailableSlots != roomTypeCheck.TotalSlot)
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Phòng đang có người ở, không thể cập nhật căn hộ của phòng",
                    data = ""
                });
        }

        var result = await _serviceWrapper.Rooms.UpdateRoom(updateRoom, buildingId, token);

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

        //var validationResult = await _validator.ValidateAsync(updateRoom, token);
    }

    [HttpGet]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get all rooms in building(s)")]
    public async Task<IActionResult> GetAllRooms([FromQuery] RoomFilterRequest request, CancellationToken token)
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

        var filter = _mapper.Map<RoomFilter>(request);

        var list = await _serviceWrapper.Rooms.GetRoomList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<RoomDetailEntity>>(list);

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

    [HttpGet("flat/{flatId:int}/rooms")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get all rooms in flat(s)")]
    public async Task<IActionResult> GetAllRoomsInFlat(int flatId, CancellationToken token)
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

        var list = await _serviceWrapper.Rooms.GetRoomList(flatId, buildingId, token);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách phòng trống",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<RoomDetailEntity>>(list);

        var roomDetailEntities = resultList as RoomDetailEntity[] ?? resultList.ToArray();

        foreach (var room in roomDetailEntities)
            if (room.AvailableSlots != room.RoomType.TotalSlot)
                room.IsAnyOneRented = true;

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = roomDetailEntities
        });
    }


    [HttpGet("{roomId:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get rooms in building managed by supervisor")]
    public async Task<IActionResult> GetSpecificRoom(int roomId, CancellationToken token)
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

        var result = _mapper.Map<RoomDetailEntity>(room);

        if (room.AvailableSlots != room.RoomType.TotalSlot)
            result.IsAnyOneRented = true;

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị thông tin phòng",
            data = result
        });
    }

    /*
    [HttpPost]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Add rooms in building(s) managed by supervisor Id")]
    public async Task<IActionResult> CreateRoom(RoomCreateRequest request, CancellationToken token)
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

    [HttpPut("{roomId:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Update rooms in building(s) managed by supervisor Id")]
    public async Task<IActionResult> UpdateRoom(int roomId, RoomUpdateRequest request, CancellationToken token)
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

        var validation = await _validator.ValidateParams(request, roomId, buildingId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateRoom = new RoomType
        {
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

        var room = await _serviceWrapper.RoomTypes.GetRoomTypeById(roomId, buildingId, token);
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
    */
}
using AutoMapper;
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

[Route("api/room")]
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

    [HttpGet]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get all rooms in building(s) managed by supervisor Id")]
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

        var resultList = _mapper.Map<IEnumerable<RoomBasicDetailEntity>>(list);

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

    [HttpGet("{roomId:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get rooms in building(s) managed by supervisor Id")]
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

        var result = _mapper.Map<RoomBasicDetailEntity>(room);

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị thông tin phòng",
            data = result
        });
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

        var room = await _serviceWrapper.Rooms.GetRoomById(roomId, buildingId, token);

        if (room == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy phòng",
                data = ""
            });

        var result = _mapper.Map<RoomBasicDetailEntity>(room);

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị thông tin phòng",
            data = result
        });
    }
}
using AutoMapper;
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
        var filter = _mapper.Map<RoomFilter>(request);

        var list = await _serviceWrapper.Rooms.GetRoomList(filter, token);

        var resultList = _mapper.Map<IEnumerable<RoomBasicDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Room list is empty",
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


    [HttpGet("building")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get all rooms in a building")]
    public async Task<IActionResult> GetAllRoomInBuilding(int buildingId)
    {
        return Ok("On");
    }
}
namespace API.Controllers;
/*
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

        var list = await _serviceWrapper.Rooms.GetRoomList(filter, 0, token);

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
            message = "Hiển thị danh sách",
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

    /*
    [HttpGet("types")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation("[Authorize] Get all room types")]
    public async Task<IActionResult> GetAllRoomTypes(RoomTypeFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<RoomTypeFilter>(request);

        var list = await _serviceWrapper.RoomType.GetRoomTypes(filter, token);

        return Ok("test");
    }
    
}
*/
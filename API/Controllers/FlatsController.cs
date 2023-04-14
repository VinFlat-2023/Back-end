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
    [SwaggerOperation(Summary = "[Authorize] Get flat list by filter request (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFlats([FromQuery] FlatFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<FlatFilter>(request);

        var list = await _serviceWrapper.Flats.GetFlatList(filter, token);

        var resultList = _mapper.Map<IEnumerable<FlatDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách căn hộ trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách căn hộ",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/Flats/5
    [SwaggerOperation(Summary = "[Authorize] Get flat (For management and renter)")]
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFlat(int id)
    {
        var entity = await _serviceWrapper.Flats.GetFlatById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy căn hộ",
                data = ""
            });
        return Ok(
            new
            {
                status = "Success",
                message = "Đã tìm thấy căn hộ",
                data = _mapper.Map<FlatDetailEntity>(entity)
            });
    }

    // PUT: api/Flats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update flat info (For management)")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> PutFlat(int id, [FromBody] FlatUpdateRequest flat)
    {
        var validation = await _validator.ValidateParams(flat, id);

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
            Name = flat.Name,
            Description = flat.Description ?? "Không có thông tin mô tả",
            Status = flat.Status,
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };

        var result = await _serviceWrapper.Flats.UpdateFlat(updateFlat);

        return result.IsSuccess switch
        {
            false => BadRequest(
                new
            {
                status = "Bad Request",
                message = "Thông tin người dùng cập nhật thất bại",
                data = ""
            }),
            true => Ok(
                new
                {
                    status = "Success",
                    message = "Thông tin người dùng cập nhật thành công",
                    data = ""
                })
        };
    }

    // POST: api/Flats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create flat (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostFlat([FromBody] FlatCreateRequest flat)
    {
        var validation = await _validator.ValidateParams(flat);

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
            Description = flat.Description ?? "Không có mô tả",
            Status = flat.Status,
            WaterMeterBefore = 0,
            ElectricityMeterBefore = 0,
            WaterMeterAfter = 0,
            ElectricityMeterAfter = 0,
            MaxRoom = flat.MaxRoom ?? 1,
            AvailableRoom = flat.MaxRoom ?? 1,
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };

      

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
            data = ""
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

        var list = await _serviceWrapper.FlatTypes.GetFlatTypeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<FlatTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách loại căn hộ trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiện thị danh sách loại căn hộ",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/FlatTypes/5
    [SwaggerOperation(Summary = "[Authorize] Get flat type by id (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("type/{id:int}")]
    public async Task<IActionResult> GetFlatType(int id)
    {
        var entity = await _serviceWrapper.FlatTypes.GetFlatTypeById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy thông tin loại căn hộ",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Tìm thấy thông tin loại căn hộ",
                data = _mapper.Map<FlatTypeDetailEntity>(entity)
            });
    }

    // PUT: api/FlatTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update flat type info (For management)")]
    [Authorize(Roles = " Admin, Supervisor")]
    [HttpPut("type/{id:int}")]
    public async Task<IActionResult> PutFlatType(int id, [FromBody] FlatTypeUpdateRequest flatType)
    {
        var validation = await _validator.ValidateParams(flatType, id);
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

    // POST: api/FlatTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create flat type (For management)")]
    [Authorize(Roles = "Supervisor")]
    [HttpPost("type")]
    public async Task<IActionResult> PostFlatType([FromBody] FlatTypeCreateRequest flatType, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(flatType);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var supervisorId = int.Parse(User.Identity.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(supervisorId, token);

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
        
        var newFlatType = new FlatType
        {
            RoomCapacity = flatType.RoomCapacity,
            Status = flatType.Status,
            BuildingId = buildingId
        };

        var result = await _serviceWrapper.FlatTypes.AddFlatType(newFlatType);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tạo loại can hộ không thành công",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Tạo thành công",
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
    public async Task<IActionResult> GetTotalAvailableRoom(int id)
    {
        var result = await _serviceWrapper.Flats.GetRoomInAFlat(id);

        return result.IsSuccess switch
        {
            true => Ok(new 
            { 
                status = "Success", 
                message = result.Message,
                data = "" 
            }),
            false => 
                BadRequest(new
                {
                    status = "Bad Request", 
                    message = result.Message, 
                    data = ""
                })
        };
    }

    // TODO : Check validation 
    [SwaggerOperation(Summary = "[Authorize] Move a renter in inside available slot in a room (Not yet finished)")]
    [Authorize(Roles = " Admin, Supervisor")]
    [HttpPost("{flatId:int}/room/{roomId:int}/slots")]
    public async Task<IActionResult> MoveNewRenterIn(int flatId, int roomId, int renterId, CancellationToken token)
    {
        var entity = await _serviceWrapper.Flats.GetFlatById(flatId);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Căn hộ không tồn tại",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "",
            data = ""
        });
    }
}
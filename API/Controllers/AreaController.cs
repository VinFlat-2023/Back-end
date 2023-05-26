using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Area;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.AreaEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/areas")]
[ApiController]
public class AreaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IAreaValidator _validator;

    public AreaController(IMapper mapper, IServiceWrapper serviceWrapper,
        IAreaValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Areas
    [HttpGet]
    [SwaggerOperation(Summary = "[Authorize] Get area list")]
    public async Task<IActionResult> GetAreas([FromQuery] AreaFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<AreaFilter>(request);

        var list = await _serviceWrapper.Areas.GetAreaList(filter, token);

        if (list == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách khu vực trống",
                data = filter
            });

        var resultList = _mapper.Map<IEnumerable<AreaDetailEntity>>(list);

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [HttpGet("no-paging")]
    [SwaggerOperation(Summary = "[Authorize] Get area list")]
    public async Task<IActionResult> GetAreas(CancellationToken token)
    {
        var list = await _serviceWrapper.Areas.GetAreaList(token);

        var resultList = _mapper.Map<IEnumerable<AreaDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách khu vực trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách khu vực",
            data = resultList
        });
    }

    // GET: api/Areas/5
    [SwaggerOperation(Summary = "[Authorize] Get area using id")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetArea(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Areas.GetAreaByIdWithCache(id, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Khu vực không tìm thấy",
                data = ""
            });

        var result = _mapper.Map<AreaDetailEntity>(entity);

        return Ok(new
        {
            status = "Success",
            message = "Đã tìm thấy khu vực",
            data = result
        });
    }

    // PUT: api/Areas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update area info using id (For management)")]
    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutArea(int id, [FromBody] AreaUpdateRequest area, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(area, id, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateArea = new Area
        {
            AreaId = id,
            Name = area.Name,
            //Location = area.Location,
            Status = area.Status,
            AreaImageUrl1 = area.ImageUrl,
            AreaImageUrl2 = area.ImageUrl2,
            AreaImageUrl3 = area.ImageUrl3,
            AreaImageUrl4 = area.ImageUrl4
        };

        var result = await _serviceWrapper.Areas.UpdateArea(updateArea);

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

    // POST: api/Areas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create area (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostArea([FromBody] AreaCreateRequest area, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(area, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newArea = new Area
        {
            Name = area.Name,
            //Location = area.Location,
            Status = area.Status,
            AreaImageUrl1 = area.ImageUrl,
            AreaImageUrl2 = area.ImageUrl2,
            AreaImageUrl3 = area.ImageUrl3,
            AreaImageUrl4 = area.ImageUrl4
        };

        var result = await _serviceWrapper.Areas.AddArea(newArea);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tạo khu vực không thành công",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Khu vực được tạo thành công",
            data = _mapper.Map<AreaDetailEntity>(result)
        });
    }

    [SwaggerOperation(Summary = "Activate and Deactivate area status")]
    [Authorize(Roles = "Admin")]
    [HttpPut("{areaId:int}/toggle-area/status")]
    public async Task<IActionResult> ToggleAreaStatus(int areaId)
    {
        var result = await _serviceWrapper.Areas.ToggleAreaStatus(areaId);

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


    // DELETE: api/Areas/5
    [SwaggerOperation(Summary = "[Authorize] Delete area using id (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteArea(int id)
    {
        var result = await _serviceWrapper.Areas.DeleteArea(id);

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
}
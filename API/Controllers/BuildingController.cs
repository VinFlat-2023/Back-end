using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Building;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.BuildingEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/buildings")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IBuildingValidator _validator;

    public BuildingController(IMapper mapper, IServiceWrapper serviceWrapper,
        IBuildingValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Buildings
    [SwaggerOperation(Summary = "[Authorize] Get building list using query")]
    [HttpGet]
    public async Task<IActionResult> GetBuildings([FromQuery] BuildingFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<BuildingFilter>(request);

        var list = await _serviceWrapper.Buildings.GetBuildingList(filter, token);

        var resultList = _mapper.Map<IEnumerable<BuildingDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách toà nhà trống",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách toà nhà",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get current building (Supervisor only)")]
    [Authorize(Roles = "Supervisor")]
    [HttpGet("current")]
    public async Task<IActionResult> GetBuildingBasedOnSupervisor(CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

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

        var entity = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà này không tồn tại trong hệ thống",
                data = 0
            });

        return Ok(new
        {
            status = "Success",
            message = "Tải thành công thông tin kí túc xá",
            data = _mapper.Map<BuildingDetailEntity>(entity)
        });
    }

    // GET: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Get building info (For management and renter)")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBuilding(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Buildings.GetBuildingById(id, token);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà này không tồn tại trong hệ thống",
                data = ""
            });

        var building = _mapper.Map<BuildingDetailEntity>(entity);

        var imageUrls = new[]
        {
            entity.BuildingImageUrl1,
            entity.BuildingImageUrl2,
            entity.BuildingImageUrl3,
            entity.BuildingImageUrl4,
            entity.BuildingImageUrl5,
            entity.BuildingImageUrl6
        };

        building.ImageUrls = imageUrls;

        return Ok(new
        {
            status = "Success",
            message = "Building found",
            data = building
        });
    }

    // PUT: api/Buildings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Building info (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBuilding(int id, [FromBody] BuildingUpdateRequest building,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(building, id, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var buildingEntity = await _serviceWrapper.Buildings.GetBuildingById(id, token);

        if (buildingEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà này không tồn tại trong hệ thống",
                data = ""
            });

        var updateBuilding = new Building
        {
            BuildingId = id,
            BuildingName = building.BuildingName,
            BuildingAddress = building.BuildingAddress,
            Description = building.Description,
            BuildingPhoneNumber = building.BuildingPhoneNumber,
            AveragePrice = building.AveragePrice ?? 0,
            Status = building.Status,
            AreaId = building.AreaId,
            BuildingImageUrl1 = building.ImageUrl ?? buildingEntity.BuildingImageUrl1,
            BuildingImageUrl2 = building.ImageUrl2 ?? buildingEntity.BuildingImageUrl2,
            BuildingImageUrl3 = building.ImageUrl3 ?? buildingEntity.BuildingImageUrl3,
            BuildingImageUrl4 = building.ImageUrl4 ?? buildingEntity.BuildingImageUrl4,
            BuildingImageUrl5 = building.ImageUrl5 ?? buildingEntity.BuildingImageUrl5,
            BuildingImageUrl6 = building.ImageUrl6 ?? buildingEntity.BuildingImageUrl6
        };

        var result = await _serviceWrapper.Buildings.UpdateBuilding(updateBuilding);

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

    // POST: api/Buildings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create building (For management)")]
    [Authorize(Roles = "Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostBuilding([FromBody] BuildingCreateRequest building, CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity.Name);

        var supervisor = await _serviceWrapper.Employees.GetEmployeeById(employeeId, token);

        if (supervisor == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Nhân viên không tồn tại",
                data = ""
            });

        var validation = await _validator.ValidateParams(building, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var buildingForCurrentSupervisor =
            await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

        switch (buildingForCurrentSupervisor)
        {
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                    data = ""
                });
            case -1:
                var newBuilding = new Building
                {
                    BuildingName = building.BuildingName ?? "Building created by " + supervisor.FullName,
                    BuildingAddress = building.BuildingAddress ?? "To be filled",
                    Description = building.Description ?? "Building description",
                    TotalFlats = 0,
                    AveragePrice = building.AveragePrice ?? 0,
                    EmployeeId = employeeId,
                    Status = building.Status ?? true,
                    AreaId = building.AreaId,
                    BuildingPhoneNumber = building.BuildingPhoneNumber ?? "0",
                    BuildingImageUrl1 = building.ImageUrl,
                    BuildingImageUrl2 = building.ImageUrl2,
                    BuildingImageUrl3 = building.ImageUrl3,
                    BuildingImageUrl4 = building.ImageUrl4,
                    BuildingImageUrl5 = building.ImageUrl5,
                    BuildingImageUrl6 = building.ImageUrl6
                };

                var result = await _serviceWrapper.Buildings.AddBuildingAndItsManagement(newBuilding, employeeId);

                switch (result.IsSuccess)
                {
                    case true:
                        var buildingId =
                            await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

                        var buildingDetail =
                            await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

                        if (buildingDetail == null)
                            return NotFound(new
                            {
                                status = "Not Found",
                                message = "Toà nhà vừa tạo không tìm thấy",
                                data = ""
                            });

                        var employeeUpdate = new Employee
                        {
                            EmployeeId = employeeId,
                            SupervisorBuildingId = buildingDetail.BuildingId
                        };

                        //TODO: Implement batch insertion to include roll back

                        var employeeUpdateManagement =
                            await _serviceWrapper.Employees.UpdateEmployeeBuilding(employeeUpdate);

                        if (employeeUpdateManagement.IsSuccess == false)
                            return NotFound(new
                            {
                                status = "Not Found",
                                message = "Không thể cập nhật quản lý cho toà nhà",
                                data = ""
                            });

                        return Ok(new
                        {
                            status = "Success",
                            message = result.Message,
                            data = _mapper.Map<BuildingDetailEntity>(buildingDetail)
                        });

                    case false:
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = result.Message,
                            data = ""
                        });
                }
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Lỗi hệ thống",
            data = ""
        });
    }

// DELETE: api/Buildings/5
    [SwaggerOperation(Summary = "[Authorize] Remove building (For management)")]
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        var result = await _serviceWrapper.Buildings.DeleteBuilding(id);

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
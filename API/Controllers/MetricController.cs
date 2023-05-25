using AutoMapper;
using Domain.CustomEntities;
using Domain.EntityRequest.Metric;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.FlatEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/metric/current/building")]
[ApiController]
public class MetricController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public MetricController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet("total-water-and-electricity")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> GetTotalWaterAndElectricity(CancellationToken token)
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

        var result = await _serviceWrapper.Flats.GetTotalWaterAndElectricity(buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số điện nước",
            data = result
        });
    }

    [HttpGet("flats")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> GetTotalFlatInBuilding([FromQuery] MetricFlatFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<MetricFlatFilter>(request);

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

        var result = await _serviceWrapper.Flats.GetTotalFlatBasedOnFilter(filter, buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số điện nước",
            data = result
        });
    }

    [HttpGet("rooms")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> GetTotalRoomInBuilding([FromQuery] MetricRoomFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<MetricRoomFilter>(request);

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

        var result = await _serviceWrapper.Rooms.GetTotalRoomInBuilding(filter, buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số điện nước",
            data = result
        });
    }
    
    [HttpGet("renter")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> GetTotalRenter([FromQuery] MetricRenterContractFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<MetricRenterContractFilter>(request);

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

        var result = await _serviceWrapper.Contracts.GetTotalRenterWithActiveContract(filter, buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số người thuê đang có hợp đồng hoạt động",
            data = result
        });
    }

    [HttpGet("renter/contract")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> GetTotalRenterWithActiveContract([FromQuery] MetricRenterContractFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<MetricRenterContractFilter>(request);

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

        var result = await _serviceWrapper.Contracts.GetTotalRenterWithActiveContract(filter, buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số người thuê đang có hợp đồng hoạt động",
            data = result
        });
    }

    [HttpGet("flat/{flatId:int}/water-and-electricity")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> GetTotalWaterAndElectricity(int flatId, CancellationToken token)
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
                    data = -2
                });
        }

        var flat = await _serviceWrapper.Flats.GetFlatById(flatId, buildingId, token);
        if (flat == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy căn hộ",
                data = flat
            });

        var flatMap = _mapper.Map<FlatBasicDetailEntity>(flat);

        var result = await _serviceWrapper.Flats.GetTotalWaterAndElectricityByFlat(flatId, buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = ""
            });

        var resultForFlat = new MetricNumberForFlat
        {
            LastFetch = DateTime.Now.ToString("dd/MM/yyyy"),
            WaterNumber = result.WaterNumber,
            ElectricityNumber = result.ElectricityNumber,
            FlatId = flatId,
            Flat = flatMap
        };

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số điện nước của căn hộ",
            data = resultForFlat
        });
    }

    [HttpPut("flat/{flatId:int}")]
    [Authorize(Roles = "Supervisor, Technician")]
    public async Task<IActionResult> UpdateWaterAndElectricMeter([FromBody] UpdateMetricRequest request, int flatId,
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
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = -2
                });
        }

        var result = await _serviceWrapper.Flats.SetTotalWaterAndElectricityByFlat(request, flatId, buildingId, token);

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
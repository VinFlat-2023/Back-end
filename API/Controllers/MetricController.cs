using AutoMapper;
using Domain.CustomEntities;
using Domain.ViewModel.FlatEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/metric")]
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

    [HttpGet("current/building")]
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

        var result = await _serviceWrapper.Flats.GetTotalWaterAndElectricity(buildingId, token);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không tìm thấy dữ liệu",
                data = result
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị tổng số điện nước",
            data = result
        });
    }

    [HttpGet("current/building/flat/{flatId:int}")]
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
                data = result
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
}
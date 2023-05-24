using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Renter;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.RentalEntity;
using Domain.ViewModel.RenterEntity;
using Domain.ViewModel.ServiceEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;
using Utilities.Extensions;

namespace API.Controllers;

[Route("api/renters")]
[ApiController]
public class RentersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPasswordValidator _passwordValidator;
    private readonly IRenterValidator _renterValidator;
    private readonly IServiceWrapper _serviceWrapper;

    public RentersController(IMapper mapper, IServiceWrapper serviceWrapper,
        IRenterValidator renterValidator, IPasswordValidator passwordValidator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _renterValidator = renterValidator;
        _passwordValidator = passwordValidator;
    }

    // GET: api/Renters
    [HttpGet]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renter list with pagination and filter (For management)")]
    public async Task<IActionResult> GetRenters([FromQuery] RenterFilterRequest request, CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var filter = _mapper.Map<RenterFilter>(request);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

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

        var entity = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà không tồn tại",
                data = ""
            });

        var list = await _serviceWrapper.Renters.GetRenterList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<RenterProfileEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách khách thuê trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Tìm thấy danh sách khách thuê",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [HttpGet("contract/inactive")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renter list with pagination and filter (For management)")]
    public async Task<IActionResult> GetRentersWithNoActiveContract(CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

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

        var entity = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà không tồn tại",
                data = ""
            });

        var list = await _serviceWrapper.Renters.GetRenterList(buildingId, token);

        var resultList = _mapper.Map<IEnumerable<RenterProfileEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Danh sách khách thuê trống",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Tìm thấy danh sách khách thuê",
            data = resultList
        });
    }


    // GET: api/Renters/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renter by id (For management)")]
    public async Task<IActionResult> GetRenter(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Renters.GetRenterById(id, token);

        var renter = _mapper.Map<RenterProfileEntity>(entity);

        // convert gender to Vietnamese

        renter.Gender = renter.Gender switch
        {
            "male" => "Nam",
            "female" => "Nữ",
            _ => renter.Gender
        };

        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Người thuê không tồn tại",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Đã tìm thấy",
                data = renter
            });
    }

    [HttpGet("profile")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get renter profile by logged in user (For Renter)")]
    public async Task<IActionResult> GetRenter(CancellationToken token)
    {
        var renterId = int.Parse(User.Identity?.Name);
        var entity = await _serviceWrapper.Renters.GetRenterById(renterId, token);

        var renter = _mapper.Map<RenterProfileEntity>(entity);

        renter.Gender = renter.Gender switch
        {
            "male" => "Nam",
            "female" => "Nữ",
            _ => renter.Gender
        };

        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Người thuê không tồn tại",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Đã tìm thấy",
                data = renter
            });
    }

    [HttpGet("rental")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get current renter rental (For renter)")]
    public async Task<IActionResult> GetRental(CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var rentalCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (rentalCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Người dùng này hiện tại không có hợp đồng nào hoặc đang thuê",
                data = ""
            });

        var contract = await _serviceWrapper.Contracts
            .GetContractByRenterIdWithActiveStatus(rentalCheck.RenterId, token);

        if (contract == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Người thuê này hiện tại không có hợp đồng nào bên hệ thống",
                data = ""
            });

        var building = await _serviceWrapper.Buildings.GetBuildingById(contract.BuildingId, token);
        if (building == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà này không tồn tại trong hệ thống",
                data = ""
            });

        var flatCheck = await _serviceWrapper.Flats.GetFlatById(contract.FlatId, contract.BuildingId, token);
        if (flatCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Căn hộ này không tồn tại trong hệ thống",
                data = ""
            });

        var listRenter = await _serviceWrapper.Renters.GetRenterListBasedOnFlat(flatCheck.FlatId, token);
        if (listRenter == null || !listRenter.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Căn hộ này hiện đang trống",
                data = ""
            });

        var listService = await _serviceWrapper.ServicesEntity.GetServiceEntityList(new ServiceEntityFilter
        {
            BuildingId = building.BuildingId
        }, token);

        var flatMeterDetail = new FlatMeterDetailEntity
        {
            PriceForRent = contract.PriceForRent.DecimalToString(),
            PriceForWater = contract.PriceForWater.DecimalToString(),
            PriceForElectricity = contract.PriceForElectricity.DecimalToString(),
            PriceForService = contract.PriceForService.DecimalToString(),
            WaterMeterAfter = contract.Flat.WaterMeterAfter,
            ElectricityMeterAfter = contract.Flat.ElectricityMeterAfter
        };

        var buildingManager = new EmployeeBuildingDetailEntity
        {
            EmployeeId = building.EmployeeId,
            FullName = building.Employee.FullName,
            PhoneNumber = building.Employee.PhoneNumber
        };

        var buildingDetail = new BuildingContractDetailEntity
        {
            BuildingId = building.BuildingId,
            BuildingName = building.BuildingName,
            BuildingPhoneNumber = building.BuildingPhoneNumber,
            BuildingAddress = building.BuildingAddress,
            EmployeeId = building.EmployeeId,
            Employee = buildingManager
        };

        var rentalDetailEntity = new RentalDetailEntity
        {
            BuildingDetailEntity = buildingDetail,
            FlatName = contract.Flat.Name,
            FlatMeterEntity = flatMeterDetail,
            Services = _mapper.Map<ICollection<ServiceBasicDetailEntity>>(listService),
            Renters = _mapper.Map<ICollection<RenterBasicDetailEntity>>(listRenter)
        };

        return Ok(new
        {
            status = "Success",
            message = "Đã tìm thấy hợp đồng hiện tại của người thuê",
            data = rentalDetailEntity
        });
    }

    [HttpGet("basic-rental")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get current renter rental (For renter)")]
    public async Task<IActionResult> GetBasicRental(CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var rentalCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (rentalCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Khách thuê không tồn tại trong hệ thống",
                data = ""
            });

        var contract =
            await _serviceWrapper.Contracts.GetContractByRenterIdWithActiveStatus(rentalCheck.RenterId, token);
        if (contract == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Khách thuê này hiện đang không có hợp đồng thuê",
                data = ""
            });

        var building = await _serviceWrapper.Buildings.GetBuildingById(contract.BuildingId, token);
        if (building == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà không tồn tại trong hệ thống",
                data = ""
            });

        var flatCheck = await _serviceWrapper.Flats.GetFlatById(contract.FlatId, contract.BuildingId, token);

        if (flatCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Căn hộ này không tòn tại trong hệ thống",
                data = ""
            });

        // GET BUILDING / FLAT / RENTER / ROOM
        var basicRental = new BasicRentalEntity
        {
            BuildingId = building.BuildingId,
            BuildingName = building.BuildingName,
            FlatId = flatCheck.FlatId,
            FlatName = flatCheck.Name,
            RoomId = contract.RoomId,
            RoomName = "VF-2300"
        };

        return Ok(new
        {
            status = "Success",
            message = "Đã tìm thấy",
            data = basicRental
        });
    }


    // PUT: api/Renters/5
    // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("profile/update")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Update renter (For renter)")]
    public async Task<IActionResult> PutRenter([FromBody] RenterUpdateRequest renter, CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var validation = await _renterValidator.ValidateParams(renter, userId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });


        //var imageExtension = ImageExtension.ImageExtensionChecker(renter.Image?.FileName);

        //var fileNameUserImage = renterCheck.ImageUrl?.Split('/').Last();
        //var fileNameCitizenImage = renterCheck.CitizenImageUrl?.Split('/').Last();

        if (renter.Gender.ToLower() == "nữ".ToLower())
            renter.Gender = "female";

        if (renter.Gender.ToLower() == "nam".ToLower())
            renter.Gender = "male";

        var finalizeUpdate = new Renter
        {
            RenterId = userId,
            Email = renter.Email,
            PhoneNumber = renter.PhoneNumber,
            FullName = renter.FullName,
            BirthDate = DateTime.ParseExact(renter.BirthDate, "dd/MM/yyyy", null),
            /*
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renter.Image, fileNameUserImage,
                "User", imageExtension))?.Blob.Uri,
            CitizenNumber = renter.CitizenNumber,
            CitizenImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renter.CitizenImage, fileNameCitizenImage,
                "Citizen", imageExtension))?.Blob.Uri,
            */
            Address = renter.Address,
            Gender = renter.Gender
        };

        var result = await _serviceWrapper.Renters.UpdateRenter(finalizeUpdate);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            }),
            true => Ok(
                new
                {
                    status = "Success",
                    message = result.Message,
                    data = ""
                })
        };
    }

    [HttpPut("change-password")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Update renter password (For renter)")]
    public async Task<IActionResult> ChangePassword([FromBody] RenterUpdatePasswordRequest renter,
        CancellationToken token)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterEntity = await _serviceWrapper.Renters.GetRenterById(renterId, token);

        if (renterEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Khách thuê không tồn tại trong hệ thống",
                data = ""
            });

        var validation = await _passwordValidator.ValidateParams(renter, renterId, token);

        if (!validation.IsValid)
            return Ok(new
            {
                status = "Success",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var finalizePasswordUpdate = new Renter
        {
            RenterId = renterId,
            Password = renter.Password
        };

        var result = await _serviceWrapper.Renters.UpdatePasswordRenter(finalizePasswordUpdate);

        var jwtToken = _serviceWrapper.Tokens.CreateTokenForRenter(renterEntity);

        return result.IsSuccess switch
        {
            true => Ok(
                new
                {
                    status = "Success",
                    message = "Cập nhập mật khẩu thành công",
                    data = jwtToken
                }),
            false => BadRequest(new
            {
                status = "Bad Request",
                message = "Cập nhập mật khẩu thất bại",
                data = ""
            })
        };
    }


    /*
    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Register a new renter (For management)")]
    public async Task<IActionResult> PostRenter([FromBody] RenterCreateRequest renter)
    {
        var imageExtension = ImageExtension.ImageExtensionChecker(renter.Image?.FileName);

        var finalizeCreation = new Renter
        {
            Username = renter.Username,
            Email = renter.Email,
            Password = renter.Password,
            PhoneNumber = renter.PhoneNumber,
            FullName = renter.FullName,
            BirthDate = renter.BirthDate,
            Status = true,
            CitizenNumber = renter.CitizenNumber,

        
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(renter.Image,
                "User", imageExtension))?.Blob.Uri,
            CitizenImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(renter.CitizenImage,
                "Citizen", imageExtension))?.Blob.Uri,
            
            
            Address = renter.Address,
            Gender = renter.Gender,
        };

        var validation = await _renterValidator.ValidateParams(finalizeCreation, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Renters.AddRenter(finalizeCreation);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Renters failed to create",
                data = ""
            });

        if (!StringUtils.IsNotEmpty(renter.DeviceToken))
            return CreatedAtAction("GetRenter", new { id = result.RenterId }, result);

        var userDeviceFound = await _serviceWrapper.Devices
            .GetUdByDeviceToken(renter.DeviceToken);

        if (userDeviceFound.UserName == result.Username)
            return Ok(new
            {
                status = "Success",
                message = "Device token generated successfully",
                data = ""
            });

        userDeviceFound.UserName = result.Username;

        await _serviceWrapper.Devices.UpdateUserDeviceInfo(userDeviceFound);

        return Ok(new
        {
            status = "Success",
            message = "Device token generated successfully",
            data = ""
        });
    }
    
    */


    // DELETE: api/Renters/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Disable renter by id (For management)")]
    public async Task<IActionResult> DeleteRenter(int id, CancellationToken token)
    {
        var renter = await _serviceWrapper.Renters.GetRenterById(id, token);

        if (renter == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Người thuê không tồn tại",
                data = ""
            });

        /*
        var listUserDevice = await _serviceWrapper.Devices.GetDeviceByUserName(renter.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);
        */

        var result = await _serviceWrapper.Renters.DeleteRenter(id);

        return result.IsSuccess switch
        {
            true => Ok(new
            {
                status = "Success",
                message = "Renter deleted successfully",
                data = ""
            }),
            false => BadRequest(new
            {
                status = "Bad Request",
                message = "Renter failed to delete",
                data = ""
            })
        };
    }
}
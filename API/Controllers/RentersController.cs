using API.Extension;
using AutoMapper;
using Domain.CustomEntities.ViewModel.BuildingEntity;
using Domain.CustomEntities.ViewModel.FlatEntity;
using Domain.CustomEntities.ViewModel.RentalEntity;
using Domain.EntitiesDTO.RenterDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Renter;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/renters")]
[ApiController]
public class RentersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IRenterValidator _validator;

    public RentersController(IMapper mapper, IServiceWrapper serviceWrapper,
        IRenterValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Renters
    [HttpGet]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renter list with pagination and filter (For management)")]
    public async Task<IActionResult> GetRenters([FromQuery] RenterFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<RenterFilter>(request);

        var list = await _serviceWrapper.Renters.GetRenterList(filter, token);

        var resultList = _mapper.Map<IEnumerable<RenterDto>>(list);

        return list != null && !list.Any()
            ? NotFound(new
            {
                status = "Not Found",
                message = "Renter list is empty",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            });
    }

    // GET: api/Renters/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get renter by id (For management and renter)")]
    public async Task<IActionResult> GetRenter(int id)
    {
        /*
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        if (userRole is not ("Admin" or "Supervisor") || (User.Identity?.Name != id.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });
        */

        var entity = await _serviceWrapper.Renters.GetRenterById(id);

        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Renter not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Renter found",
                data = _mapper.Map<RenterDto>(entity)
            });
    }

    [HttpGet("rental")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get current renter rental (For renter)")]
    public async Task<IActionResult> GetRental()
    {
        var userId = int.Parse(User.Identity?.Name);

        var userEntity = await _serviceWrapper.Renters.GetRenterById(userId);

        if (userEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "This user does not exist in our system",
                data = ""
            });

        var rentalCheck = await _serviceWrapper.Renters.GetRenterById(userId);

        if (rentalCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "This renter does not exist in our system",
                data = ""
            });

        var contract = await _serviceWrapper.Contracts.GetContractByIdWithActiveStatus(rentalCheck.RenterId);

        if (contract == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "This renter does not have any active contract",
                data = ""
            });

        var building = await _serviceWrapper.Buildings.GetBuildingById(contract.BuildingId);

        if (building == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "This building does not exist in our system",
                data = ""
            });

        var flatDetail = new FlatDetailEntity
        {
            PriceForRent = contract.PriceForRent,
            PriceForWater = contract.PriceForWater,
            PriceForElectricity = contract.PriceForElectricity,
            PriceForService = contract.PriceForService,
            WaterMeterAfter = contract.Flat.WaterMeterAfter,
            ElectricityMeterAfter = contract.Flat.ElectricityMeterAfter
        };

        var buildingDetail = new BuildingManagerEntity
        {
            BuildingName = building.BuildingName,
            BuildingManager = building.Account.FullName,
            BuildingNumber = building.BuildingPhoneNumber
        };

        var rentalDetailEntity = new RentalDetailEntity
        {
            BuildingManagerEntity = buildingDetail,
            FlatName = contract.Flat.Name,
            FlatEntity = flatDetail
        };

        return Ok(new
        {
            status = "Success",
            message = "Rental found",
            data = rentalDetailEntity
        });
    }


    // PUT: api/Renters/5
    // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Update renter by id (For management and renter)")]
    public async Task<IActionResult> PutRenter([FromBody] RenterUpdateRequest renter, int id)
    {
        /*
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        Console.WriteLine(userRole);

        if (userRole is not ("Admin" or "Supervisor") || (User.Identity?.Name != id.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });
        */

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(id);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var imageExtension = ImageExtension.ImageExtensionChecker(renter.Image?.FileName);

        var fileNameUserImage = renterCheck.ImageUrl?.Split('/').Last();
        var fileNameCitizenImage = renterCheck.CitizenImageUrl?.Split('/').Last();

        var finalizeUpdate = new Renter
        {
            RenterId = id,
            Email = renter.Email,
            Password = renter.Password,
            Phone = renter.Phone,
            FullName = renter.FullName,
            BirthDate = renter.BirthDate ?? null,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renter.Image, fileNameUserImage,
                "User", imageExtension))?.Blob.Uri,
            /*
            CitizenNumber = renter.CitizenNumber,
            CitizenImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renter.CitizenImage, fileNameCitizenImage,
                "Citizen", imageExtension))?.Blob.Uri,
            */
            Address = renter.Address,
            Gender = renter.Gender,
            UniversityId = renter.UniversityId ?? null,
            MajorId = renter.MajorId ?? null
        };

        var validation = await _validator.ValidateParams(finalizeUpdate, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Renters.UpdateRenter(finalizeUpdate);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Renter failed to update",
                data = ""
            });

        return Ok(
            new
            {
                status = "Success",
                message = "Renter updated",
                data = ""
            });
    }

    [HttpPut("{id:int}/change-password")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Update renter by id (For management and renter)")]
    public async Task<IActionResult> ChangePassword([FromBody] RenterUpdateRequest renter, int id)
    {
        /*
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        Console.WriteLine(userRole);

        if (userRole is not ("Admin" or "Supervisor") || (User.Identity?.Name != id.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });
        */

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(id);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var finalizeUpdate = new Renter
        {
            Password = renter.Password
        };

        var validation = await _validator.ValidateParams(finalizeUpdate, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Renters.UpdateRenter(finalizeUpdate);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Renter failed to update",
                data = ""
            });

        return Ok(
            new
            {
                status = "Success",
                message = "Renter updated",
                data = ""
            });
    }


    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize("Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Register a new renter (For management)")]
    public async Task<IActionResult> PostRenter([FromBody] RenterCreateRequest renter)
    {
        var imageExtension = ImageExtension.ImageExtensionChecker(renter.Image?.FileName);

        var finalizeCreation = new Renter
        {
            Username = renter.Username,
            Email = renter.Email,
            Password = renter.Password,
            Phone = renter.Phone,
            FullName = renter.FullName,
            BirthDate = renter.BirthDate,
            Status = true,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(renter.Image,
                "User", imageExtension))?.Blob.Uri,
            CitizenNumber = renter.CitizenNumber,
            CitizenImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(renter.CitizenImage,
                "Citizen", imageExtension))?.Blob.Uri,
            Address = renter.Address,
            Gender = renter.Gender,
            UniversityId = renter.UniversityId ?? null,
            MajorId = renter.MajorId ?? null
        };

        var validation = await _validator.ValidateParams(finalizeCreation, null);
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


    // DELETE: api/Renters/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Disable renter by id (For management)")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        var renter = await _serviceWrapper.Renters.GetRenterById(id);

        if (renter == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Renter not found",
                data = ""
            });

        var listUserDevice = await _serviceWrapper.Devices.GetDeviceByUserName(renter.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);

        var result = await _serviceWrapper.Renters.DeleteRenter(id);
        return result
            ? BadRequest(new
            {
                status = "Bad Request",
                message = "Renter failed to delete",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Renter deleted successfully",
                data = ""
            });
    }
}
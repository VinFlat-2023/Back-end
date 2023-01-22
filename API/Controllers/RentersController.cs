using API.Extension;
using AutoMapper;
using Domain.EntitiesDTO.RenterDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Renter;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/renters")]
[ApiController]
public class RentersController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IRenterValidator _validator;

    public RentersController(IMapper mapper, IServiceWrapper serviceWrapper,
        IJwtRoleCheckerHelper jwtRoleCheckHelper, IRenterValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Renters
    [HttpGet]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renter list")]
    public async Task<IActionResult> GetRenters([FromQuery] RenterFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<RenterFilter>(request);

        var list = await _serviceWrapper.Renters.GetRenterList(filter, token);

        if (list != null && !list.Any())
            return NotFound("No renter available");

        var resultList = _mapper.Map<IEnumerable<RenterDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Renter list is not initialized");
    }

    [HttpGet("nofilter")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renters")]
    public async Task<IActionResult> GetRenterNoFilter(CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var list = await _serviceWrapper.Renters.GetRenterListNoFilter(token);

        if (list == null)
            return NotFound("Renter list not found");

        return Ok(_mapper.Map<IEnumerable<RenterDto>>(list));
    }


    // GET: api/Renters/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get renter by id")]
    public async Task<IActionResult> GetRenter(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, id))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Renters.GetRenterById(id);

        if (entity == null)
            return NotFound("Renter not found");

        return Ok(_mapper.Map<RenterDto>(entity));
    }

    // PUT: api/Renters/5
    // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Update renter by id")]
    public async Task<IActionResult> PutRenter([FromForm] RenterUpdateRequest renter, int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, id))
            return BadRequest("You are not authorized to access this information");

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(id);

        if (renterCheck == null)
            return NotFound("The renter is not available in our system!");

        var imageExtension = ImageExtension.ImageExtensionChecker(renter.Image?.FileName);

        var fileNameUserImage = renterCheck.ImageUrl?.Split('/').Last();
        var fileNameCitizenImage = renterCheck.CitizenImageUrl?.Split('/').Last();

        var finalizeUpdate = new Renter
        {
            RenterId = id,
            Username = renter.Username,
            Email = renter.Email,
            Password = renter.Password,
            Phone = renter.Phone,
            FullName = renter.FullName,
            BirthDate = renter.BirthDate ?? null,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renter.Image, fileNameUserImage,
                "User", imageExtension))?.Blob.Uri,
            CitizenNumber = renter.CitizenNumber,
            CitizenImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renter.CitizenImage, fileNameCitizenImage,
                "Citizen", imageExtension))?.Blob.Uri,
            Address = renter.Address,
            Gender = renter.Gender,
            UniversityId = renter.UniversityId ?? null,
            MajorId = renter.MajorId ?? null
        };

        var validation = await _validator.ValidateParams(finalizeUpdate, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Renters.UpdateRenter(finalizeUpdate);
        if (result == null)
            return NotFound("Update failed");

        return Ok("Update successfully");
    }

    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [SwaggerOperation(Summary = "[Authorize] Register a new renter")]
    public async Task<IActionResult> PostRenter([FromForm] RenterCreateRequest renter)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

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
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Renters.AddRenter(finalizeCreation);

        if (result == null)
            return NotFound("Create failed");

        if (!StringUtils.IsNotEmpty(renter.DeviceToken))
            return Ok("Created successfully");

        var userDeviceFound = await _serviceWrapper.Devices.GetUDByDeviceToken(renter.DeviceToken);
        if (userDeviceFound.UserName == result.Username)
            return Ok("Device token generated successfully");
        userDeviceFound.UserName = result.Username;
        await _serviceWrapper.Devices.UpdateUserDeviceInfo(userDeviceFound);

        return Ok("Device token generated successfully");
    }


    // DELETE: api/Renters/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Disable renter")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, id))
            return BadRequest("You are not authorized to access this information");

        var renter = await _serviceWrapper.Renters.GetRenterById(id);

        if (renter == null)
            return BadRequest("Renter not found");

        var listUserDevice = await _serviceWrapper.Devices.GetDeviceByUserName(renter.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);

        var result = await _serviceWrapper.Renters.DeleteRenter(id);
        return result
            ? NotFound("Renter failed to delete")
            : Ok("Renter deleted");
    }
}
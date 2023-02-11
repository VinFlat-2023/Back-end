using AutoMapper;
using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Account;
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

[Route("api/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IAccountValidator _validator;

    public AccountsController(IServiceWrapper serviceWrapper, IMapper mapper,
        IJwtRoleCheckerHelper jwtRoleCheckHelper, IAccountValidator validator)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Accounts
    [SwaggerOperation(Summary = "[Authorize] Get account list")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetAccounts([FromQuery] AccountFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<AccountFilter>(request);

        var list = await _serviceWrapper.Accounts.GetAccountList(filter, token);

        if (list != null && !list.Any())
            return NotFound("No account available");

        var resultList = _mapper.Map<IEnumerable<AccountDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Account list is not initialized");
    }

    [SwaggerOperation(Summary = "[Authorize] Get account by ID")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Accounts.GetAccountById(id);
        if (entity == null)
            return NotFound("Account not found");
        return Ok(
            new
            {
                status = "Success",
                message = "Account found",
                data = _mapper.Map<AccountDto>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create Account")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost("register")]
    public async Task<IActionResult> CreateAccount([FromForm] AccountCreateRequest account)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newAccount = new Account
        {
            Username = account.Username,
            Password = account.Password,
            Email = account.Email,
            Phone = account.Phone,
            Status = true,
            RoleId = account.RoleId
        };

        var validation = await _validator.ValidateParams(newAccount, null, User);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        // Create User Device token
        var result = await _serviceWrapper.Accounts.AddAccount(newAccount);
        if (result == null)
            return NotFound("Account not created");

        if (!StringUtils.IsNotEmpty(account.DeviceToken))
            return CreatedAtAction("GetAccount", new { id = result.AccountId }, result);

        var userDeviceFound = await _serviceWrapper.Devices.GetUDByDeviceToken(account.DeviceToken);

        if (userDeviceFound.UserName == result.Username)
            return CreatedAtAction("GetAccount", new { id = result.AccountId }, result);

        userDeviceFound.UserName = result.Username;

        await _serviceWrapper.Devices.UpdateUserDeviceInfo(userDeviceFound);

        return CreatedAtAction("GetAccount", new { id = result.AccountId }, result);
    }

    // PUT: api/Accounts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "Update account info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAccount(int id, [FromForm] AccountUpdateRequest account)
    {
        if (await _jwtRoleCheckHelper.IsManagementAndEmployeeRoleAuthorized(User, id))
            return BadRequest("You are not authorized to access this information");

        var updateAccount = new Account
        {
            AccountId = id,
            Username = account.Username ?? string.Empty,
            Password = account.Password ?? string.Empty,
            Email = account.Email ?? string.Empty,
            Phone = account.Phone ?? string.Empty,
            RoleId = account.RoleId
        };

        var validation = await _validator.ValidateParams(updateAccount, id, User);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Accounts.UpdateAccount(updateAccount);
        if (result == null)
            return NotFound("Updating account failed");

        return Ok("Account updated successfully");
    }

    [SwaggerOperation(Summary = "Activate and Deactivate Account")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("toggle-account/{id:int}")]
    public async Task<IActionResult> ToggleAccountStatus(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementAndEmployeeRoleAuthorized(User, id))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Accounts.ToggleAccountStatus(id);
        if (!result)
            return BadRequest("Updating account status failed");

        return Ok($"Status updated at : {DateTime.Now.ToShortDateString()}");
    }

    // DELETE: api/Accounts/5
    [SwaggerOperation(Summary = "Remove Account")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var account = await _serviceWrapper.Accounts.GetAccountById(id);

        if (account == null)
            return BadRequest("Account not found");

        var listUserDevice =
            await _serviceWrapper.Devices.GetDeviceByUserName(account.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);

        var result = await _serviceWrapper.Accounts.DeleteAccount(id);

        if (!result)
            return BadRequest("Account failed to delete");

        return Ok($"Account deleted at : {DateTime.Now.ToShortDateString()}");
    }
}
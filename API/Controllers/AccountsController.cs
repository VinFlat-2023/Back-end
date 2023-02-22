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
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IAccountValidator _validator;

    public AccountsController(IServiceWrapper serviceWrapper, IMapper mapper,
        IAccountValidator validator)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
        _validator = validator;
    }

    // GET: api/Accounts
    [SwaggerOperation(Summary = "[Authorize] Get account list")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetAccounts([FromQuery] AccountFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<AccountFilter>(request);

        var list = await _serviceWrapper.Accounts.GetAccountList(filter, token);

        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Success",
                message = "Account list is empty",
                data = ""
            });

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
            : NotFound(new
            {
                status = "Not Found",
                message = "Account list is empty",
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get account by ID")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        var entity = await _serviceWrapper.Accounts.GetAccountById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Account not found",
                data = ""
            });
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
    public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest account)
    {
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
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        // Create User Device token
        var result = await _serviceWrapper.Accounts.AddAccount(newAccount);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Account failed to create",
                data = ""
            });

        if (!StringUtils.IsNotEmpty(account.DeviceToken))
            return CreatedAtAction("GetAccount", new { id = result.AccountId }, result);

        var userDeviceFound = await _serviceWrapper.Devices.GetUdByDeviceToken(account.DeviceToken);

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

    // PUT: api/Accounts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "Update account info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountUpdateRequest account)
    {
        var updateAccount = new Account
        {
            AccountId = id,
            Username = account.Username,
            Password = account.Password ?? string.Empty,
            Email = account.Email,
            Phone = account.Phone,
            RoleId = account.RoleId
        };

        var validation = await _validator.ValidateParams(updateAccount, id, User);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Accounts.UpdateAccount(updateAccount);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Updating account failed",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Account updated",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "Activate and Deactivate Account")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("toggle-account/{id:int}")]
    public async Task<IActionResult> ToggleAccountStatus(int id)
    {
        var result = await _serviceWrapper.Accounts.ToggleAccountStatus(id);
        if (!result)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Account status failed to update",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Account status updated",
            data = ""
        });
    }

    // DELETE: api/Accounts/5
    [SwaggerOperation(Summary = "Remove Account")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var account = await _serviceWrapper.Accounts.GetAccountById(id);

        if (account == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Account not found",
                data = ""
            });
        var listUserDevice =
            await _serviceWrapper.Devices.GetDeviceByUserName(account.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);

        var result = await _serviceWrapper.Accounts.DeleteAccount(id);

        if (!result)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Account failed to delete",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Account deleted",
            data = ""
        });
    }
}
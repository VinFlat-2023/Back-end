using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Account;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Domain.ViewModel.AccountEntity;
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
    private readonly IAccountValidator _accountValidator;
    private readonly IMapper _mapper;
    private readonly IPasswordValidator _passwordValidator;
    private readonly IServiceWrapper _serviceWrapper;

    public AccountsController(IServiceWrapper serviceWrapper, IMapper mapper,
        IAccountValidator accountValidator, IPasswordValidator passwordValidator)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
        _accountValidator = accountValidator;
        _passwordValidator = passwordValidator;
    }

    // GET: api/Accounts
    [SwaggerOperation(Summary = "[Authorize] Get account list")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetAccounts([FromQuery] AccountFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<AccountFilter>(request);

        var list = await _serviceWrapper.Accounts.GetAccountList(filter, token);

        var resultList = _mapper.Map<IEnumerable<AccountDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Account list is empty",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "List found",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get account by ID")]
    [Authorize(Roles = "Admin, Supervisor")]
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
                data = _mapper.Map<AccountDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create Account")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost("register")]
    public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest account)
    {
        var newAccount = new Account
        {
            Username = account.Username,
            FullName = account.Fullname,
            Password = account.Password,
            Email = account.Email,
            Phone = account.Phone,
            Status = true,
            RoleId = account.RoleId
        };

        var validation = await _accountValidator.ValidateParams(newAccount, null, false);
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
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountUpdateRequest account)
    {
        var accountEntity = await _serviceWrapper.Accounts.GetAccountById(id);

        if (accountEntity == null)
            return NotFound(new
            {
                status = "Bad Request",
                message = "This account does not exist",
                data = ""
            });

        var updateAccount = new Account
        {
            AccountId = id,
            Username = account.Username ?? accountEntity.Username,
            Email = account.Email ?? accountEntity.Email,
            Phone = account.Phone ?? accountEntity.Phone,
            FullName = account.Fullname ?? accountEntity.FullName
        };

        var validation = await _accountValidator.ValidateParams(updateAccount, id, true);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Accounts.UpdateAccount(updateAccount);

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

    [SwaggerOperation(Summary = "Update account password")]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpPut("change-password")]
    public async Task<IActionResult> UpdateAccountPassword([FromBody] AccountUpdatePasswordRequest account)
    {
        var accountId = int.Parse(User.Identity?.Name);
        var accountEntity = await _serviceWrapper.Accounts.GetAccountById(accountId);

        if (accountEntity == null)
            return NotFound(new
            {
                status = "Bad Request",
                message = "This account does not exist",
                data = ""
            });

        var updatePasswordAccount = new Account
        {
            AccountId = accountId,
            Password = account.Password
        };

        var validation = await _passwordValidator
            .ValidateParams(updatePasswordAccount.Password, accountId, false);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Accounts.UpdatePasswordAccount(updatePasswordAccount);

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


    [SwaggerOperation(Summary = "Activate and Deactivate Account")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("toggle-account/status")]
    public async Task<IActionResult> ToggleAccountStatus()
    {
        var accountId = int.Parse(User.Identity?.Name);

        var result = await _serviceWrapper.Accounts.ToggleAccountStatus(accountId);

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

    // DELETE: api/Accounts/5
    [SwaggerOperation(Summary = "Remove Account")]
    [Authorize(Roles = "Admin")]
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
using Domain.ControllerEntities;
using Domain.EntitiesForManagement;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IServiceWrapper _serviceWrapper;

    public AuthController(IServiceWrapper serviceWrapper)
    {
        _serviceWrapper = serviceWrapper;
    }

    /// <summary>
    ///     login for management
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns></returns>
    [SwaggerOperation(Summary =
        "Login for management team with username and password. Return JWT Token if login successfully")]
    [HttpPost("management/v1/login")]
    public async Task<IActionResult> LoginManagement([FromBody] LoginModel loginModel)
    {
        var account = await _serviceWrapper.Accounts
            .AccountLogin(loginModel.Username, loginModel.Password);

        if (account == null)
            return Unauthorized("Username or password is wrong");

        if (StringUtils.IsNotEmpty(loginModel.DeviceToken))
        {
            var userDeviceFound = await _serviceWrapper.Devices.GetUDByDeviceToken(loginModel.DeviceToken);
            if (userDeviceFound == null)
            {
                var userDevice = new UserDevice
                {
                    DeviceToken = loginModel.DeviceToken,
                    UserName = account.Username
                };
                await _serviceWrapper.Devices.AddUserDeviceInfo(userDevice);
            }
            else if (userDeviceFound.UserName != account.Username)
            {
                userDeviceFound.UserName = account.Username;
                await _serviceWrapper.Devices.UpdateUserDeviceInfo(userDeviceFound);
            }
        }

        var jwtToken = _serviceWrapper.Tokens.CreateTokenForAccount(account);
        return Ok(new
        {
            status = "Success",
            message = "User logged in successfully",
            data = new
            {
                id = account.AccountId,
                token = jwtToken
            }
        });
    }

    /// <summary>
    ///     login for renter
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns></returns>
    [SwaggerOperation(Summary = "Login for renters with username and password. Return JWT Token if login successfully")]
    [HttpPost("user/v1/login")]
    public async Task<IActionResult> LoginRenter([FromBody] LoginModel loginModel)
    {
        var renter = await _serviceWrapper.Renters
            .RenterLogin(loginModel.Username, loginModel.Password);

        if (renter == null)
            return Unauthorized("Username or password is wrong");

        if (StringUtils.IsNotEmpty(loginModel.DeviceToken))
        {
            var userDeviceFound = await _serviceWrapper.Devices.GetUDByDeviceToken(loginModel.DeviceToken);
            if (userDeviceFound == null)
            {
                var userDevice = new UserDevice
                {
                    DeviceToken = loginModel.DeviceToken,
                    UserName = renter.Username
                };
                await _serviceWrapper.Devices.AddUserDeviceInfo(userDevice);
            }
            else if (userDeviceFound.UserName != renter.Username)
            {
                userDeviceFound.UserName = renter.Username;
                await _serviceWrapper.Devices.UpdateUserDeviceInfo(userDeviceFound);
            }
        }

        var jwtToken = _serviceWrapper.Tokens.CreateTokenForRenter(renter);
        return Ok(new
        {
            status = "Success",
            message = "User logged in successfully",
            data = new
            {
                id = renter.RenterId,
                token = jwtToken
            }
        });
    }
}
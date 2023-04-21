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
    /// <param name="token"></param>
    /// <returns></returns>
    [SwaggerOperation(Summary =
        "Login for management team with username and password. Return JWT Token if login successfully")]
    [HttpPost("management/v1/login")]
    public async Task<IActionResult> LoginManagement([FromBody] LoginModel loginModel, CancellationToken token)
    {
        var employee = await _serviceWrapper.Employees
            .EmployeeLogin(loginModel.UsernameOrPhoneNumber, loginModel.Password, token);

        if (employee == null)
            return Unauthorized(new
            {
                status = "Success",
                message = "Tên đăng nhập, số điện thoại hoặc mật khẩu không đúng",
                data = ""
            });
        if (StringUtils.IsNotEmpty(loginModel.DeviceToken))
        {
            var userDeviceFound = await _serviceWrapper.Devices.GetUdByDeviceToken(loginModel.DeviceToken);
            if (userDeviceFound == null)
            {
                var userDevice = new UserDevice
                {
                    DeviceToken = loginModel.DeviceToken,
                    UserName = employee.Username
                };
                await _serviceWrapper.Devices.AddUserDeviceInfo(userDevice);
            }
            else if (userDeviceFound.UserName != employee.Username)
            {
                userDeviceFound.UserName = employee.Username;
                await _serviceWrapper.Devices.UpdateUserDeviceInfo(userDeviceFound);
            }
        }

        var jwtToken = _serviceWrapper.Tokens.CreateTokenForEmployee(employee);
        return Ok(new
        {
            status = "Success",
            message = "Người dùng đăng nhập thành công",
            data = new
            {
                id = employee.EmployeeId,
                token = jwtToken,
                roleName = employee.Role.RoleName
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
    public async Task<IActionResult> LoginRenter([FromBody] LoginModel loginModel, CancellationToken token)
    {
        var renter = await _serviceWrapper.Renters
            .RenterLogin(loginModel.UsernameOrPhoneNumber, loginModel.Password, token);

        if (renter == null)
            return Unauthorized(new
            {
                status = "Unauthorized",
                message = "Tên đăng nhập, số điện thoại hoặc mật khẩu không đúng",
                data = ""
            });

        if (StringUtils.IsNotEmpty(loginModel.DeviceToken))
        {
            var userDeviceFound = await _serviceWrapper.Devices.GetUdByDeviceToken(loginModel.DeviceToken);
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
            message = "Người dùng đăng nhập thành công",
            data = new
            {
                id = renter.RenterId,
                token = jwtToken,
                roleName = "Renter"
            }
        });
    }
}
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Employee;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Domain.ViewModel.EmployeeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeValidator _employeeValidator;
    private readonly IMapper _mapper;
    private readonly IPasswordValidator _passwordValidator;
    private readonly IServiceWrapper _serviceWrapper;

    public EmployeesController(IServiceWrapper serviceWrapper, IMapper mapper,
        IEmployeeValidator employeeValidator, IPasswordValidator passwordValidator)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
        _employeeValidator = employeeValidator;
        _passwordValidator = passwordValidator;
    }

    // GET: api/Employees
    [SwaggerOperation(Summary = "[Authorize] Get employee list")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetEmployees([FromQuery] EmployeeFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<EmployeeFilter>(request);

        var list = await _serviceWrapper.Employees.GetEmployeeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<EmployeeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Employee list is empty",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get employee by ID")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Employees.GetEmployeeById(id, token);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Nhân viên không tồn tại",
                data = ""
            });
        return Ok(
            new
            {
                status = "Success",
                message = "Employee found",
                data = _mapper.Map<EmployeeDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get current logged in employee")]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpGet("profile")]
    public async Task<IActionResult> GetCurrentLoginEmployee(CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);
        var entity = await _serviceWrapper.Employees.GetEmployeeById(employeeId, token);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Nhân viên không tồn tại",
                data = ""
            });
        return Ok(
            new
            {
                status = "Success",
                message = "Employee found",
                data = _mapper.Map<EmployeeDetailEntity>(entity)
            });
    }


    [SwaggerOperation(Summary = "[Authorize] Create Employee")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost("register")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequest employee, CancellationToken token)
    {
        var validation = await _employeeValidator.ValidateParams(employee, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newEmployee = new Employee
        {
            Username = employee.Username,
            FullName = employee.Fullname,
            Password = "123456",
            Address = employee.Address,
            Email = employee.Email,
            Phone = employee.Phone,
            Status = true,
            RoleId = employee.RoleId
        };

        // Create User Device token
        var result = await _serviceWrapper.Employees.AddEmployee(newEmployee);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Employee failed to create",
                data = ""
            });

        if (!StringUtils.IsNotEmpty(employee.DeviceToken))
            return CreatedAtAction("GetEmployee", new { id = result.EmployeeId }, result);

        var userDeviceFound = await _serviceWrapper.Devices.GetUdByDeviceToken(employee.DeviceToken);

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

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "Update employee info")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateRequest employee,
        CancellationToken token)
    {
        var validation = await _employeeValidator.ValidateParams(employee, id, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateEmployee = new Employee
        {
            EmployeeId = id,
            Address = employee.Address,
            Email = employee.Email,
            Phone = employee.Phone,
            FullName = employee.Fullname
        };

        var result = await _serviceWrapper.Employees.UpdateEmployee(updateEmployee);

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

    [SwaggerOperation(Summary = "Update employee info")]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpPut("profile/update")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateRequest employee, CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var validation = await _employeeValidator.ValidateParams(employee, employeeId, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateEmployee = new Employee
        {
            EmployeeId = employeeId,
            Address = employee.Address,
            Email = employee.Email,
            Phone = employee.Phone,
            FullName = employee.Fullname
        };

        var result = await _serviceWrapper.Employees.UpdateEmployee(updateEmployee);

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

    [SwaggerOperation(Summary = "Update employee password")]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpPut("change-password")]
    public async Task<IActionResult> UpdateEmployeePassword([FromBody] EmployeeUpdatePasswordRequest employee,
        CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);
        
        var employeeEntity = await _serviceWrapper.Employees.GetEmployeeById(employeeId, token);

        if (employeeEntity == null)
            return NotFound(new
            {
                status = "Bad Request",
                message = "Nhân viên không tồn tại",
                data = ""
            });

        var validation = await _passwordValidator.ValidateParams(employee, employeeId, token);

        if (!validation.IsValid)
            return Ok(new
            {
                status = "Success",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updatePasswordEmployee = new Employee
        {
            EmployeeId = employeeId,
            Password = employee.Password
        };

        var result = await _serviceWrapper.Employees.UpdatePasswordEmployee(updatePasswordEmployee);

        var jwtToken = _serviceWrapper.Tokens.CreateTokenForEmployee(employeeEntity);

        return result.IsSuccess switch
        {
            true => Ok(new
            {
                status = "Success",
                message = result.Message,
                data = jwtToken
            }),
            false => NotFound(new
            {
                status = "Not Found",
                message = result.Message,
                data = ""
            })
        };
    }


    [SwaggerOperation(Summary = "Activate and Deactivate Employee")]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpPut("toggle-employee/status")]
    public async Task<IActionResult> ToggleEmployeeStatus()
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var result = await _serviceWrapper.Employees.ToggleEmployeeStatus(employeeId);

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

    // DELETE: api/Employees/5
    [SwaggerOperation(Summary = "Remove Employee")]
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id, CancellationToken token)
    {
        var employee = await _serviceWrapper.Employees.GetEmployeeById(id, token);

        if (employee == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Nhân viên không tồn tại",
                data = ""
            });

        var listUserDevice =
            await _serviceWrapper.Devices.GetDeviceByUserName(employee.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);

        var result = await _serviceWrapper.Employees.DeleteEmployee(id);

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
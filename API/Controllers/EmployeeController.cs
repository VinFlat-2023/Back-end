using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Employee;
using Domain.EnumEntities;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Domain.ViewModel.EmployeeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeValidator _employeeValidator;
    private readonly IMapper _mapper;
    private readonly IPasswordValidator _passwordValidator;
    private readonly IServiceWrapper _serviceWrapper;

    public EmployeeController(IServiceWrapper serviceWrapper, IMapper mapper,
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
                message = "Danh sách nhân viên trống",
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

    [SwaggerOperation(Summary = "[Authorize] Get employee by Id")]
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
                message = "Đã tìm thấy",
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
                message = "Đã tìm thấy",
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
            PhoneNumber = employee.PhoneNumber,
            Status = true,
            RoleId = employee.RoleId
        };

        switch (employee.RoleId)
        {
            case 2:
                newEmployee.SupervisorBuildingId = employee.BuildingId;
                break;
            case 3:
                newEmployee.TechnicianBuildingId = employee.BuildingId;
                break;
        }

        // Create User Device token
        var result = await _serviceWrapper.Employees.AddEmployee(newEmployee);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tạo nhân viên thất bại",
                data = ""
            });

        if (!StringUtils.IsNotEmpty(employee.DeviceToken))
            return CreatedAtAction("GetEmployee", new { id = result.EmployeeId }, result);

        /*
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
        */

        return Ok(new
        {
            status = "Success",
            message = "Tạo mới nhân viên thành công",
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

        var employeeCheck = await _serviceWrapper.Employees.GetEmployeeById(id, token);

        if (employeeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Nhân viên không tồn tại",
                data = ""
            });

        var updateEmployee = new Employee
        {
            EmployeeId = id,
            Address = employee.Address,
            Email = employee.Email,
            FullName = employee.Fullname
        };

        switch (employeeCheck.Role.RoleName.ToLower())
        {
            case "supervisor":
                updateEmployee.SupervisorBuildingId = employee.BuildingId;
                break;
            case "technician":
                updateEmployee.TechnicianBuildingId = employee.BuildingId;
                break;
        }

        if (employee.Phone != null)
            updateEmployee.PhoneNumber = employee.Phone;

        if (employee.PhoneNumber != null)
            updateEmployee.PhoneNumber = employee.PhoneNumber;


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
            FullName = employee.Fullname
        };

        if (employee.PhoneNumber != null)
            updateEmployee.PhoneNumber = employee.PhoneNumber;

        if (employee.Phone != null)
            updateEmployee.PhoneNumber = employee.Phone;

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

        var jwtToken = _serviceWrapper.Tokens.CreateTokenForEmployee(employeeEntity, TokenType.UpdatePassword);

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

        /*
        var listUserDevice =
            await _serviceWrapper.Devices.GetDeviceByUserName(employee.Username);

        if (!listUserDevice.IsNullOrEmpty())
            await _serviceWrapper.Devices.DeleteUserDevice(listUserDevice);
        */

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
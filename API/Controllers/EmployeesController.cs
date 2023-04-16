using System.Security.Claims;
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
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpGet]
    public async Task<IActionResult> GetEmployees([FromQuery] EmployeeFilterRequest request, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var filter = _mapper.Map<EmployeeFilter>(request);

        var employeeId = int.Parse(User.Identity?.Name);

        switch (userRole)
        {
            case "Admin":
                var adminList = await _serviceWrapper.Employees.GetEmployeeList(filter, token);

                if (adminList == null || !adminList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Employee list is empty",
                        data = ""
                    });

                var adminResultList = _mapper.Map<IEnumerable<EmployeeDetailEntity>>(adminList);

                return Ok(new
                {
                    status = "Success",
                    message = "List found",
                    data = adminResultList,
                    totalPage = adminList.TotalPages,
                    totalCount = adminList.TotalCount
                });

            case "Supervisor":

                var buildingSupervisor = await _serviceWrapper.GetId
                    .GetBuildingIdBasedOnSupervisorId(employeeId, token);

                // buildingId = -2 means there are more than one building with status 'Active' found
                switch (buildingSupervisor)
                {
                    case -2:
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Supervisor manage more than one building with status 'Active' found",
                            data = ""
                        });
                    case -1:
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = "No building found with status Active' or no building found at all for this user",
                            data = ""
                        });
                }

                var supervisorList = await _serviceWrapper.Employees.GetEmployeeList(filter, buildingSupervisor, token);

                if (supervisorList == null || !supervisorList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Employee list is empty",
                        data = ""
                    });

                var supervisorResultList = _mapper.Map<IEnumerable<EmployeeDetailEntity>>(supervisorList);

                return Ok(new
                {
                    status = "Success",
                    message = "List found",
                    data = supervisorResultList,
                    totalPage = supervisorList.TotalPages,
                    totalCount = supervisorList.TotalCount
                });

            case "Technician":

                var buildingTechnician = await _serviceWrapper.GetId
                    .GetBuildingIdBasedOnTechnicianId(employeeId, token);

                // buildingId = -2 means this technician is assigned to more than one building with status 'Active'
                switch (buildingTechnician)
                {
                    case -2:
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Technician is assigned more than one building with status 'Active' found",
                            data = ""
                        });
                    case -1:
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = "No building found with status Active' or no building found at all for this user",
                            data = ""
                        });
                }

                var technicianList = await _serviceWrapper.Employees.GetEmployeeList(filter, buildingTechnician, token);

                if (technicianList == null || !technicianList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Employee list is empty",
                        data = ""
                    });

                var technicianResultList = _mapper.Map<IEnumerable<EmployeeDetailEntity>>(technicianList);

                return Ok(new
                {
                    status = "Success",
                    message = "List found",
                    data = technicianResultList,
                    totalPage = technicianList.TotalPages,
                    totalCount = technicianList.TotalCount
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request with employee controller !!!",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get employee by ID")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var entity = await _serviceWrapper.Employees.GetEmployeeById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Employee not found",
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
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet("profile")]
    public async Task<IActionResult> GetCurrentLoginEmployee()
    {
        var employeeId = int.Parse(User.Identity?.Name);
        var entity = await _serviceWrapper.Employees.GetEmployeeById(employeeId);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Employee not found",
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
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequest employee)
    {
        var validation = await _employeeValidator.ValidateParams(employee);

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
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateRequest employee)
    {
        var validation = await _employeeValidator.ValidateParams(employee, id);

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
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("profile/update")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateRequest employee)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var validation = await _employeeValidator.ValidateParams(employee, employeeId);

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
    public async Task<IActionResult> UpdateEmployeePassword([FromBody] EmployeeUpdatePasswordRequest employee)
    {
        var employeeId = int.Parse(User.Identity?.Name);
        var employeeEntity = await _serviceWrapper.Employees.GetEmployeeById(employeeId);

        if (employeeEntity == null)
            return NotFound(new
            {
                status = "Bad Request",
                message = "Nhân viên không tồn tại",
                data = ""
            });

        if (employee.OldPassword != employeeEntity.Password)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Mật khẩu cũ không đúng, vui lòng kiểm tra lại",
                data = ""
            });

        if (employee.Password != employee.ConfirmPassword)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Mật khẩu mới và mật khẩu xác nhận không khớp, vui lòng kiểm tra lại",
                data = ""
            });

        var validation = await _passwordValidator
            .ValidateParams(employee.Password, employeeId, false);

        var updatePasswordEmployee = new Employee
        {
            EmployeeId = employeeId,
            Password = employee.Password
        };


        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

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
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _serviceWrapper.Employees.GetEmployeeById(id);

        if (employee == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Employee not found",
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
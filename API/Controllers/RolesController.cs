using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Role;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.RoleEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/roles")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IRoleValidator _validator;

    public RolesController(IMapper mapper, IServiceWrapper serviceWrapper,
        IRoleValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [SwaggerOperation(Summary = "[Authorize] Get role list with pagination and filter (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetRoleList([FromQuery] RoleFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<RoleFilter>(request);

        var list = await _serviceWrapper.Roles.GetRoleList(filter, token);

        var resultList = _mapper.Map<IEnumerable<RoleDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Role list is empty",
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

    [SwaggerOperation(Summary = "[Authorize] Get role by id (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRole(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Roles.GetRoleById(id, token);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Role not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Role found",
                data = _mapper.Map<RoleDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create role (For management)")]
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleCreateRequest role, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(role, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Role failed to create",
                data = ""
            });

        var newRole = new Role
        {
            RoleName = role.RoleName,
            Status = role.Status
        };

        var result = await _serviceWrapper.Roles.AddRole(newRole);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Role failed to create",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Role deleted",
            data = _mapper.Map<RoleDetailEntity>(result)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Update role info (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut]
    public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleUpdateRequest role, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(role, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateRole = new Role
        {
            RoleId = id,
            RoleName = role.RoleName,
            Status = role.Status
        };

        var result = await _serviceWrapper.Roles.UpdateRole(updateRole);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Role failed to update",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Role updated",
            data = ""
        });
    }
}
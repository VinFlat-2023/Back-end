using AutoMapper;
using Domain.EntitiesDTO.RoleDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Role;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/roles")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckerHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IRoleValidator _validator;

    public RolesController(IMapper mapper, IServiceWrapper serviceWrapper, IJwtRoleCheckerHelper jwtRoleCheckHelper,
        IRoleValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckerHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    [SwaggerOperation(Summary = "[Authorize] Get Role list")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetRoleList([FromQuery] RoleFilterRequest request, CancellationToken token)
    {
        // TODO : pass cancellation token
        if (await _jwtRoleCheckerHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<RoleFilter>(request);

        var list = await _serviceWrapper.Roles.GetRoleList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No role available");

        var resultList = _mapper.Map<IEnumerable<RoleDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Role list is not initialized");
    }

    [SwaggerOperation(Summary = "[Authorize] Get Role")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRole(int id)
    {
        // TODO : pass cancellation token
        if (await _jwtRoleCheckerHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Roles.GetRoleById(id);
        if (entity == null)
            return NotFound("No role available");
        return Ok(_mapper.Map<RoleDto>(entity));
    }

    [SwaggerOperation(Summary = "[Authorize] Get Role")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromForm] RoleCreateRequest request)
    {
        // TODO : pass cancellation token
        if (await _jwtRoleCheckerHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newRole = new Role
        {
            RoleName = request.RoleName,
            Status = request.Status
        };

        var validation = await _validator.ValidateParams(newRole, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Roles.AddRole(newRole);
        if (result == null)
            return NotFound("Role failed to create");

        return Ok(_mapper.Map<RoleDto>(result));
    }

    [SwaggerOperation(Summary = "[Authorize] Update Role info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut]
    public async Task<IActionResult> UpdateRole(int id, [FromForm] RoleUpdateRequest role)
    {
        if (await _jwtRoleCheckerHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateRole = new Role
        {
            RoleId = id,
            RoleName = role.RoleName,
            Status = role.Status
        };

        var validation = await _validator.ValidateParams(updateRole, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Roles.UpdateRole(updateRole);
        if (result == null)
            return NotFound("Updating role failed");

        return Ok("Role updated successfully");
    }
}
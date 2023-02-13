using AutoMapper;
using Domain.EntitiesDTO.UniversityDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.University;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/universities")]
[ApiController]
public class UniversitiesController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IUniversityValidator _validator;

    public UniversitiesController(IMapper mapper, IServiceWrapper serviceWrapper, ApplicationContext context,
        IJwtRoleCheckerHelper jwtRoleCheckHelper, IUniversityValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Universities
    [Authorize(Roles = "SuperAdmin, Admin, Employee, Renter, Supervisor")]
    [HttpGet]
    [SwaggerOperation(Summary = "[Authorize] Get university list")]
    public async Task<IActionResult> GetUniversity([FromQuery] UniversityFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<UniversityFilter>(request);

        var list = await _serviceWrapper.Universities.GetUniversityList(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "University list is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<UniversityDto>>(list);

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
                message = "University list is empty",
                data = ""
            });
    }

    // GET: api/Universities/5
    [Authorize(Roles = "SuperAdmin, Admin, Employee, Renter, Supervisor")]
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "[Authorize] Get university by id")]
    public async Task<IActionResult> GetUniversity(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Universities.GetUniversityById(id);

        return entity == null
            ? NotFound("University not found")
            : Ok(new
            {
                status = "Success",
                message = "University found",
                data = _mapper.Map<UniversityDto>(entity)
            });
    }

    // PUT: api/Universities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "[Authorize] Update university")]
    public async Task<IActionResult> PutUniversity(int id, UniversityUpdateRequest university)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateUniversity = new University
        {
            UniversityId = id,
            UniversityName = university.UniversityName ?? string.Empty,
            Description = university.Description ?? string.Empty,
            Address = university.Address ?? string.Empty,
            Status = university.Status ?? string.Empty
        };

        var validation = await _validator.ValidateParams(updateUniversity, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Universities.UpdateUniversity(updateUniversity);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "University not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "University updated",
            data = _mapper.Map<UniversityDto>(result)
        });
    }

    // POST: api/Universities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    [SwaggerOperation(Summary = "[Authorize] Create university")]
    public async Task<IActionResult> PostUniversity([FromBody] UniversityCreateRequest university)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var addNewUniversity = new University
        {
            UniversityName = university.UniversityName,
            Description = university.Description,
            Address = university.Address,
            Status = university.Status
        };

        var validation = await _validator.ValidateParams(addNewUniversity, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Universities.AddUniversity(addNewUniversity);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "University failed to create",
                data = ""
            });
        return CreatedAtAction("GetUniversity", new { id = result.UniversityId }, result);
    }

    // DELETE: api/Universities/5
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "[Authorize] Delete university")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");
        var result = await _serviceWrapper.Universities.DeleteUniversity(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "University not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "University deleted",
            data = ""
        });
    }
}
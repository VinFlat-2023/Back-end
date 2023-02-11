using AutoMapper;
using Domain.EntitiesDTO.MajorDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Major;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/majors")]
[ApiController]
public class MajorsController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IMajorValidator _validator;

    public MajorsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IJwtRoleCheckerHelper jwtRoleCheckHelper, IMajorValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Majors
    [Authorize(Roles = "SuperAdmin, Admin, Renter, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get major list")]
    [HttpGet]
    public async Task<IActionResult> GetMajors([FromQuery] MajorFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<MajorFilter>(request);

        var list = await _serviceWrapper.Majors.GetMajorList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No major available");

        var resultList = _mapper.Map<IEnumerable<MajorDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Major list is empty");
    }

    // GET: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Get all majors by university id")]
    [Authorize(Roles = "SuperAdmin, Admin, Renter, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMajor(int id)
    {
        var result = await _serviceWrapper.Majors.GetMajorListByUniversity(id);
        if (!result.Any())
            return NotFound("No major available for this university");

        return Ok(new
        {
            status = "Success",
            message = "Major list found",
            data = _mapper.Map<IEnumerable<MajorDto>>(result)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Create Major")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostMajor([FromForm] MajorCreateRequest major)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var addNewMajor = new Major
        {
            Name = major.Name,
            UniversityId = major.UniversityId
        };

        var validation = await _validator.ValidateParams(addNewMajor, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Majors.AddMajor(addNewMajor);

        if (result == null)
            return BadRequest("Major failed to add");

        return CreatedAtAction("GetMajor", new { id = result.MajorId }, result);
    }

    // PUT: api/Majors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Major info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMajor(int id, [FromForm] MajorUpdateRequest major)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateMajor = new Major
        {
            MajorId = id,
            Name = major.Name,
            UniversityId = major.UniversityId
        };

        var validation = await _validator.ValidateParams(updateMajor, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Majors.UpdateMajor(updateMajor);
        if (result == null)
            return NotFound("Updating major failed");

        return Ok($"Major updated at : {DateTime.Now.ToShortDateString()}");
    }

    // DELETE: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Remove Major")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMajor(int id)
    {
        var result = await _serviceWrapper.Majors.DeleteMajor(id);
        if (!result)
            return NotFound("Deleting major failed");

        return Ok($"Major deleted at : {DateTime.Now.ToShortDateString()}");
    }
}
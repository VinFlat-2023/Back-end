using AutoMapper;
using Domain.EntitiesDTO.MajorDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Major;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/majors")]
[ApiController]
public class MajorsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IMajorValidator _validator;

    public MajorsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IMajorValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
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
            return NotFound(new
            {
                status = "Not Found",
                message = "Major list is empty",
                data = ""
            });
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
            : NotFound(new
            {
                status = "Not Found",
                message = "Major list is empty",
                data = ""
            });
    }

    // GET: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Get all majors by university id")]
    [Authorize(Roles = "SuperAdmin, Admin, Renter, Supervisor")]
    [HttpGet("university/{id:int}")]
    public async Task<IActionResult> GetMajor(int id)
    {
        var result = await _serviceWrapper.Majors.GetMajorListByUniversity(id);
        if (!result.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Major list in this university is empty",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Major list found",
            data = _mapper.Map<IEnumerable<MajorDto>>(result)
        });
    }
    
    // GET: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Get major using id")]
    [Authorize(Roles = "SuperAdmin, Admin, Renter, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMajorDetail(int id)
    {
        var result = await _serviceWrapper.Majors.GetMajorById(id);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Major list in this university is empty",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Major list found",
            data = _mapper.Map<MajorDto>(result)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Create Major")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> PostMajor([FromBody] MajorCreateRequest major)
    {
        var addNewMajor = new Major
        {
            Name = major.Name,
            UniversityId = major.UniversityId
        };

        var validation = await _validator.ValidateParams(addNewMajor, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Majors.AddMajor(addNewMajor);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Major failed to create",
                data = ""
            });
        return CreatedAtAction("GetMajor", new { id = result.MajorId }, result);
    }

    // PUT: api/Majors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Major info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMajor(int id, [FromBody] MajorUpdateRequest major)
    {
        var updateMajor = new Major
        {
            MajorId = id,
            Name = major.Name,
            UniversityId = major.UniversityId
        };

        var validation = await _validator.ValidateParams(updateMajor, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Majors.UpdateMajor(updateMajor);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Updating major failed",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Major updated",
            data = ""
        });
    }

    // DELETE: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Remove Major")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMajor(int id)
    {
        var result = await _serviceWrapper.Majors.DeleteMajor(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Major failed to delete",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Major deleted",
            data = ""
        });
    }
}
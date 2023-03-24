using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.University;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.UniversityEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/universities")]
[ApiController]
public class UniversitiesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IUniversityValidator _validator;

    public UniversitiesController(IMapper mapper, IServiceWrapper serviceWrapper,
        IUniversityValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Universities
    [Authorize(Roles = "SuperAdmin, Admin, Renter, Supervisor")]
    [HttpGet]
    [SwaggerOperation(Summary =
        "[Authorize] Get university list with pagination and filter (For management and renter)")]
    public async Task<IActionResult> GetUniversity([FromQuery] UniversityFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<UniversityFilter>(request);

        var list = await _serviceWrapper.Universities.GetUniversityList(filter, token);

        var resultList = _mapper.Map<IEnumerable<UniversityDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "University list is empty",
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

    // GET: api/Universities/5
    [Authorize(Roles = "SuperAdmin, Admin, Renter, Supervisor")]
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "[Authorize] Get university by id (For management and renter)")]
    public async Task<IActionResult> GetUniversity(int id)
    {
        var entity = await _serviceWrapper.Universities.GetUniversityById(id);

        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "University not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "University found",
                data = _mapper.Map<UniversityDetailEntity>(entity)
            });
    }

    // PUT: api/Universities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "[Authorize] Update university by id (For management)")]
    public async Task<IActionResult> PutUniversity(int id, UniversityUpdateRequest university)
    {
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
            data = _mapper.Map<UniversityDetailEntity>(result)
        });
    }

    // POST: api/Universities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost]
    [SwaggerOperation(Summary = "[Authorize] Create university (For management)")]
    public async Task<IActionResult> PostUniversity([FromBody] UniversityCreateRequest university)
    {
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
        return Ok(new
        {
            status = "Success",
            message = "University created",
            data = ""
        });
    }

    // DELETE: api/Universities/5
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "[Authorize] Delete university by id (For management)")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
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
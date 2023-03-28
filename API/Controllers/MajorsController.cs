using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Major;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.MajorEntity;
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
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get major list with pagination and filter (For management)")]
    [HttpGet]
    public async Task<IActionResult> GetMajors([FromQuery] MajorFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<MajorFilter>(request);

        var list = await _serviceWrapper.Majors.GetMajorList(filter, token);

        var resultList = _mapper.Map<IEnumerable<MajorDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Major list is empty",
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

    // GET: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Get all majors by university id (For management and renter)")]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
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
            data = _mapper.Map<IEnumerable<MajorDetailEntity>>(result)
        });
    }

    // GET: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Get major using id (For management and renter)")]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
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
            data = _mapper.Map<MajorDetailEntity>(result)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Create major (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
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
        return Ok(new
        {
            status = "Success",
            message = "Major created",
            data = ""
        });
    }

    // PUT: api/Majors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update major info (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
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

    // DELETE: api/Majors/5
    [SwaggerOperation(Summary = "[Authorize] Remove major (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMajor(int id)
    {
        var result = await _serviceWrapper.Majors.DeleteMajor(id);
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
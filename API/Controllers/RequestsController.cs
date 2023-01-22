using AutoMapper;
using Domain.EntitiesDTO.RequestDTO;
using Domain.EntitiesDTO.RequestTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Request;
using Domain.EntityRequest.RequestType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/requests")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    private readonly IRequestValidator _validator;

    // GET: api/Requests
    public RequestsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IJwtRoleCheckerHelper jwtRoleCheckHelper, IRequestValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    [HttpGet]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get request list")]
    public async Task<IActionResult> GetRequests([FromQuery] RequestFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<RequestFilter>(request);

        var list = await _serviceWrapper.Requests.GetRequestList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No request available");

        var resultList = _mapper.Map<IEnumerable<RequestDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Request list is not initialized");
    }

    // GET: api/Requests/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get request by id")]
    public async Task<IActionResult> GetRequest(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Requests.GetRequestById(id);
        if (entity == null)
            return NotFound("No requests found");
        return Ok(_mapper.Map<RequestDto>(entity));
    }

    // PUT: api/Requests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update request (Not finished yet !!!)")]
    public async Task<IActionResult> PutRequest(int id, [FromForm] RequestUpdateRequest request)
    {
        /*
        var requestEntity = (await _serviceWrapper.Requests.GetRequestById(id));

        if (requestEntity == null)
            return NotFound("No requests found");

        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, requestEntity.Value))
            return BadRequest("You are not authorized to access this information");

        var updateRequest = new Request
        {
            RequestId = id,
            RequestName = request.RequestName ?? null,
            RequestTypeId = request.RequestTypeId ?? null,
            Description = request.Description ?? null,
            CreateDate = DateTime.UtcNow,
            Status = request.Status,
            // TODO : Auto assign to active invoice -> invoice detail if not assigned manually
            SolveDate = request.SolveDate ?? null,
            Amount = request.Amount ?? 0
        };

        var validation = await _validator.ValidateParams(updateRequest, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Requests.UpdateRequest(updateRequest);
        if (result == null)
            return NotFound("Request failed to update");
        */
        return Ok("Request updated");
    }


    // POST: api/Requests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Create request")]
    public async Task<IActionResult> PostRequest([FromForm] RequestCreateRequest request)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newRequest = new Request
        {
            RequestName = request.RequestName,
            Description = request.Description,
            CreateDate = DateTime.UtcNow,
            RequestTypeId = request.RequestTypeId,
            Status = request.Status,
            // TODO : Auto assign to active invoice -> invoice detail if not assigned manually
            SolveDate = request.SolveDate ?? null,
            Amount = request.Amount ?? 0
        };

        var validation = await _validator.ValidateParams(newRequest, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Requests.AddRequest(newRequest);
        if (result == null)
            return BadRequest("Request failed to create");
        return CreatedAtAction("GetRequest", new { id = result.RequestId }, result);
    }

    // DELETE: api/Requests/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete request (Not finished yet !!!)")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        /*777
        var requestEntity = (await _serviceWrapper.Requests.GetRequestById(id))
            ?.Invoices.FirstOrDefault()?.Renter?.RenterId;

        if (requestEntity == null)
            return NotFound("No requests found");

        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, requestEntity.Value))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Requests.DeleteRequest(id);
        if (!result)
            return NotFound("Request not found");
            
        */
        return Ok("Request deleted");
    }

    // GET: api/RequestTypes
    [HttpGet("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get request list")]
    public async Task<IActionResult> GetRequestTypes([FromQuery] RequestTypeFilter request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<RequestTypeFilter>(request);

        var list = await _serviceWrapper.RequestTypes.GetRequestTypeList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No request type available");

        var resultList = _mapper.Map<IEnumerable<RequestTypeDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Request type list is not initialized");
    }

    // GET: api/RequestTypes/5
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get request type by id")]
    public async Task<IActionResult> GetRequestType(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.RequestTypes.GetRequestTypeById(id);
        if (entity == null)
            return NotFound("No request type found");
        return Ok(_mapper.Map<RequestTypeDto>(entity));
    }

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update request type")]
    public async Task<IActionResult> PutRequestType(int id, [FromForm] RequestTypeCreateRequest requestType)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateRequestType = new RequestType
        {
            RequestTypeId = id,
            Description = requestType.Description,
            Name = requestType.Name,
            Status = true
        };

        var validation = await _validator.ValidateParams(updateRequestType, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.RequestTypes
            .UpdateRequestType(updateRequestType);
        if (result == null)
            return NotFound("Request type not found");

        return Ok("Request type updated successfully");
    }

    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("type/")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Create request type")]
    public async Task<IActionResult> PostRequestType([FromForm] RequestTypeCreateRequest requestType)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newRequestType = new RequestType
        {
            Description = requestType.Description,
            Name = requestType.Name,
            Status = true
        };

        var validation = await _validator.ValidateParams(newRequestType, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.RequestTypes.AddRequestType(newRequestType);
        if (result == null)
            return NotFound("Request type not found");
        return CreatedAtAction("GetRequestType", new { id = result.RequestTypeId }, result);
    }

    // DELETE: api/RequestTypes/5
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete request type")]
    public async Task<IActionResult> DeleteRequestType(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.RequestTypes.DeleteRequestType(id);
        if (!result)
            return NotFound("Request type not found");

        return Ok("Request type deleted");
    }
}
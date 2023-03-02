using AutoMapper;
using Domain.EntitiesDTO.TicketDTO;
using Domain.EntitiesDTO.TicketTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Ticket;
using Domain.EntityRequest.TicketType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/tickets")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly ITicketValidator _validator;

    // GET: api/Requests
    public TicketsController(IMapper mapper, IServiceWrapper serviceWrapper,
        ITicketValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpGet]
    //[Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket list")]
    public async Task<IActionResult> GetTickets([FromQuery] TicketFilterRequest ticketFilterRequest,
        CancellationToken token)
    {
        var filter = _mapper.Map<TicketFilter>(ticketFilterRequest);

        var list = await _serviceWrapper.Tickets.GetTicketList(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Ticket list is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<TicketDto>>(list);

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
                message = "Ticket list is empty",
                data = ""
            });
    }

    // GET: api/Requests/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket by id")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var entity = await _serviceWrapper.Tickets.GetTicketById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Ticket not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Ticket found",
                data = _mapper.Map<TicketDto>(entity)
            });
    }

    // PUT: api/Requests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
   // [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update ticket (Not finished yet !!!)/n date format d/M/YYYY")]
    public async Task<IActionResult> PutTicket(int id, [FromBody] TicketUpdateRequest ticketUpdateRequest)
    {
        /*
        var requestEntity = (await _serviceWrapper.Requests.GetRequestById(id));

        if (requestEntity == null)
            return NotFound("No requests found");

        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, requestEntity.Value))
            return BadRequest("You are not authorized to access this information");

        var updateRequest = new Request
        {
            TicketId = id,
            TicketName = request.TicketName ?? null,
            TicketTypeId = request.TicketTypeId ?? null,
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

        var result = await _serviceWrapper.Requests.UpdateTicket(updateRequest);
        if (result == null)
            return NotFound("Request failed to update");
        return Ok("Request updated");
        */
        var updateTicket = _mapper.Map<Ticket>(ticketUpdateRequest);
        return Ok(new { ticket = updateTicket, date1 = updateTicket.CreateDate.ToString("dd MMM yyyy") });
    }


    // POST: api/Requests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Create ticket")]
    public async Task<IActionResult> PostTicket([FromBody] TicketCreateRequest ticketCreateRequest)
    {
        var newRequest = new Ticket
        {
            TicketName = ticketCreateRequest.TicketName,
            Description = ticketCreateRequest.Description,
            CreateDate = DateTime.UtcNow,
            TicketTypeId = ticketCreateRequest.TicketTypeId,
            Status = ticketCreateRequest.Status,
            // TODO : Auto assign to active invoice -> invoice detail if not assigned manually
            SolveDate = ticketCreateRequest.SolveDate ?? null,
            Amount = ticketCreateRequest.Amount ?? 0
        };

        var validation = await _validator.ValidateParams(newRequest, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Tickets.AddTicket(newRequest);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Request failed to create",
                data = ""
            });

        return CreatedAtAction("GetTicket", new { id = result.TicketId }, result);
    }

    // DELETE: api/Requests/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete ticket (Not finished yet !!!)")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        /*777
        var requestEntity = (await _serviceWrapper.Requests.GetRequestById(id))
            ?.Invoices.FirstOrDefault()?.Renter?.RenterId;

        if (requestEntity == null)
            return NotFound("No requests found");

        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, requestEntity.Value))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Requests.DeleteTicket(id);
        if (!result)
            return NotFound("Request not found");
            
        */
        return Ok("Request deleted");
    }

    // GET: api/RequestTypes
    [HttpGet("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket list")]
    public async Task<IActionResult> GetTIcketTypes([FromQuery] TicketTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<TicketTypeFilter>(request);

        var list = await _serviceWrapper.TicketTypes.GetTicketTypeList(filter, token);

        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "List not found",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<TicketTypeDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest(new
            {
                status = "Bad Request",
                message = "List not found",
                data = ""
            });
    }

    // GET: api/RequestTypes/5
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket type by id")]
    public async Task<IActionResult> GetTicketType(int id)
    {
        var entity = await _serviceWrapper.TicketTypes.GetTicketTypeById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Ticket type not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Ticket type found",
                data = _mapper.Map<TicketTypeDto>(entity)
            });
    }

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update ticket type")]
    public async Task<IActionResult> PutTicketType(int id,
        [FromBody] TicketTypeCreateRequest ticketTypeCreateRequestType)
    {
        var updateRequestType = new TicketType
        {
            TicketTypeId = id,
            Description = ticketTypeCreateRequestType.Description,
            TicketTypeName = ticketTypeCreateRequestType.Name,
            Status = true
        };

        var validation = await _validator.ValidateParams(updateRequestType, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.TicketTypes
            .UpdateTicketType(updateRequestType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Request type not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Request type updated",
            data = _mapper.Map<TicketTypeDto>(result)
        });
    }

    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("type/")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Create ticket type")]
    public async Task<IActionResult> PostTicketType([FromBody] TicketTypeCreateRequest ticketTypeCreateRequestType)
    {
        var newRequestType = new TicketType
        {
            Description = ticketTypeCreateRequestType.Description,
            TicketTypeName = ticketTypeCreateRequestType.Name,
            Status = true
        };

        var validation = await _validator.ValidateParams(newRequestType, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.TicketTypes.AddTicketType(newRequestType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Request type not found",
                data = ""
            });
        return CreatedAtAction("GetTicketType", new { id = result.TicketTypeId }, result);
    }

    // DELETE: api/RequestTypes/5
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete ticket type")]
    public async Task<IActionResult> DeleteTicketType(int id)
    {
        var result = await _serviceWrapper.TicketTypes.DeleteTicketType(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Request type not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Request type deleted",
            data = ""
        });
    }
}
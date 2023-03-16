using System.Security.Claims;
using AutoMapper;
using Domain.EntitiesDTO.TicketDTO;
using Domain.EntitiesDTO.TicketTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Ticket;
using Domain.EntityRequest.TicketType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
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
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket list with pagination and filter (For management and renter))")]
    public async Task<IActionResult> GetTickets([FromQuery] TicketFilterRequest ticketFilterRequest,
        CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var filter = _mapper.Map<TicketFilter>(ticketFilterRequest);

        var list = await _serviceWrapper.Tickets.GetTicketList(filter, token);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Ticket list is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<TicketDto>>(list);

        switch (userRole)
        {
            case "Admin":
                return Ok(new
                {
                    status = "Success",
                    message = "List found",
                    data = resultList,
                    totalPage = list.TotalPages,
                    totalCount = list.TotalCount
                });
            case "Supervisor":
                var supervisorId = int.Parse(User.Identity?.Name);

                // TODO : searching based on renter ID for management
                var supervisorTicketCheck =
                    await _serviceWrapper.Tickets.GetTicketList(filter, supervisorId, true, token);

                if (supervisorTicketCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No ticket list found for this management",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "List found",
                    data = supervisorTicketCheck,
                    totalPage = supervisorTicketCheck.TotalPages,
                    totalCount = supervisorTicketCheck.TotalCount
                });

            case "Renter":
                var renterId = int.Parse(User.Identity?.Name);

                var renterTicketCheck =
                    await _serviceWrapper.Tickets.GetTicketList(filter, renterId, false, token);

                if (renterTicketCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No ticket list found with this renter",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "List found",
                    data = renterTicketCheck,
                    totalPage = renterTicketCheck.TotalPages,
                    totalCount = renterTicketCheck.TotalCount
                });

            case null:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "No ticket found or no renter found",
                    data = ""
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request with ticket controller !!!",
            data = ""
        });
    }

    // GET: api/Requests/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket by id (For management and renter)")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var entity = await _serviceWrapper.Tickets.GetTicketById(id);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No ticket found",
                data = ""
            });

        /*

        if (userRole is not ("Admin" or "Supervisor") || (User.Identity?.Name != id.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });

        */

        switch (userRole)
        {
            case "Admin" or "Supervisor":
                return Ok(new
                {
                    status = "Success",
                    message = "Ticket found",
                    data = entity
                });

            case "Renter" when User.Identity?.Name == entity.Contract.RenterId.ToString():
                var renterTicketCheck = await _serviceWrapper.Tickets.GetTicketById(id, entity.Contract.RenterId);

                if (renterTicketCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No ticket with this id found with this user",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "Ticket found",
                    data = entity
                });
            case null:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "No ticket found or no renter found",
                    data = ""
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request !!!",
            data = ""
        });
    }

    // PUT: api/Requests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update ticket by id (For management)",
        Description = "date format d/M/YYYY")]
    public async Task<IActionResult> PutTicket(int id, [FromBody] TicketUpdateRequest ticketUpdateRequest)
    {
        var ticketEntity = await _serviceWrapper.Tickets.GetTicketById(id);

        if (ticketEntity == null)
            return NotFound("No requests found");

        var updateTicket = new Ticket
        {
            TicketId = id,
            TicketName = ticketUpdateRequest.TicketName ?? ticketEntity.TicketName,
            Description = ticketUpdateRequest.Description ?? ticketEntity.Description,
            TicketTypeId = ticketUpdateRequest.TicketTypeId ?? ticketEntity.TicketTypeId,
            Status = ticketUpdateRequest.Status ?? "Active",
            Amount = ticketUpdateRequest.Amount ?? ticketEntity.Amount ?? 0,
            SolveDate = ticketUpdateRequest.SolveDate.ConvertToDateTime() ?? ticketEntity.SolveDate
        };

        var validation = await _validator.ValidateParams(updateTicket, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Tickets.UpdateTicket(updateTicket);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Ticket failed to update",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Ticket updated successfully",
            data = ""
        });
    }


    // POST: api/Requests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Create ticket (For renter)", Description = "date format d/M/YYYY")]
    public async Task<IActionResult> PostTicket([FromBody] TicketCreateRequest ticketCreateRequest)
    {
        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "User not found",
                data = ""
            });

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnRenter(userId);

        if (buildingId == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        var managementAccountId = await _serviceWrapper.GetId.GetAccountIdBasedOnBuildingId(buildingId);
        if (managementAccountId == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Management account not found",
                data = ""
            });

        var contractId = await _serviceWrapper.GetId.GetContractIdBasedOnRenterId(userId);
        if (contractId == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found for this renter, please contact management",
                data = ""
            });

        var newTicket = new Ticket
        {
            TicketName = ticketCreateRequest.TicketName,
            Description = ticketCreateRequest.Description,
            CreateDate = DateTime.UtcNow,
            TicketTypeId = ticketCreateRequest.TicketTypeId,
            // TODO : Auto assign to active invoice -> invoice detail if not assigned manually
            Status = "Active",
            Amount = 0,
            ContractId = contractId.Value,
            AccountId = managementAccountId.Value
        };

        var validation = await _validator.ValidateParams(newTicket, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Tickets.AddTicket(newTicket);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Ticket failed to create",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Ticket created successfully",
            data = ""
        });
    }

    // DELETE: api/Requests/5
    [HttpDelete("{id:int}/user/{userId:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Delete ticket by id (For management and renter)")]
    public async Task<IActionResult> DeleteTicket(int id, int userId)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        if (userRole is not ("Admin" or "Supervisor") || (User.Identity?.Name != id.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(userId);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "User not found",
                data = ""
            });

        // pass renter Id and ticket Id to get, management can bypass restriction bound by token id
        var ticketEntity = await _serviceWrapper.Tickets.GetTicketById(id, userId);

        if (ticketEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Ticket not found",
                data = ""
            });

        var result = await _serviceWrapper.Tickets.DeleteTicket(id);
        if (!result)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Ticket failed to delete",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Ticket deleted successfully",
            data = ""
        });
    }

    // GET: api/RequestTypes
    [HttpGet("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket type list (For management and renter)")]
    public async Task<IActionResult> GetTicketTypes([FromQuery] TicketTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<TicketTypeFilter>(request);

        var list = await _serviceWrapper.TicketTypes.GetTicketTypeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<TicketTypeDto>>(list);

        return list != null && !list.Any()
            ? NotFound(new
            {
                status = "Not Found",
                message = "List not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            });
    }

    // GET: api/RequestTypes/5
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket type by id (For management and renter)")]
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

    /*

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update ticket type by id (For management)")]
    public async Task<IActionResult> PutTicketType(int id,
        [FromBody] TicketTypeUpdateRequest ticketTypeUpdateRequestType)
    {
        var updateRequestType = new TicketType
        {
            TicketTypeId = id,
            Description = ticketTypeUpdateRequestType.Description,
            TicketTypeName = ticketTypeUpdateRequestType.Name,
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
    
    */

    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("type/")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Create ticket type (For management)")]
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
    [SwaggerOperation(Summary = "[Authorize] Delete ticket type by id (For management)")]
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
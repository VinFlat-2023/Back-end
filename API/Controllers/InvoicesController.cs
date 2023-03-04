using System.Security.Claims;
using AutoMapper;
using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.InvoiceTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/invoices")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IInvoiceValidator _validator;

    // GET: api/Invoices
    public InvoicesController(IMapper mapper, IServiceWrapper serviceWrapper,
        IInvoiceValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice list")]
    [HttpGet]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoices([FromQuery] InvoiceFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<InvoiceFilter>(request);

        var list = await _serviceWrapper.Invoices.GetInvoiceList(filter, token);

        var resultList = _mapper.Map<IEnumerable<InvoiceDto>>(list);

        return list != null && !list.Any()
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
                status = "Bad Request",
                message = "List is empty",
                data = ""
            });
    }

    // GET: api/Invoices/5
    [SwaggerOperation(Summary = "[Authorize] Get Invoice by management")]
    [HttpGet("{id:int}/user")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceByManagement(int id)
    {
        var entity = await _serviceWrapper.Invoices.GetInvoiceById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No invoice found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Invoice found",
            data = _mapper.Map<InvoiceDto>(entity)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice list by renter ID")]
    [HttpGet("user/{userId:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetInvoiceRenter(int userId, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        if (userRole is not ("Admin" or "Supervisor") ||
            (User.Identity?.Name != userId.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);
        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var entities = await _serviceWrapper.Invoices
            .GetInvoiceList(new InvoiceFilter { RenterId = userId }, token);

        var resultList = _mapper.Map<IEnumerable<InvoiceDto>>(entities);

        return entities != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = entities.TotalPages,
                totalCount = entities.TotalCount
            })
            : NotFound(new
            {
                status = "Not Found",
                message = "No invoice list found",
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice by renter for renter usage")]
    [HttpGet("{invoiceId:int}/user/{userId:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetInvoiceRenterUsingId(int invoiceId, int userId)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        if (userRole is not ("Admin" or "Supervisor") ||
            (User.Identity?.Name != userId.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var entity = await _serviceWrapper.Invoices.GetInvoiceByRenterAndInvoiceId(userId, invoiceId);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No invoice found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Invoice found",
            data = _mapper.Map<InvoiceDto>(entity)
        });
    }

    // PUT: api/Invoices/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Invoice info")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> PutInvoice(int id, [FromBody] InvoiceUpdateRequest invoice)
    {
        var updateInvoice = new Invoice
        {
            InvoiceId = id,
            Name = invoice.Name,
            Status = invoice.Status,
            DueDate = invoice.DueDate,
            Detail = invoice.Detail,
            ImageUrl = invoice.ImageUrl,
            PaymentTime = null,
            CreatedTime = DateTime.UtcNow,
            AccountId = invoice.AccountId,
            RenterId = invoice.RenterId,
            InvoiceTypeId = invoice.InvoiceTypeId
        };

        var validation = await _validator.ValidateParams(updateInvoice, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Invoices.UpdateInvoice(updateInvoice);

        if (result == null)
            return NotFound("Invoice failed to update");
        return Ok("Invoice updated");
    }

    // POST: api/Invoices
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Invoice")]
    [HttpPost]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> PostInvoice([FromBody] InvoiceCreateRequest invoice)
    {
        var addNewInvoice = new Invoice
        {
            Name = invoice.Name,
            ImageUrl = invoice.ImageUrl,
            Detail = invoice.Detail,
            AccountId = int.Parse(User.Identity.Name),
            RenterId = invoice.RenterId,
            InvoiceTypeId = invoice.InvoiceTypeId
        };

        var validation = await _validator.ValidateParams(addNewInvoice, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Invoices.AddInvoice(addNewInvoice);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Invoice failed to create",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Invoice created",
            data = ""
        });
    }

    // DELETE: api/Invoices/5
    [SwaggerOperation(Summary = "[Authorize] Delete Invoice")]
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var result = await _serviceWrapper.Invoices.DeleteInvoice(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Invoice failed to delete",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Invoice deleted",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice type")]
    [HttpGet("types")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceTypes([FromQuery] InvoiceTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<InvoiceTypeFilter>(request);

        var list = await _serviceWrapper.InvoiceTypes.GetInvoiceTypes(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Invoice type list is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<InvoiceTypeDto>>(list);

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
                message = "Invoice type list is empty",
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice type by id")]
    [HttpGet("types/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var entity = await _serviceWrapper.InvoiceTypes.GetInvoiceTypeById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoice type not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoice type found",
                data = _mapper.Map<InvoiceTypeDto>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create Invoice")]
    [HttpPost("types")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> CreateNewInvoiceType([FromBody] InvoiceTypeCreateRequest invoiceType)
    {
        var newInvoiceType = new InvoiceType
        {
            Status = invoiceType.Status,
            InvoiceTypeName = invoiceType.InvoiceTypeName
        };

        var validation = await _validator.ValidateParams(newInvoiceType, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.InvoiceTypes.AddInvoiceType(newInvoiceType);
        return result == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoice type failed to create",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoice type created",
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Update Invoice")]
    [HttpPut("types/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> UpdateInvoiceType(int id, [FromBody] InvoiceTypeUpdateRequest invoiceType)
    {
        var updateInvoiceType = new InvoiceType
        {
            InvoiceTypeId = id,
            Status = invoiceType.Status,
            InvoiceTypeName = invoiceType.InvoiceTypeName
        };

        var validation = await _validator.ValidateParams(updateInvoiceType, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.InvoiceTypes.UpdateInvoiceType(updateInvoiceType);
        return result == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoice type failed to update",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoice type updated",
                data = _mapper.Map<InvoiceTypeDto>(result)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Delete invoice type")]
    [HttpDelete("types/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> DeleteInvoiceType(int id)
    {
        var result = await _serviceWrapper.InvoiceTypes.DeleteInvoiceType(id);
        return !result
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoice type failed to delete",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoice type deleted",
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Delete invoice detail")]
    [HttpDelete("details/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> DeleteInvoiceDetail(int id)
    {
        var result = await _serviceWrapper.InvoiceDetails.DeleteInvoiceDetail(id);
        return !result
            ? NotFound("Invoice detail failed to delete")
            : Ok("Invoice detail deleted successfully");
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice detail")]
    [HttpGet("details")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetails([FromQuery] InvoiceDetailFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<InvoiceDetailFilter>(request);

        var list = await _serviceWrapper.InvoiceDetails.GetInvoiceDetails(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Success",
                message = "List found",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<InvoiceTypeDto>>(list);

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
                message = "Invoice detail list is empty",
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice detail by id")]
    [HttpGet("details/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailById(int id)
    {
        var entity = await _serviceWrapper.InvoiceDetails.GetInvoiceDetailById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoice detail not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoice detail found",
                data = _mapper.Map<InvoiceDto>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice detail by user id with true")]
    [HttpGet("details/user/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailListByUserId(int id, CancellationToken token)
    {
        var result = await _serviceWrapper.InvoiceDetails
            .GetInvoiceDetailListByUserId(id, token);

        return !result.Any()
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoice detail list not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoice detail found",
                data = _mapper.Map<InvoiceDto>(result)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice detail by user id with true")]
    [HttpGet("details/user/{id:int}/active")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailByUserId(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.InvoiceDetails
            .GetActiveInvoiceDetailByUserId(id, token);

        return entity == null
            ? NotFound("Invoice detail with active status by this user not found")
            : Ok(new
            {
                status = "Success",
                message = "Invoice detail found",
                data = _mapper.Map<InvoiceDto>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create Invoice based on renter")]
    [HttpPost("create")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> CreateManyInvoice([FromBody] List<MassInvoiceCreateRequest> invoices)
    {
        var result = await _serviceWrapper.Invoices.BatchInsertInvoice(invoices);
        return !result
            ? NotFound(new
            {
                status = "Not Found",
                message = "Invoices failed to create",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Invoices created successfully",
                data = ""
            });
    }

    private static int DateRemainingCheck(DateTime start, DateTime end)
    {
        return (start.Date - end.Date).Days + 1;
    }

    private static decimal CalculateBillAmount(Invoice? invoice)
    {
        if (invoice == null)
            return -1;
        //var dateStart = invoice.Contract.StartDate;
        //var dateEnd = invoice.Renter.Contract.EndDate;
        //var dateCheck = DateRemainingCheck(dateStart, dateEnd);
        //switch (dateCheck)
        //{
        // TODO : Add more cases
        //}

        return 0;
    }
}
using AutoMapper;
using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.InvoiceTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceDetail;
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

        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "List is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<InvoiceDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Account list is empty");
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

    [SwaggerOperation(Summary = "[Authorize] Get Invoice by renter")]
    [HttpGet("user/{userId:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetInvoiceRenter(int userId, CancellationToken token)
    {
        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);
        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });
        var entity = await _serviceWrapper.Invoices
            .GetInvoiceList(new InvoiceFilter { RenterId = userId }, token);

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
    
    [SwaggerOperation(Summary = "[Authorize] Get Invoice by renter")]
    [HttpGet("{id:int}/user/{userId:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetInvoiceRenterUsingId(int id, int userId, CancellationToken token)
    {
        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);
        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });
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

    // PUT: api/Invoices/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Invoice info")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> PutInvoice(int id, [FromForm] InvoiceUpdateRequest invoice)
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
    public async Task<IActionResult> PostInvoice([FromForm] InvoiceCreateRequest invoice)
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
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Invoices.AddInvoice(addNewInvoice);
        if (result == null)
            return NotFound("Invoice not found");

        return Ok("Invoice created successfully");
    }

    // DELETE: api/Invoices/5
    [SwaggerOperation(Summary = "[Authorize] Delete Invoice")]
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var result = await _serviceWrapper.Invoices.DeleteInvoice(id);
        if (!result)
            return NotFound("Invoice not found");

        return Ok("Invoice deleted");
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

    [SwaggerOperation(Summary = "[Authorize] Get Invoice by id")]
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
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.InvoiceTypes.AddInvoiceType(newInvoiceType);
        return result == null
            ? NotFound("Invoice type failed to create")
            : Ok("Invoice type created successfully");
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
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.InvoiceTypes.UpdateInvoiceType(updateInvoiceType);
        return result == null
            ? NotFound("Invoice type not found")
            : Ok(_mapper.Map<InvoiceTypeDto>(result));
    }

    [SwaggerOperation(Summary = "[Authorize] Delete invoice type")]
    [HttpDelete("types/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> DeleteInvoiceType(int id)
    {
        var result = await _serviceWrapper.InvoiceTypes.DeleteInvoiceType(id);
        return !result
            ? NotFound("Invoice type failed to delete")
            : Ok("Invoice type deleted successfully");
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
            : BadRequest("Invoice type is empty");
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice detail by id")]
    [HttpGet("details/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailById(int id)
    {
        var entity = await _serviceWrapper.InvoiceDetails.GetInvoiceDetailById(id);
        return entity == null
            ? NotFound("Invoice detail not found")
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
        var result = await _serviceWrapper.InvoiceDetails.GetInvoiceDetailListByUserId(id, token);
        return !result.Any()
            ? NotFound("Invoice detail list by this user not found")
            : Ok(_mapper.Map<InvoiceDto>(result));
    }

    [SwaggerOperation(Summary = "[Authorize] Get Invoice detail by user id with true")]
    [HttpGet("details/user/{id:int}/active")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailByUserId(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.InvoiceDetails.GetActiveInvoiceDetailByUserId(id, token);
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
    [HttpPut("create")]
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

    [SwaggerOperation(Summary = "[Authorize] Update Invoice detail")]
    [HttpPut("details/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> UpdateInvoiceDetail(int id, [FromBody] InvoiceDetailCreateRequest invoiceDetail)
    {
        return Ok("On development");
    }

    private static int DateRemainingCheck(DateTime start, DateTime end)
    {
        return (start.Date - end.Date).Days + 1;
    }

    private static double CalculateBillAmount(Invoice? invoice)
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
using System.Security.Claims;
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.InvoiceEntity;
using Domain.ViewModel.InvoiceTypeEntity;
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

    [SwaggerOperation(Summary = "[Authorize] Get invoice list (For management)")]
    [Authorize(Roles = "Renter, Supervisor")]
    [HttpGet]
    // [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetInvoices([FromQuery] InvoiceFilterRequest request, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var userId = int.Parse(User.Identity.Name);

        var filter = _mapper.Map<InvoiceFilter>(request);

        switch (userRole)
        {
            case "Supervisor":
                var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);

                switch (buildingId)
                {
                    case -1:
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Quản lí này hiện đang không quản lí toà nhà nào",
                            data = -1
                        });
                    case -2:
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                            data = -2
                        });
                }

                var supervisorList = await _serviceWrapper.Invoices.GetInvoiceList(filter, buildingId, true, token);

                if (supervisorList == null || !supervisorList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Danh sách hoá đơn trống",
                        data = ""
                    });

                var resultSupervisorList = _mapper.Map<IEnumerable<InvoiceRenterDetailEntity>>(supervisorList);

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = resultSupervisorList,
                    totalPage = supervisorList.TotalPages,
                    totalCount = supervisorList.TotalCount
                });
            case "Renter":
                var renterList = await _serviceWrapper.Invoices.GetInvoiceList(filter, userId, false, token);

                if (renterList == null || !renterList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Danh sách hoá đơn trống",
                        data = ""
                    });

                var resulRenterList = _mapper.Map<IEnumerable<InvoiceRenterDetailEntity>>(renterList);

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = resulRenterList,
                    totalPage = renterList.TotalPages,
                    totalCount = renterList.TotalCount
                });
            case null:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "No user logged in",
                    data = ""
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request with invoice controller !!!",
            data = ""
        });
    }

    // GET: api/Invoices/5
    [SwaggerOperation(Summary = "[Authorize] Get invoice by Id (For management)")]
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> GetInvoiceByManagement(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Invoices.GetInvoiceById(id, token);

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
            data = _mapper.Map<InvoiceRenterDetailEntity>(entity)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get latest invoice by renter")]
    [HttpGet("latest")]
    [Authorize(Roles = "Renter")]
    public async Task<IActionResult> GetLatestInvoiceByRenter(CancellationToken token)
    {
        var renterId = int.Parse(User.Identity.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(renterId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "User not found",
                data = ""
            });

        var invoiceId = await _serviceWrapper.Invoices.GetLatestUnpaidInvoiceByRenter(renterId, token);

        if (invoiceId == 0)
            return NotFound(new
            {
                status = "Not Found",
                message = "Invoice not found for this user",
                data = ""
            });

        var invoice = await _serviceWrapper.Invoices.GetInvoiceById(invoiceId, token);

        if (invoice == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Invoice not found for this user",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Invoice found",
            data = _mapper.Map<InvoiceRenterDetailEntity>(invoice)
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice list by renter Id (For management)")]
    [HttpGet("user/{userId:int}")]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> GetInvoiceRenter(int userId, CancellationToken token)
    {
        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var list = await _serviceWrapper.Invoices
            .GetInvoiceList(new InvoiceFilter { RenterId = userId }, token);

        var resultList = _mapper.Map<IEnumerable<InvoiceRenterDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Hiển thị danh sách",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get all invoice list by renter (For renter)")]
    [HttpGet("user/all")]
    [Authorize(Roles = "Renter")]
    public async Task<IActionResult> GetInvoiceRenter(CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var list = await _serviceWrapper.Invoices
            .GetInvoiceList(new InvoiceFilter { RenterId = userId }, token);

        var resultList = _mapper.Map<IEnumerable<InvoiceRenterDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Hiển thị danh sách",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice list by renter Id (For renter and management)")]
    [HttpGet("user/current/status/{status:bool}")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetInvoiceListRenterWithStatus([FromQuery] bool status, CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);
        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var list = await _serviceWrapper.Invoices
            .GetInvoiceList(new InvoiceFilter { RenterId = userId, Status = status }, token);

        // false = paid, true = unpaid

        var resultList = _mapper.Map<IEnumerable<InvoiceRenterDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Hiển thị danh sách",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }


    [SwaggerOperation(Summary = "[Authorize] Get invoice using invoice Id (For renter)")]
    [HttpGet("{invoiceId:int}/user")]
    [Authorize(Roles = "Renter")]
    public async Task<IActionResult> GetInvoiceRenterUsingId(int invoiceId, CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var entity = await _serviceWrapper.Invoices.GetInvoiceByRenterAndInvoiceId(userId, invoiceId, token);

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
            data = _mapper.Map<InvoiceRenterDetailEntity>(entity)
        });
    }

    // PUT: api/Invoices/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Invoice info (For management)",
        Description = "date format d/M/YYYY")]
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> PutInvoice(int id, [FromBody] InvoiceUpdateRequest invoice,
        CancellationToken token)
    {
        /*
        var validation = await _validator.ValidateParams(invoice, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

*/
        var updateInvoice = new Invoice
        {
            InvoiceId = id,
            Name = invoice.Name,
            Status = invoice.Status,
            DueDate = invoice.DueDate,
            Detail = invoice.Detail,
            PaymentTime = invoice.PaymentTime ?? null
        };

        var result = await _serviceWrapper.Invoices.UpdateInvoice(updateInvoice);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad request",
                message = "Invoice failed to update",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Invoice updated",
            data = ""
        });
    }

    // POST: api/Invoices
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Invoice (For management)", Description = "date format d/M/YYYY")]
    [HttpPost]
    [Authorize(Roles = "Supervisor")]
    public async Task<IActionResult> PostInvoice([FromBody] InvoiceCreateRequest invoice, CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        if (employeeId == 0)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Nhân viên không tồn tại",
                data = ""
            });
        
        var buildingForCurrentSupervisor =
            await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

        switch (buildingForCurrentSupervisor)
        {
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                    data = ""
                });
            case -1:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Người quản lý không quản lý tòa nhà nào",
                    data = ""
                });
        }


        /*
        var validation = await _validator.ValidateParams(invoice, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
            */

        var addNewInvoice = new Invoice
        {
            Name = invoice.Name,
            Status = true,
            DueDate = invoice.DueDate ?? null,
            Detail = invoice.Detail,
            PaymentTime = null,
            CreatedTime = DateTime.UtcNow,
            InvoiceTypeId = invoice.InvoiceTypeId,
            EmployeeId = employeeId,
            BuildingId = buildingForCurrentSupervisor,
        };

        switch (addNewInvoice.InvoiceTypeId)
        {
            case 1:
                addNewInvoice.RenterId = invoice.RenterId;
                break;
            case 2:
                if (addNewInvoice.RenterId != null)
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "Hoá đơn với loại là phiếu thu thì không được gắn với người thuê",
                        data = ""
                    });
                break;
            default:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Hoá đơn với loại là phiếu thu thì không được gắn với người thuê",
                    data = ""
                });
        }

        var result = await _serviceWrapper.Invoices.AddInvoice(addNewInvoice);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Hoá đơn tạo thất bại",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hoá đơn được tạo thành công",
            data = ""
        });
    }

    // DELETE: api/Invoices/5
    [SwaggerOperation(Summary = "[Authorize] Delete invoice (For management)")]
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
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

    [SwaggerOperation(Summary = "[Authorize] Get invoice type list (For management)")]
    [HttpGet("types")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceTypes([FromQuery] InvoiceTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<InvoiceTypeFilter>(request);

        var list = await _serviceWrapper.InvoiceTypes.GetInvoiceTypes(filter, token);

        var resultList = _mapper.Map<IEnumerable<InvoiceTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Invoice type list is empty",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice type by id (For management)")]
    [HttpGet("types/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceTypeById(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.InvoiceTypes.GetInvoiceTypeById(id, token);

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
                data = _mapper.Map<InvoiceTypeDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create invoice type (For management)")]
    [HttpPost("types")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> CreateNewInvoiceType([FromBody] InvoiceTypeCreateRequest invoiceType,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(invoiceType, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newInvoiceType = new InvoiceType
        {
            Status = invoiceType.Status,
            InvoiceTypeName = invoiceType.InvoiceTypeName
        };

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

    [SwaggerOperation(Summary = "[Authorize] Update invoice type (For management)")]
    [HttpPut("types/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> UpdateInvoiceType(int id, [FromBody] InvoiceTypeUpdateRequest invoiceType,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(invoiceType, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateInvoiceType = new InvoiceType
        {
            InvoiceTypeId = id,
            Status = invoiceType.Status,
            InvoiceTypeName = invoiceType.InvoiceTypeName
        };


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
                data = ""
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Delete invoice type (For management)")]
    [HttpDelete("types/{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteInvoiceType(int id)
    {
        var result = await _serviceWrapper.InvoiceTypes.DeleteInvoiceType(id);
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

    [SwaggerOperation(Summary = "[Authorize] Delete invoice detail (For management)")]
    [HttpDelete("details/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> DeleteInvoiceDetail(int id)
    {
        var result = await _serviceWrapper.InvoiceDetails.DeleteInvoiceDetail(id);
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

    [SwaggerOperation(Summary = "[Authorize] Get invoice detail list (For management)")]
    [HttpGet("details")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetails([FromQuery] InvoiceDetailFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<InvoiceDetailFilter>(request);

        var list = await _serviceWrapper.InvoiceDetails.GetInvoiceDetails(filter, token);

        var resultList = _mapper.Map<IEnumerable<InvoiceDataDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Invoice detail list is empty",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice detail by id (For management)")]
    [HttpGet("details/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailById(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.InvoiceDetails.GetInvoiceDetailById(id, token);
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
                data = _mapper.Map<InvoiceDataDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice detail by user id with true (For management)")]
    [HttpGet("details/user/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
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
                data = _mapper.Map<InvoiceDataDetailEntity>(result)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Get invoice detail by user id with true (For management)")]
    [HttpGet("details/user/{id:int}/active")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetInvoiceDetailByUserId(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.InvoiceDetails
            .GetActiveInvoiceDetailByUserId(id, token);

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
                data = _mapper.Map<InvoiceDataDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create invoice based on list of renter id (For management)")]
    [HttpPost("create")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> CreateManyInvoice([FromBody] List<MassInvoiceCreateRequest> invoices)
    {
        var result = await _serviceWrapper.Invoices.BatchInsertInvoice(invoices);
        return result switch
        {
            { IsSuccess: false } => BadRequest(new { status = "Bad Request", message = result.Message, data = "" }),
            { IsSuccess: true } => Ok(new { status = "Success", message = result.Message, data = "" }),
            null => BadRequest(new { status = "Bad Request", message = "Invoice failed to create", data = "" })
        };
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
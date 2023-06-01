using System.Security.Claims;
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Service;
using Domain.EntityRequest.ServiceType;
using Domain.EnumEntities;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.ServiceEntity;
using Domain.ViewModel.ServiceTypeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IServiceValidator _validator;

    public ServiceController(IServiceWrapper serviceWrapper, IMapper mapper,
        IServiceValidator validator)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
        _validator = validator;
    }

    // GET: api/ServiceEntities
    [HttpGet]
    [Authorize(Roles = " Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service list with pagination and filter (For management and renter))")]
    public async Task<IActionResult> GetServiceEntities([FromQuery] ServiceFilterRequest request,
        CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var userId = User.Identity?.Name;

        var filter = _mapper.Map<ServiceEntityFilter>(request);

        switch (userRole)
        {
            case "Supervisor":
                var supervisorBuildingId =
                    await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(int.Parse(userId), token);
                switch (supervisorBuildingId)
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

                var supervisorServiceList = await _serviceWrapper.ServicesEntity
                    .GetServiceEntityList(filter, supervisorBuildingId, token);

                var supervisorServiceListReturn =
                    _mapper.Map<IEnumerable<ServiceDetailEntitySupervisor>>(supervisorServiceList);

                if (supervisorServiceList == null || !supervisorServiceList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Danh sách dịch vụ trống",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = supervisorServiceListReturn,
                    totalPage = supervisorServiceList.TotalPages,
                    totalCount = supervisorServiceList.TotalCount
                });

            case "Renter":
                var buildingId =
                    await _serviceWrapper.GetId.GetBuildingIdBasedOnRenterActiveContract(int.Parse(userId), token);

                var renterServiceList =
                    await _serviceWrapper.ServicesEntity.GetServiceEntityList(filter, buildingId, token);

                var renterServiceListReturn = _mapper.Map<IEnumerable<ServiceDetailEntity>>(renterServiceList);

                if (renterServiceList == null || !renterServiceList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Danh sách dịch vụ trống",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = renterServiceListReturn,
                    totalPage = renterServiceList.TotalPages,
                    totalCount = renterServiceList.TotalCount
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Lỗi hệ thống",
            data = ""
        });
    }

    [HttpGet("building/current")]
    [Authorize(Roles = " Supervisor, Renter")]
    [SwaggerOperation(Summary =
        "[Authorize] Get service list based on current user building id (For management and renter)")]
    public async Task<IActionResult> GetServiceEntitiesBasedOnRenterId([FromQuery] ServiceFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<ServiceEntityFilter>(request);

        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Người dùng không tồn tại",
                data = ""
            });

        var buildingId =
            await _serviceWrapper.GetId.GetBuildingIdBasedOnRenterActiveContract(userCheck.RenterId, token);

        var list = await _serviceWrapper.ServicesEntity.GetServiceEntityList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<ServiceDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Service list is empty",
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

    [HttpGet("building/{buildingId:int}")]
    [Authorize(Roles = " Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Get service list based on building id (For management)d)")]
    public async Task<IActionResult> GetServiceEntitiesByBuilding([FromQuery] ServiceFilterRequest request,
        int buildingId, CancellationToken token)
    {
        var filter = _mapper.Map<ServiceEntityFilter>(request);

        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà này không tồn tại trong hệ thống",
                data = ""
            });

        var list = await _serviceWrapper.ServicesEntity.GetServiceEntityList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<ServiceDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Service list in this building is empty",
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

    [HttpPut("select")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Select services to consume (For renter)")]
    public async Task<IActionResult> SelectServices(List<int> serviceIds, CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Người dùng không tồn tại",
                data = ""
            });

        var contractId = await _serviceWrapper.Contracts.GetLatestContractByUserId(userId, token);

        if (contractId == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Người dùng không có hợp đồng nào đang có hiệu lực",
                data = ""
            });

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnRenterActiveContract(userId, token);

        var building = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (building == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Toà nhà này không tồn tại trong hệ thống",
                data = ""
            });

        var invoiceId = await _serviceWrapper.Invoices.GetLatestUnpaidInvoiceByRenter(userId, token);

        if (invoiceId == 0)
        {
            var newInvoice = new Invoice
            {
                RenterId = userId,
                Name = "Hoá đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " của " +
                       userCheck.FullName,
                Status = InvoiceStatusEnum.unpaid.ToString(),
                CreatedTime = DateTime.Now,
                PaymentTime = null,
                Detail = "Chi tiết hoá đơn",
                ContractId = contractId.ContractId,
                EmployeeId = building.EmployeeId,
                InvoiceTypeId = 1,
                BuildingId = buildingId
            };

            await _serviceWrapper.Invoices.AddInvoice(newInvoice);

            var newFetchInvoice = await _serviceWrapper.Invoices.GetLatestUnpaidInvoiceByRenter(userId, token);

            var invoiceEntity =
                await _serviceWrapper.Invoices.AddServiceToLastInvoice(newFetchInvoice, serviceIds, token);

            return invoiceEntity switch
            {
                { IsSuccess: true } => Ok(new
                {
                    status = "Success", message = invoiceEntity.Message, data = ""
                }),
                { IsSuccess: false } => BadRequest(new
                {
                    status = "Bad Request", message = invoiceEntity.Message, data = ""
                }),
                null => NotFound(new
                {
                    status = "Not Found", message = "Hoá đơn không tồn tại ", data = ""
                })
            };
        }
        else
        {
            var invoiceEntity = await _serviceWrapper.Invoices.AddServiceToLastInvoice(invoiceId, serviceIds, token);

            return invoiceEntity switch
            {
                { IsSuccess: true } => Ok(new
                {
                    status = "Success", message = invoiceEntity.Message, data = ""
                }),
                { IsSuccess: false } => BadRequest(new
                {
                    status = "Bad Request", message = invoiceEntity.Message, data = ""
                }),
                null => NotFound(new
                {
                    status = "Not Found", message = "Hoá đơn không tồn tại ", data = ""
                })
            };
        }
    }

    // GET: api/ServiceEntitys/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = " Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service by id (For management and renter)")]
    public async Task<IActionResult> GetServiceEntity(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.ServicesEntity.GetServiceEntityById(id, token);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Dịch vụ không tồn tại",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Hiện thị dịch vụ",
                data = _mapper.Map<ServiceDetailEntity>(entity)
            });
    }

    // PUT: api/ServiceEntitys/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = " Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update service by id (For management)")]
    public async Task<IActionResult> PutServiceEntity(int id, [FromBody] ServiceUpdateRequest service,
        CancellationToken token)
    {
        var managementId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(managementId, token);

        switch (buildingId)
        {
            case -1:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang không quản lí toà nhà nào",
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Quản lí này hiện đang quản lí hơn 1 toà nhà",
                    data = ""
                });
        }

        var validation = await _validator.ValidateParams(service, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateService = new ServiceEntity
        {
            ServiceId = id,
            Name = service.Name,
            Description = service.Description,
            Status = service.Status,
            ServiceTypeId = service.ServiceTypeId,
            Price = service.Price,
            BuildingId = buildingId
        };

        var result = await _serviceWrapper.ServicesEntity.UpdateServiceEntity(updateService);

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

    // POST: api/ServiceEntitiess
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Add new service (For management)")]
    public async Task<IActionResult> PostServiceEntity([FromBody] ServiceCreateRequest service, CancellationToken token)
    {
        var managementId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(managementId, token);

        switch (buildingId)
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

        var validation = await _validator.ValidateParams(service, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newService = new ServiceEntity
        {
            Name = service.Name,
            Description = service.Description,
            Status = service.Status,
            ServiceTypeId = service.ServiceTypeId,
            Price = service.Price,
            BuildingId = buildingId
            // TODO : Auto get latest invoice detail ID with corresponding Invoice with active status
            // TODO : In invoice controller, auto generate invoice detail id
        };

        var result = await _serviceWrapper.ServicesEntity.AddServiceEntity(newService);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Hiện thị thông tin dịch vụ",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Tạo mới dịch vụ thành công",
            data = ""
        });
    }

    // DELETE: api/ServiceEntitys/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete service by id (For management)")]
    public async Task<IActionResult> DeleteServiceEntity(int id)
    {
        var result = await _serviceWrapper.ServicesEntity.DeleteServiceEntity(id);
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

    [HttpGet("type")]
    [Authorize(Roles = " Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service type list (For management and renter)")]
    public async Task<IActionResult> GetServiceTypes([FromQuery] ServiceTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<ServiceTypeFilter>(request);

        var list = await _serviceWrapper.ServiceTypes.GetServiceTypeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<ServiceTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Hiển thị danh sách loại dịch vụ",
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

    // GET: api/ServiceTypes/5
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = " Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service type by id (For management and renter)")]
    public async Task<IActionResult> GetServiceType(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.ServiceTypes.GetServiceTypeById(id, token);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Loại dịch vụ không tồn tại",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Hiển thị thông tin loại dịch vụ",
                data = _mapper.Map<ServiceTypeDetailEntity>(entity)
            });
    }

    // PUT: api/ServiceTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = " Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update service type by id (For management)")]
    public async Task<IActionResult> PutServiceType(int id, ServiceTypeCreateRequest serviceType,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(serviceType, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateServiceType = new ServiceType
        {
            ServiceTypeId = id,
            Name = serviceType.Name,
            Status = serviceType.Status
        };


        var result = await _serviceWrapper.ServiceTypes.UpdateServiceType(updateServiceType);
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

    // POST: api/ServiceTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("type")]
    [Authorize(Roles = " Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Add new service type (For management)")]
    public async Task<IActionResult> PostServiceType(ServiceTypeCreateRequest serviceType, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(serviceType, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });


        var addNewServiceType = new ServiceType
        {
            Name = serviceType.Name,
            Status = serviceType.Status
        };

        var result = await _serviceWrapper.ServiceTypes.AddServiceType(addNewServiceType);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Tạo mới loại dịch vụ thất bại",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Tạo mới thành công",
            data = ""
        });
    }

    // DELETE: api/ServiceTypes/5
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = " Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete service type by id (For management)")]
    public async Task<IActionResult> DeleteServiceType(int id)
    {
        var result = await _serviceWrapper.ServiceTypes.DeleteServiceType(id);
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
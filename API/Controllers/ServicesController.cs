﻿using AutoMapper;
using Domain.EntitiesDTO.ServiceDTO;
using Domain.EntitiesDTO.ServiceTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Service;
using Domain.EntityRequest.ServiceType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/services")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IServiceValidator _validator;

    public ServicesController(IServiceWrapper serviceWrapper, IMapper mapper,
        IServiceValidator validator)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
        _validator = validator;
    }

    // GET: api/ServiceEntities
    [HttpGet]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service list")]
    public async Task<IActionResult> GetServiceEntities([FromQuery] ServiceFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<ServiceEntityFilter>(request);

        var list = await _serviceWrapper.ServicesEntity.GetServiceEntityList(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Service list is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<ServiceEntityDto>>(list);

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
                message = "Service list is empty",
                data = ""
            });
    }

    [HttpGet("building/{buildingId:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service list based on building id")]
    public async Task<IActionResult> GetServiceEntitiesByBuilding([FromQuery] ServiceFilterRequest request,
        CancellationToken token, int buildingId)
    {
        var filter = _mapper.Map<ServiceEntityFilter>(request);

        var list = await _serviceWrapper.ServicesEntity.GetServiceEntityList(filter, buildingId, token);

        var resultList = _mapper.Map<IEnumerable<ServiceEntityDto>>(list);

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
                status = "Not Found",
                message = "Service list in this building is empty",
                data = ""
            });
    }

    // GET: api/ServiceEntitys/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service by id")]
    public async Task<IActionResult> GetServiceEntity(int id)
    {
        var entity = await _serviceWrapper.ServicesEntity.GetServiceEntityById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Service not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Service found",
                data = _mapper.Map<ServiceEntityDto>(entity)
            });
    }

    // PUT: api/ServiceEntitys/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update service by id")]
    public async Task<IActionResult> PutServiceEntity(int id, [FromBody] ServiceUpdateRequest service)
    {
        var updateService = new ServiceEntity
        {
            ServiceId = id,
            Name = service.Name,
            Description = service.Description,
            Status = service.Status,
            ServiceTypeId = service.ServiceTypeId,
            Amount = service.Amount ?? 0
            // TODO : Auto get latest invoice detail ID with corresponding Invoice with active status
            // TODO : In invoice controller, auto generate invoice detail id
        };

        var validation = await _validator.ValidateParams(updateService, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.ServicesEntity.UpdateServiceEntity(updateService);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Service not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Service updated",
            data = ""
        });
    }

    // POST: api/ServiceEntitiess
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Add new service")]
    public async Task<IActionResult> PostServiceEntity([FromBody] ServiceCreateRequest service)
    {
        var newService = new ServiceEntity
        {
            Name = service.Name,
            Description = service.Description,
            Status = service.Status,
            ServiceTypeId = service.ServiceTypeId,
            Amount = service.Amount ?? 0
            // TODO : Auto get latest invoice detail ID with corresponding Invoice with active status
            // TODO : In invoice controller, auto generate invoice detail id
        };

        var validation = await _validator.ValidateParams(newService, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.ServicesEntity.AddServiceEntity(newService);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Service not found",
                data = ""
            });

        return CreatedAtAction("GetServiceEntity", new { id = result.ServiceId }, result);
    }

    // DELETE: api/ServiceEntitys/5
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete service by id")]
    public async Task<IActionResult> DeleteServiceEntity(int id)
    {
        var result = await _serviceWrapper.ServicesEntity.DeleteServiceEntity(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Service not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Service deleted",
            data = ""
        });
    }

    [HttpGet("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service type list")]
    public async Task<IActionResult> GetServiceTypes([FromQuery] ServiceTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<ServiceTypeFilter>(request);

        var list = await _serviceWrapper.ServiceTypes.GetServiceTypeList(filter, token);
        if (list != null && !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Service type list is empty",
                data = ""
            });

        var resultList = _mapper.Map<IEnumerable<ServiceTypeDto>>(list);

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
                message = "Service type list is empty",
                data = ""
            });
    }

    // GET: api/ServiceTypes/5
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get service type by id")]
    public async Task<IActionResult> GetServiceType(int id)
    {
        var entity = await _serviceWrapper.ServiceTypes.GetServiceTypeById(id);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Service type not found",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Service type found",
                data = _mapper.Map<ServiceTypeDto>(entity)
            });
    }

    // PUT: api/ServiceTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update service type")]
    public async Task<IActionResult> PutServiceType(int id, ServiceTypeCreateRequest serviceType)
    {
        var updateServiceType = new ServiceType
        {
            ServiceTypeId = id,
            Name = serviceType.Name,
            Status = serviceType.Status
        };

        var validation = await _validator.ValidateParams(updateServiceType, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.ServiceTypes.UpdateServiceType(updateServiceType);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Service type failed to update",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Service type updated",
            data = ""
        });
    }

    // POST: api/ServiceTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Add new service type")]
    public async Task<IActionResult> PostServiceType(ServiceTypeCreateRequest serviceType)
    {
        var addNewServiceType = new ServiceType
        {
            Name = serviceType.Name,
            Status = serviceType.Status
        };

        var validation = await _validator.ValidateParams(addNewServiceType, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.ServiceTypes.AddServiceType(addNewServiceType);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Service type failed to create",
                data = ""
            });
        return CreatedAtAction("GetServiceType", new { id = result.ServiceTypeId }, result);
    }

    // DELETE: api/ServiceTypes/5
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete service type by id")]
    public async Task<IActionResult> DeleteServiceType(int id)
    {
        var result = await _serviceWrapper.ServiceTypes.DeleteServiceType(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Service type not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Service type deleted",
            data = ""
        });
    }
}
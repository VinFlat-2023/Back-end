using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Attribute;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.Attribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/attribute")]
[ApiController]
public class AttributeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IAttributeValidator _validator;

    public AttributeController(IMapper mapper, IServiceWrapper serviceWrapper, IAttributeValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "[Authorize] Get attribute numeric list")]
    [Authorize(Roles = "Admin, Supervisor")]
    public async Task<IActionResult> GetAttributes([FromQuery] AttributeForNumericFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<AttributeForNumericFilter>(request);

        var list = await _serviceWrapper.Attributes.GetAttributeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<AttributeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Attribute list is empty",
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

    [SwaggerOperation(Summary = "[Authorize] Get attribute by Id (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAttribute(int id)
    {
        var entity = await _serviceWrapper.Attributes.GetAttributeById(id);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Attribute not found",
                data = ""
            });
        return Ok(
            new
            {
                status = "Success",
                message = "Attribute found",
                data = _mapper.Map<AttributeDetailEntity>(entity)
            });
    }

    [SwaggerOperation(Summary = "[Authorize] Create a custom attribute (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost]
    public async Task<IActionResult> CreateAttribute([FromBody] AttributeCreateRequest attribute)
    {
        var newAttribute = new AttributeForNumeric
        {
            ElectricityAttribute = attribute.ElectricityAttribute,
            WaterAttribute = attribute.WaterAttribute
        };

        var validation = await _validator.ValidateParams(newAttribute, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Attributes.AddAttribute(newAttribute);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Attribute failed to create",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Attribute created successfully",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Update a custom attribute (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAttribute(int id, [FromBody] AttributeUpdateRequest attribute)
    {
        var updateAttribute = new AttributeForNumeric
        {
            AttributeForNumericId = id,
            ElectricityAttribute = attribute.ElectricityAttribute,
            WaterAttribute = attribute.WaterAttribute
        };

        var validation = await _validator.ValidateParams(updateAttribute, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Attributes.UpdateAttribute(updateAttribute);

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

    [SwaggerOperation(Summary = "[Authorize] Delete a custom attribute")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAttribute(int id)
    {
        var result = await _serviceWrapper.Attributes.DeleteAttribute(id);

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
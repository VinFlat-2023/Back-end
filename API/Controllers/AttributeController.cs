using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;


[Route("api/attribute")]
[ApiController]
public class AttributeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public AttributeController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }
    
}
﻿/*
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.FeedBack;
using Domain.EntityRequest.FeedbackType;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.ViewModel.FeedbackEntity;
using Domain.ViewModel.FeedbackTypeDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/feedbacks")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IFeedbackValidator _validator;

    public FeedbacksController(IMapper mapper, IServiceWrapper serviceWrapper,
        IFeedbackValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Feedbacks
    [SwaggerOperation(Summary = "[Authorize] Get Feedback List")]
    [Authorize(Roles = " Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetFeedbacks([FromQuery] FeedbackFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<FeedbackFilter>(request);

        var list = await _serviceWrapper.Feedbacks.GetFeedbackList(filter, token);

        var resultList = _mapper.Map<IEnumerable<FeedbackDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Hiển thị danh sách",
            resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/Feedbacks/5
    [SwaggerOperation(Summary = "[Authorize] Get Feedback")]
    [Authorize(Roles = " Supervisor, Renter")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFeedback(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Feedbacks.GetFeedbackById(id, token);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Feedback found",
            data = _mapper.Map<FeedbackDetailEntity>(entity)
        });
    }

    // PUT: api/Feedbacks/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Feedback info")]
    [Authorize(Roles = " Supervisor, Renter")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFeedback(int id, [FromBody] FeedbackUpdateRequest feedback,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(feedback, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateFeedback = new Feedback
        {
            FeedbackId = id,
            Description = feedback.Description,
            Status = feedback.Status,
            FeedbackTitle = feedback.FeedbackTitle,
            FeedbackTypeId = feedback.FeedbackTypeId,
            FlatId = feedback.FlatId,
            RenterId = feedback.RenterId
        };

        var result = await _serviceWrapper.Feedbacks.UpdateFeedback(updateFeedback);
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

    //TODO : get feedback from renter ID

    // POST: api/Feedbacks
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Feedback")]
    [Authorize(Roles = " Supervisor, Renter")]
    [HttpPost]
    public async Task<IActionResult> PostFeedback([FromBody] FeedbackCreateRequest feedback, CancellationToken token)
    {
        var validation = await _validator.ValidateParams(feedback, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var addNewFeedback = new Feedback
        {
            FeedbackTypeId = feedback.FeedbackTypeId,
            FeedbackTitle = feedback.FeedbackTitle,
            Description = feedback.Description,
            Status = feedback.Status,
            CreateDate = DateTime.UtcNow,
            FlatId = feedback.FlatId,
            RenterId = feedback.RenterId
        };


        var result = await _serviceWrapper.Feedbacks.AddFeedback(addNewFeedback);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Feedback created",
            data = ""
        });
    }

    // DELETE: api/Feedbacks/5
    [SwaggerOperation(Summary = "Remove Feedback")]
    [Authorize(Roles = " Supervisor, Renter")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
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

    [SwaggerOperation(Summary = "[Authorize] Get Feedback Type List")]
    [HttpGet("type")]
    [Authorize(Roles = "  Supervisor, Renter")]
    public async Task<IActionResult> GetFeedbackTypes([FromQuery] FeedbackTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<FeedbackTypeFilter>(request);

        var list = await _serviceWrapper.FeedbackTypes.GetFeedbackTypeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<FeedbackTypeDetailEntity>>(list);

        return list != null && !list.Any()
            ? NotFound(new
            {
                status = "Not Found",
                message = "No Feedback Type available",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Hiển thị danh sách",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            });
    }

    // GET: api/FeedbackTypes/5
    [SwaggerOperation(Summary = "[Authorize] GetFeedback Type")]
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "  Supervisor, Renter")]
    public async Task<IActionResult> GetFeedbackType(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.FeedbackTypes
            .GetFeedbackTypeById(id, token);
        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback type not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Feedback type found",
            data = _mapper.Map<FeedbackTypeDetailEntity>(entity)
        });
    }

    // PUT: api/FeedbackTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Feedback Type info")]
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "  Supervisor")]
    public async Task<IActionResult> PutFeedbackType(int id, [FromBody] FeedbackTypeUpdateRequest feedbackType,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(feedbackType, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateFeedBackType = new FeedbackType
        {
            FeedbackTypeId = id,
            Name = feedbackType.Name
        };

        var result = await _serviceWrapper.FeedbackTypes.UpdateFeedbackType(updateFeedBackType);
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

    // POST: api/FeedbackTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "Create Feedback Type")]
    [HttpPost("type")]
    [Authorize(Roles = "  Supervisor")]
    public async Task<IActionResult> PostFeedbackType([FromBody] FeedbackTypeCreateRequest feedbackType,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(feedbackType, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newFeedbackType = new FeedbackType
        {
            Name = feedbackType.Name
        };

        var result = await _serviceWrapper.FeedbackTypes.AddFeedbackType(newFeedbackType);

        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Feedback type failed to add",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Feedback type added",
            data = ""
        });
    }

    // DELETE: api/FeedbackTypes/5
    [SwaggerOperation(Summary = "Remove Feedback Type")]
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = "  Supervisor")]
    public async Task<IActionResult> DeleteFeedbackType(int id)
    {
        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
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
*/


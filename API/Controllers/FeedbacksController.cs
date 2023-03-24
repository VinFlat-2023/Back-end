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
    [Authorize(Roles = "Admin, Supervisor")]
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
            message = "List found",
            resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/Feedbacks/5
    [SwaggerOperation(Summary = "[Authorize] Get Feedback")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFeedback(int id)
    {
        var entity = await _serviceWrapper.Feedbacks.GetFeedbackById(id);
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
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFeedback(int id, [FromBody] FeedbackUpdateRequest feedback)
    {
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

        var validation = await _validator.ValidateParams(updateFeedback, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Feedbacks.UpdateFeedback(updateFeedback);
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
            message = "Feedback updated",
            data = ""
        });
    }

    //TODO : get feedback from renter ID

    // POST: api/Feedbacks
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Feedback")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpPost]
    public async Task<IActionResult> PostFeedback([FromBody] FeedbackCreateRequest feedback)
    {
        var addNewFeedback = new Feedback
        {
            FeedbackTypeId = feedback.FeedbackTypeId,
            FeedbackTitle = feedback.FeedbackTitle,
            Description = feedback.Description,
            Status = feedback.Status,
            CreateDate = DateTime.Now,
            FlatId = feedback.FlatId,
            RenterId = feedback.RenterId
        };

        var validation = await _validator.ValidateParams(addNewFeedback, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

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
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Feedback deleted",
            data = ""
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Feedback Type List")]
    [HttpGet("type")]
    [Authorize(Roles = " Admin, Supervisor, Renter")]
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
                message = "List found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            });
    }

    // GET: api/FeedbackTypes/5
    [SwaggerOperation(Summary = "[Authorize] GetFeedback Type")]
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = " Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFeedbackType(int id)
    {
        var entity = await _serviceWrapper.FeedbackTypes
            .GetFeedbackTypeById(id);
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
    [Authorize(Roles = " Admin, Supervisor")]
    public async Task<IActionResult> PutFeedbackType(int id, [FromBody] FeedbackTypeUpdateRequest feedbackType)
    {
        var updateFeedBackType = new FeedbackType
        {
            FeedbackTypeId = id,
            Name = feedbackType.Name
        };

        var validation = await _validator.ValidateParams(updateFeedBackType, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.FeedbackTypes.UpdateFeedbackType(updateFeedBackType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback type not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Feedback type updated",
            data = ""
        });
    }

    // POST: api/FeedbackTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "Create Feedback Type")]
    [HttpPost("type")]
    [Authorize(Roles = " Admin, Supervisor")]
    public async Task<IActionResult> PostFeedbackType([FromBody] FeedbackTypeCreateRequest feedbackType)
    {
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
    [Authorize(Roles = " Admin, Supervisor")]
    public async Task<IActionResult> DeleteFeedbackType(int id)
    {
        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Feedback type not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Feedback type deleted",
            data = ""
        });
    }
}
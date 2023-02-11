namespace API.Controllers;

/*
[Route("api/feedbacks")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IFeedbackValidator _validator;

    public FeedbacksController(IMapper mapper, IServiceWrapper serviceWrapper, IJwtRoleCheckerHelper jwtRoleCheckHelper,
        IFeedbackValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Feedbacks
    [SwaggerOperation(Summary = "[Authorize] Get Feedback List")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetFeedbacks([FromQuery] FeedbackFilterRequest request, CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<FeedbackFilter>(request);

        var list = await _serviceWrapper.Feedbacks.GetFeedbackList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No Feedback available");

        var resultList = _mapper.Map<IEnumerable<FeedbackDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Feedback list is empty");
    }

    // GET: api/Feedbacks/5
    [SwaggerOperation(Summary = "[Authorize] Get Feedback")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFeedback(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Feedbacks.GetFeedbackById(id);
        if (entity == null)
            return NotFound("Feedback not found");
        return Ok(_mapper.Map<FeedbackDto>(entity));
    }

    // PUT: api/Feedbacks/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Feedback info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFeedback(int id, [FromForm] FeedbackUpdateRequest feedback)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User, feedback.RenterId))
            return BadRequest("You are not authorized to access this information");

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
            return NotFound("Feedback not found");

        return Ok("Feedback updated");
    }

    //TODO : get feedback from renter ID

    // POST: api/Feedbacks
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Feedback")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpPost]
    public async Task<IActionResult> PostFeedback([FromForm] FeedbackCreateRequest feedback)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

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
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Feedbacks.AddFeedback(addNewFeedback);
        if (result == null)
            return BadRequest();

        return CreatedAtAction("GetFeedback", new { id = result.FeedbackId }, result);
    }

    // DELETE: api/Feedbacks/5
    [SwaggerOperation(Summary = "Remove Feedback")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
        if (!result)
            return NotFound("Feedback not found");

        return Ok("Feedback deleted");
    }

    [SwaggerOperation(Summary = "[Authorize] Get Feedback Type List")]
    [HttpGet("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFeedbackTypes([FromQuery] FeedbackTypeFilterRequest request,
        CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<FeedbackTypeFilter>(request);

        var list = await _serviceWrapper.FeedbackTypes.GetFeedbackTypeList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No Feedback type available");

        var resultList = _mapper.Map<IEnumerable<FeedbackTypeDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Feedback type list is empty");
    }

    // GET: api/FeedbackTypes/5
    [SwaggerOperation(Summary = "[Authorize] GetFeedback Type")]
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    public async Task<IActionResult> GetFeedbackType(int id)
    {
        if (await _jwtRoleCheckHelper.IsRenterRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.FeedbackTypes
            .GetFeedbackTypeById(id);
        if (entity == null)
            return NotFound("Feedback type not found");

        return Ok(_mapper.Map<FeedbackTypeDto>(entity));
    }

    // PUT: api/FeedbackTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Feedback Type info")]
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> PutFeedbackType(int id, [FromForm] FeedbackTypeUpdateRequest feedbackType)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateFeedBackType = new FeedbackType
        {
            FeedbackTypeId = id,
            Name = feedbackType.Name
        };

        var validation = await _validator.ValidateParams(updateFeedBackType, feedbackType.FeedbackTypeId);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.FeedbackTypes.UpdateFeedbackType(updateFeedBackType);
        if (result == null)
            return NotFound("Feedback type not found");
        return Ok("Feedback type updated");
    }

    // POST: api/FeedbackTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "Create Feedback Type")]
    [HttpPost("type")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> PostFeedbackType([FromForm] FeedbackTypeCreateRequest feedbackType)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var newFeedbackType = new FeedbackType
        {
            Name = feedbackType.Name
        };
        var result = await _serviceWrapper.FeedbackTypes.AddFeedbackType(newFeedbackType);
        if (result == null)
            return NotFound("Feedback type not found");
        return CreatedAtAction("GetFeedbackType", new { id = result.FeedbackTypeId }, result);
    }

    // DELETE: api/FeedbackTypes/5
    [SwaggerOperation(Summary = "Remove Feedback Type")]
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    public async Task<IActionResult> DeleteFeedbackType(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
        if (!result)
            return NotFound("Feedback type not found");
        return Ok("Feedback type deleted");
    }
}
*/
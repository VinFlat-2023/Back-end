using API.Extension;
using AutoMapper;
using Domain.EntitiesDTO.ContractDTO;
using Domain.EntitiesDTO.ContractHistoryDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Contract;
using Domain.EntityRequest.ContractHistory;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IHelper;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/contracts")]
[ApiController]
public class ContractsController : ControllerBase
{
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckHelper;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IContractValidator _validator;

    public ContractsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IJwtRoleCheckerHelper jwtRoleCheckHelper, IContractValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _jwtRoleCheckHelper = jwtRoleCheckHelper;
        _validator = validator;
    }

    // GET: api/Contract
    [SwaggerOperation(Summary = "Get Contract List")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetContracts([FromQuery] ContractFilterRequest request, CancellationToken token)
    {
        // TODO Add filter ? So It can get by renter ID too
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filter = _mapper.Map<ContractFilter>(request);

        var list = await _serviceWrapper.Contracts.GetContractList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No contract available");

        var resultList = _mapper.Map<IEnumerable<ContractDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Contract list is not initialized");
    }

    //TODO get contract by renter ID

    // GET: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Get Contract")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContract(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.Contracts.GetContractById(id);
        if (entity == null)
            return NotFound("Contract not found");
        return Ok(_mapper.Map<ContractDto>(entity));
    }

    // PUT: api/Contract/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Contract info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContract(int id, [FromForm] ContractUpdateRequest contract)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var updateContract = new Contract
        {
            ContractId = contract.ContractId,
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate ?? null,
            Description = contract.Description,
            LastUpdated = DateTime.UtcNow,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            Price = contract.Price,
            ContractStatus = contract.ContractStatus
        };

        var validation1 = await _validator.ValidateParams(updateContract, id);
        if (!validation1.IsValid)
            return BadRequest(validation1.Failures.FirstOrDefault());

        var result1 = await _serviceWrapper.Contracts.UpdateContract(updateContract);
        if (result1 == null)
            return BadRequest("Contract update failed");

        // Create another copy of contract history
        var addNewContractHistory = new ContractHistory
        {
            ContractId = result1.ContractId,
            Description = result1.Description,
            Price = result1.Price,
            ContractHistoryStatus = result1.ContractStatus,
            ContractExpiredDate = result1.EndDate
        };

        var validation2 = await _validator.ValidateParams(addNewContractHistory, null);
        if (!validation2.IsValid)
            return BadRequest(validation2.Failures.FirstOrDefault());

        var result2 = await _serviceWrapper.ContractHistories.AddContractHistory(addNewContractHistory);
        if (result2 == null)
            return BadRequest("Cannot add new contract history");

        return Ok("Contract updated");
    }

    // POST: api/Contract
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Contract")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost("sign")]
    public async Task<IActionResult> PostContract([FromForm] ContractCreateRequest contract)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var newContract = new Contract
        {
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus ?? "Active",
            Price = contract.Price,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            Description = contract.Description
            // TODO : get the current user id based on the token
        };

        var validation = await _validator.ValidateParams(newContract, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Contracts.AddContract(newContract);
        if (result == null)
            return NotFound();

        return CreatedAtAction("GetContract", new { id = result.ContractId }, result);
    }

    // DELETE: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Remove Contract")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.Contracts.DeleteContract(id);
        if (!result)
            return NotFound("Contract not found");

        return Ok("Contract deleted");
    }

    [SwaggerOperation(Summary = "Get Contract History")]
    [Authorize(Roles = "Admin, SuperAdmin, Supervisor")]
    [HttpGet("history")]
    public async Task<IActionResult> GetContractHistories([FromQuery] ContractHistoryFilterRequest request,
        CancellationToken token)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var filters = _mapper.Map<ContractHistoryFilter>(request);

        var list = await _serviceWrapper.ContractHistories.GetContractHistoryList(filters, token);
        if (list != null && !list.Any())
            return NotFound("No contract history available");

        var resultList = _mapper.Map<IEnumerable<ContractHistoryDto>>(list);

        return list != null
            ? Ok(new
            {
                resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Contract history list is not initialized");
    }

    // GET: api/ContractHistories/5
    [SwaggerOperation(Summary = "[Authorize] Get Contract History")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet("history/{id:int}")]
    public async Task<IActionResult> GetContractHistory(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var entity = await _serviceWrapper.ContractHistories.GetContractHistoryById(id);
        if (entity == null)
            return NotFound("Contract history not found");
        var dto = _mapper.Map<ContractHistoryDto>(entity);
        return Ok(dto);
    }

    // DELETE: api/ContractHistories/5
    [SwaggerOperation(Summary = "[Authorize] Remove Contract History")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpDelete("history/{id:int}")]
    public async Task<IActionResult> DeleteContractHistory(int id)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var result = await _serviceWrapper.ContractHistories.DeleteContractHistory(id);

        if (!result)
            return NotFound("Contract history not found");

        return Ok("Contract history deleted successfully");
    }

    // PUT: api/ContractHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Contract History info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("history/{id:int}")]
    public async Task<IActionResult> PutContractHistory(int id, [FromForm] ContractHistoryCreateRequest contractHistory)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var updateContract = new ContractHistory
        {
            ContractHistoryId = id,
            Description = contractHistory.Description,
            ContractHistoryStatus = contractHistory.ContractHistoryStatus,
            ContractExpiredDate = contractHistory.ContractExpiredDate,
            Price = contractHistory.Price
        };

        var validation = await _validator.ValidateParams(updateContract, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.ContractHistories.UpdateContractHistory(updateContract);
        if (result == null)
            return NotFound("Contract history not found");

        return Ok("Contract history updated successfully");
    }

    // POST: api/ContractHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Contract History")]
    [HttpPost("history")]
    public async Task<IActionResult> PostContractHistory(
        [FromForm] ContractHistoryCreateRequest contractHistory)
    {
        if (await _jwtRoleCheckHelper.IsManagementRoleAuthorized(User))
            return BadRequest("You are not authorized to access this information");

        var contractCheck = await _serviceWrapper.Contracts.GetContractById(contractHistory.ContractId);
        if (contractCheck == null)
            return NotFound("Contract not found");

        var addNewContractHistory = new ContractHistory
        {
            ContractId = contractHistory.ContractId,
            Description = contractHistory.Description,
            Price = contractHistory.Price,
            ContractHistoryStatus = contractHistory.ContractHistoryStatus,
            ContractExpiredDate = contractHistory.ContractExpiredDate
        };

        var validation = await _validator.ValidateParams(addNewContractHistory, null);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.ContractHistories.UpdateContractHistory(addNewContractHistory);
        if (result == null)
            return NotFound("Contract history not found");

        return CreatedAtAction("GetContractHistory", new { id = result.ContractHistoryId }, result);
    }
}
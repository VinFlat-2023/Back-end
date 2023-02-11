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
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly IContractValidator _validator;

    public ContractsController(IMapper mapper, IServiceWrapper serviceWrapper,
        IContractValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    // GET: api/Contract
    [SwaggerOperation(Summary = "Get Contract List")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetContracts([FromQuery] ContractFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<ContractFilter>(request);

        var list = await _serviceWrapper.Contracts.GetContractList(filter, token);
        if (list != null && !list.Any())
            return NotFound("No contract available");

        var resultList = _mapper.Map<IEnumerable<ContractDto>>(list);

        return list != null
            ? Ok(new
            {
                status = "Success",
                message = "Contract list found",
                data = resultList,
                totalPage = list.TotalPages,
                totalCount = list.TotalCount
            })
            : BadRequest("Contract list is empty");
    }

    //TODO get contract by renter ID

    // GET: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Get Contract")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor, Renter")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContract(int id)
    {
        var entity = await _serviceWrapper.Contracts.GetContractById(id);
        if (entity == null)
            return NotFound("Contract not found");
        return Ok(new
        {
            status = "Success",
            message = "Contract found",
            data = _mapper.Map<ContractDto>(entity)
        });
    }

    // PUT: api/Contract/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Contract info")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContract(int id, [FromForm] ContractUpdateRequest contract)
    {
        var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var contractEntity = await _serviceWrapper.Contracts.GetContractById(id);

        if (contractEntity == null)
            return NotFound("Contract not found");
        
        var updateContract = new Contract
        {
            ContractId = id,
            ContractName = contract.ContractName ?? "Contract for " + contractEntity.RenterId,
            DateSigned = contract.DateSigned ?? contractEntity.DateSigned,
            StartDate = contract.StartDate ?? contractEntity.StartDate,
            EndDate = contract.EndDate ?? contractEntity.EndDate,
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus ?? contractEntity.ContractStatus,
            Price = contract.Price ?? contractEntity.Price,
            RenterId = contractEntity.RenterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            //ImageUrl = contract.ImageUrl,
            Description = contract.Description ?? "No description"
        };

        var validation = await _validator.ValidateParams(updateContract, id);
        if (!validation.IsValid)
            return BadRequest(validation.Failures.FirstOrDefault());

        var result = await _serviceWrapper.Contracts.UpdateContract(updateContract);
        if (result == null)
            return BadRequest("Contract update failed");

        return Ok("Contract updated");
    }

    // POST: api/Contract
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Contract")]
    [Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [HttpPost("sign")]
    public async Task<IActionResult> PostContract([FromForm] ContractCreateRequest contract)
    {
        var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);
        
        var renterEntity = await _serviceWrapper.Renters.GetRenterById(contract.RenterId);

        if (renterEntity == null)
            return BadRequest("Renter not found");

        var newContract = new Contract
        {
            ContractName = contract.ContractName ?? "Contract for " + renterEntity.FullName,
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus ?? "Active",
            Price = contract.Price,
            RenterId = renterEntity.RenterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            //ImageUrl = contract.ImageUrl,
            Description = contract.Description ?? "No description"
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
        var result = await _serviceWrapper.Contracts.DeleteContract(id);
        if (!result)
            return NotFound("Contract not found");

        return Ok("Contract deleted");
    }
    
}
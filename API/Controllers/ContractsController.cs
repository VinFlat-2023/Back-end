using System.Security.Claims;
using API.Extension;
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Contract;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.ContractEntity;
using Domain.ViewModel.RenterEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;
using Utilities.Extensions;
using static System.Int32;

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
    [SwaggerOperation(Summary = "Get contract list (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet]
    public async Task<IActionResult> GetContracts([FromQuery] ContractFilterRequest request, CancellationToken token)
    {
        var filter = _mapper.Map<ContractFilter>(request);

        var list = await _serviceWrapper.Contracts.GetContractList(filter, token);

        var resultList = _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "No contract available",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract list found",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }
    //TODO get contract by renter ID

    // GET: api/Contract
    [SwaggerOperation(Summary = "Get contract list (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("renter")]
    public async Task<IActionResult> GetContractsByRenterId([FromQuery] ContractFilterRequest request,
        CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var filter = _mapper.Map<ContractFilter>(request);

        var list = await _serviceWrapper.Contracts.GetContractList(filter, renterId, token);

        var resultList = _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "No contract available",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract list found",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "Get active contract list (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("renter/active")]
    public async Task<IActionResult> GetActiveContractsByRenterId(CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var list = await _serviceWrapper.Contracts.GetContractList(new ContractFilter { ContractStatus = "Active" },
            renterId, token);

        var resultList = _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "No contract available",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract list found",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    [SwaggerOperation(Summary = "Get inactive contract list (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("renter/inactive")]
    public async Task<IActionResult> GetInactiveContractsByRenterId(CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var list = await _serviceWrapper.Contracts.GetContractList(new ContractFilter { ContractStatus = "Inactive" },
            renterId, token);

        var resultList = _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "No contract available",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract list found",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }

    // GET: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Get Contract using id (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContractManagement(int id)
    {
        var entity = await _serviceWrapper.Contracts.GetContractById(id);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract found",
            data = new ContractMeterDetailEntity
            {
                ContractId = entity.ContractId,
                ContractName = entity.ContractName,
                DateSigned = entity.DateSigned,
                StartDate = entity.StartDate,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                EndDate = entity.EndDate,
                LastUpdated = entity.LastUpdated,
                ContractStatus = entity.ContractStatus,
                ImageUrl = entity.ImageUrl,
                PriceForRent = entity.PriceForRent.DecimalToString(),
                PriceForService = entity.PriceForService.DecimalToString(),
                PriceForWater = entity.PriceForWater.DecimalToString(),
                PriceForElectricity = entity.PriceForElectricity.DecimalToString(),
                RoomId = entity.RoomId
            }
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Contract using contract id with renter id (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("{id:int}/user/{renterId:int}")]
    public async Task<IActionResult> GetContract(int id, int renterId)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var entity = await _serviceWrapper.Contracts.GetContractById(id);

        switch (entity)
        {
            case { } when userRole is "Renter" && entity.RenterId != Parse(User.Identity.Name):
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "You are not authorized to access this resource due to invalid renter ID",
                    data = ""
                });

            case { } when userRole is "Renter" && renterId != Parse(User.Identity.Name):
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "You are not authorized to access this resource due to invalid token",
                    data = ""
                });

            case { } when userRole != "Renter":
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "You are not authorized to access this resource",
                    data = ""
                });

            case null:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Contract not found",
                    data = ""
                });
            default:
                var building = await _serviceWrapper.Buildings.GetBuildingById(entity.BuildingId);
                var renter = await _serviceWrapper.Renters.GetRenterById(entity.RenterId);
                if (renter == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Renter not found",
                        data = ""
                    });

                if (building == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Building not found",
                        data = ""
                    });

                var buildingDetail = new BuildingContractDetailEntity
                {
                    BuildingName = building.BuildingName,
                    BuildingPhoneNumber = building.BuildingPhoneNumber
                };

                var contractDetailView = new ContractMeterDetailEntity
                {
                    ContractId = entity.ContractId,
                    ContractName = entity.ContractName,
                    DateSigned = entity.DateSigned,
                    StartDate = entity.StartDate,
                    CreatedDate = entity.CreatedDate,
                    Description = entity.Description,
                    EndDate = entity.EndDate,
                    LastUpdated = entity.LastUpdated,
                    ContractStatus = entity.ContractStatus,
                    ImageUrl = entity.ImageUrl,
                    PriceForRent = entity.PriceForRent.DecimalToString(),
                    PriceForService = entity.PriceForService.DecimalToString(),
                    PriceForWater = entity.PriceForWater.DecimalToString(),
                    PriceForElectricity = entity.PriceForElectricity.DecimalToString(),
                    RoomId = entity.RoomId
                };

                var contractViewModel = new ContractDetailEntity
                {
                    ContractMeterDetail = contractDetailView,
                    Building = buildingDetail,
                    Renter = _mapper.Map<RenterProfileEntity>(renter)
                };

                return Ok(new
                {
                    status = "Success",
                    message = "Contract found",
                    data = contractViewModel
                });
        }
    }

    [SwaggerOperation(Summary = "[Authorize] Get active contract based on user Id (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("user/{userId:int}/active")]
    public async Task<IActionResult> GetContractBasedOnUserId(int userId)
    {
        /*
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        if (userRole is not ("Admin" or "Supervisor") ||
            (User.Identity?.Name != userId.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });
        */

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var entity = await _serviceWrapper.Contracts.GetContractByUserId(userId);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No contract found for this user",
                data = ""
            });

        var contractEntity = await _serviceWrapper.Contracts.GetContractByIdWithActiveStatus(entity.ContractId);

        if (contractEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract found",
            data = new ContractMeterDetailEntity
            {
                ContractId = entity.ContractId,
                ContractName = entity.ContractName,
                DateSigned = entity.DateSigned,
                StartDate = entity.StartDate,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                EndDate = entity.EndDate,
                LastUpdated = entity.LastUpdated,
                ContractStatus = entity.ContractStatus,
                ImageUrl = entity.ImageUrl,
                PriceForRent = entity.PriceForRent.DecimalToString(),
                PriceForService = entity.PriceForService.DecimalToString(),
                PriceForWater = entity.PriceForWater.DecimalToString(),
                PriceForElectricity = entity.PriceForElectricity.DecimalToString(),
                //BuildingId = entity.BuildingId,
                RoomId = entity.RoomId
                //RenterId = entity.RenterId,
            }
        });
    }

    // PUT: api/Contract/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Contract info (For management)",
        Description = "date format d/M/YYYY")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContract(int id, [FromBody] ContractUpdateRequest contract)
    {
        var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var contractEntity = await _serviceWrapper.Contracts.GetContractById(id);

        if (contractEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });
        var updateContract = new Contract
        {
            ContractId = id,
            ContractName = contract.ContractName ?? "Contract for " + contractEntity.RenterId,
            DateSigned = contract.DateSigned.ConvertToDateTime() ?? contractEntity.DateSigned,
            StartDate = contract.StartDate.ConvertToDateTime() ?? contractEntity.StartDate,
            EndDate = contract.EndDate.ConvertToDateTime() ?? contractEntity.EndDate,
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus ?? contractEntity.ContractStatus,
            PriceForRent = contract.PriceForRent ?? contractEntity.PriceForRent,
            PriceForElectricity = contract.PriceForElectricity ?? contractEntity.PriceForElectricity,
            PriceForWater = contract.PriceForWater ?? contractEntity.PriceForWater,
            PriceForService = contract.PriceForService ?? contractEntity.PriceForService,
            RenterId = contractEntity.RenterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            Description = contract.Description ?? "No description",
            CreatedDate = contractEntity.CreatedDate
        };

        var validation = await _validator.ValidateParams(updateContract, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });
        var result = await _serviceWrapper.Contracts.UpdateContract(updateContract);
        if (result == null)
            return BadRequest(new
            {
                status = "Not Found",
                message = "Contract failed to update",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Contract updated",
            data = ""
        });
    }

    // POST: api/Contract
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Contract (For management)", Description = "date format d/M/YYYY")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPost("sign")]
    public async Task<IActionResult> PostContract([FromBody] ContractCreateRequest contract)
    {
        var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var renterEntity = await _serviceWrapper.Renters.GetRenterById(contract.RenterId);

        if (renterEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renter not found",
                data = ""
            });
        var newContract = new Contract
        {
            ContractName = contract.ContractName ?? "Contract for " + renterEntity.FullName,
            DateSigned = contract.DateSigned.ConvertToDateTime() ?? DateTimeUtils.GetCurrentDateTime(),
            StartDate = contract.StartDate.ConvertToDateTime() ?? DateTimeUtils.GetCurrentDateTime(),
            EndDate = contract.EndDate.ConvertToDateTime(),
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus ?? "Active",
            CreatedDate = DateTime.UtcNow,
            PriceForRent = contract.PriceForRent,
            PriceForElectricity = contract.PriceForElectricity,
            PriceForWater = contract.PriceForWater,
            PriceForService = contract.PriceForService,
            RenterId = renterEntity.RenterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            //ImageUrl = contract.ImageUrl,
            Description = contract.Description ?? "No description"
        };

        var validation = await _validator.ValidateParams(newContract, null);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.Contracts.AddContract(newContract);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract failed to create",
                data = ""
            });
        return CreatedAtAction("GetContract", new { id = result.ContractId }, result);
    }

    // DELETE: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Remove contract (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        var result = await _serviceWrapper.Contracts.DeleteContract(id);
        if (!result)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });
        return Ok(new
        {
            status = "Success",
            message = "Contract deleted",
            data = ""
        });
    }
}
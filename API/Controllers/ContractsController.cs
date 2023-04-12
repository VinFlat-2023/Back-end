using System.Globalization;
using System.Security.Claims;
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
    [SwaggerOperation(Summary = "Get contract list using query (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet]
    public async Task<IActionResult> GetContracts([FromQuery] ContractFilterRequest request, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var filter = _mapper.Map<ContractFilter>(request);

        switch (userRole)
        {
            case "Admin":
                var adminContractList = await _serviceWrapper.Contracts.GetContractList(filter, token);

                if (adminContractList == null || !adminContractList.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No contract available",
                        data = ""
                    });

                var adminContractListReturn = _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(adminContractList);

                return Ok(new
                {
                    status = "Success",
                    message = "Contract list found",
                    data = adminContractListReturn,
                    totalPage = adminContractList.TotalPages,
                    totalCount = adminContractList.TotalCount
                });

            case "Supervisor":
                var supervisorId = Parse(User.Identity?.Name);

                var supervisorContractList =
                    await _serviceWrapper.Contracts.GetContractList(filter, supervisorId, true, token);

                var supervisorContractListReturn =
                    _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(supervisorContractList);

                if (supervisorContractList == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No contract found for this building managed by this supervisor",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "Contract list found",
                    data = supervisorContractListReturn,
                    totalPage = supervisorContractList.TotalPages,
                    totalCount = supervisorContractList.TotalCount
                });

            case "Renter":
                var renterId = Parse(User.Identity?.Name);

                var renterContractList =
                    await _serviceWrapper.Contracts.GetContractList(filter, renterId, false, token);

                var renterContractListReturn = _mapper.Map<IEnumerable<ContractBasicDetailEntity>>(renterContractList);

                if (renterContractList == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No contract found for this renter",
                        data = ""
                    });

                return Ok(new
                {
                    status = "Success",
                    message = "Contract list found",
                    data = renterContractListReturn,
                    totalPage = renterContractList.TotalPages,
                    totalCount = renterContractList.TotalCount
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Something went wrong",
            data = ""
        });
    }
    //TODO get contract by renter ID

    // GET: api/Contract
    [SwaggerOperation(Summary = "Get all contract list of logged in renter (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("renter")]
    public async Task<IActionResult> GetContractsByRenterId(CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var list = await _serviceWrapper.Contracts.GetContractList(new ContractFilter
        {
            RenterId = renterId
        }, token);

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

    [SwaggerOperation(Summary = "Get all contract list of logged in renter (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("latest/renter/current")]
    public async Task<IActionResult> GetFirstContractsByRenter(CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var latestContract = await _serviceWrapper.Contracts.GetLatestContractByUserId(renterId, token);

        return Ok(new
        {
            status = "Success",
            message = "Contract list found",
            data = _mapper.Map<ContractBasicDetailEntity>(latestContract)
        });
    }


    [SwaggerOperation(Summary = "Get active contract list of logged in renter (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("renter/active")]
    public async Task<IActionResult> GetActiveContractsByRenter(CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var list = await _serviceWrapper.Contracts.GetContractList(new ContractFilter
            {
                ContractStatus = "Active",
                RenterId = renterId
            },
            token);

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

    [SwaggerOperation(Summary = "Get inactive contract list of logged in renter (For renter)")]
    [Authorize(Roles = "Renter")]
    [HttpGet("renter/inactive")]
    public async Task<IActionResult> GetInactiveContractsByRenter(CancellationToken token)
    {
        var renterId = Parse(User.Identity?.Name);

        var list = await _serviceWrapper.Contracts.GetContractList(new ContractFilter
        {
            ContractStatus = "Inactive",
            RenterId = renterId
        }, token);

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
    [Authorize(Roles = "Supervisor")]
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
                PriceForElectricity = entity.PriceForElectricity.DecimalToString()
            }
        });
    }

    [SwaggerOperation(Summary = "[Authorize] Get Contract using contract id with renter id (For renter)")]
    [Authorize(Roles = "Supervisor, Renter")]
    [HttpGet("{id:int}/user/{renterId:int}")]
    public async Task<IActionResult> GetContract(int id, int renterId, CancellationToken token)
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

                var employeeId = await _serviceWrapper.GetId.GetSupervisorIdByBuildingId(entity.BuildingId, token);

                var buildingDetail = new BuildingContractDetailEntity
                {
                    EmployeeId = employeeId,
                    BuildingName = building.BuildingName,
                    BuildingPhoneNumber = building.BuildingPhoneNumber,
                    BuildingAddress = building.BuildingAddress
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
                    PriceForElectricity = entity.PriceForElectricity.DecimalToString()
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

    /*

    [SwaggerOperation(Summary = "[Authorize] Get active contract based on user Id (For management and renter)")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [HttpGet("user/{userId:int}/active")]
    public async Task<IActionResult> GetContractBasedOnUserId(int userId)
    {
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
        

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No user found",
                data = ""
            });

        var entity = await _serviceWrapper.Contracts.GetLatestContractByUserId(userId);

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
    
    */


    // PUT: api/Contract/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Update Contract info (For management)",
        Description = "date format d/M/YYYY")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContract(int id, [FromBody] ContractUpdateRequest contract)
    {
        //var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var contractEntity = await _serviceWrapper.Contracts.GetContractById(id);

        if (contractEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        var validation = await _validator.ValidateParams(contract, id);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var updateContract = new Contract
        {
            ContractId = id,
            ContractName = contract.ContractName,
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                "dd/MM/yyyy HH:mm:ss", null),
            ContractStatus = contract.ContractStatus,
            PriceForRent = decimal.Parse(contract.PriceForRent, CultureInfo.InvariantCulture),
            PriceForElectricity = decimal.Parse(contract.PriceForElectricity, CultureInfo.InvariantCulture),
            PriceForWater = decimal.Parse(contract.PriceForWater, CultureInfo.InvariantCulture),
            PriceForService = decimal.Parse(contract.PriceForService, CultureInfo.InvariantCulture),
            RenterId = contractEntity.RenterId,
            /*
            ImageUrl = (await _serviceWrapper.AzureStorage.UploadAsync(contract.Image, "Contract",
                imageExtension))?.Blob.Uri,
            */
            Description = contract.Description ?? "No description",
            CreatedDate = contractEntity.CreatedDate
        };

        var result = await _serviceWrapper.Contracts.UpdateContract(updateContract);

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

    // POST: api/Contract
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [SwaggerOperation(Summary = "[Authorize] Create Contract (For management)", Description = "date format d/M/YYYY")]
    [Authorize(Roles = "Supervisor")]
    [HttpPost("sign")]
    public async Task<IActionResult> PostContract([FromBody] ContractCreateRequest contract, CancellationToken token)
    {
        var contractValidation = await _validator.ValidateParams(contract);

        if (!contractValidation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = contractValidation.Failures.FirstOrDefault(),
                data = ""
            });

        var newRenter = new Renter
        {
            Username = contract.RenterUsername,
            FullName = contract.FullName,
            Password = "123456",
            Email = contract.RenterEmail ?? "No email",
            Phone = contract.RenterPhone,
            BirthDate = contract.RenterBirthDate,
            Address = contract.Address,
            Gender = contract.Gender
        };

        var renterEntity = await _serviceWrapper.Renters.AddRenter(newRenter);

        if (renterEntity == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Renter failed to create",
                data = ""
            });

        var employeeId = Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetSupervisorIdByBuildingId(employeeId, token);

        var newContract = new Contract
        {
            ContractName = contract.ContractName ?? "Contract for " + renterEntity.FullName,
            DateSigned = contract.DateSigned ?? DateTimeUtils.GetCurrentDateTime(),
            StartDate = contract.StartDate ?? DateTimeUtils.GetCurrentDateTime(),
            CreatedDate = DateTimeUtils.GetCurrentDateTime(),
            Description = contract.Description ?? "No description",
            EndDate = contract.EndDate,
            LastUpdated = DateTimeUtils.GetCurrentDateTime(),
            ContractStatus = contract.ContractStatus ?? "Active",
            PriceForRent = decimal.Parse(contract.PriceForRent, CultureInfo.InvariantCulture),
            PriceForElectricity = decimal.Parse(contract.PriceForElectricity, CultureInfo.InvariantCulture),
            PriceForWater = decimal.Parse(contract.PriceForWater, CultureInfo.InvariantCulture),
            PriceForService = decimal.Parse(contract.PriceForService, CultureInfo.InvariantCulture),
            RenterId = renterEntity.RenterId,
            BuildingId = buildingId,
            FlatId = contract.FlatId,
            RoomId = contract.RoomId
        };

        var result = await _serviceWrapper.Contracts.AddContract(newContract);

        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract failed to create",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Contract created",
            data = ""
        });
    }

    // DELETE: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Remove contract (For management)")]
    [Authorize(Roles = "Admin, Supervisor")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        var result = await _serviceWrapper.Contracts.DeleteContract(id);
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
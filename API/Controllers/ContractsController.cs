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

                var adminContractListReturn = _mapper.Map<IEnumerable<ContactDetailRenterEntity>>(adminContractList);

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = adminContractListReturn,
                    totalPage = adminContractList.TotalPages,
                    totalCount = adminContractList.TotalCount
                });

            case "Supervisor":
                var supervisorId = Parse(User.Identity?.Name);

                var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(supervisorId, token);

                switch (buildingId)
                {
                    case -2:
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                            data = ""
                        });
                    case -1:
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = "Người quản lý không quản lý tòa nhà nào",
                            data = ""
                        });
                }

                var supervisorContractList =
                    await _serviceWrapper.Contracts.GetContractList(filter, buildingId, true, token);

                var supervisorContractListReturn =
                    _mapper.Map<IEnumerable<ContactDetailRenterEntity>>(supervisorContractList);

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
                    message = "Hiển thị danh sách",
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
                    message = "Hiển thị danh sách",
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

    /*
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
            message = "Hiển thị danh sách",
            data = resultList,
            totalPage = list.TotalPages,
            totalCount = list.TotalCount
        });
    }
    */

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
            message = "Hiển thị danh sách",
            data = _mapper.Map<ContactDetailRenterEntity>(latestContract)
        });
    }

/*
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
*/
/*
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
*/
    // GET: api/Contract/5
    [SwaggerOperation(Summary = "[Authorize] Get Contract using id (For management)")]
    [Authorize(Roles = "Supervisor")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContractManagement(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.Contracts.GetContractById(id, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        var imageUrls = new[]
        {
            entity.ContractImageUrl1,
            entity.ContractImageUrl2
        };

        var contract = _mapper.Map<ContactDetailRenterEntity>(entity);

        contract.ImageUrls = imageUrls;
        contract.PriceForRent = entity.PriceForRent.DecimalToString();
        contract.PriceForService = entity.PriceForService.DecimalToString();
        contract.PriceForWater = entity.PriceForWater.DecimalToString();
        contract.PriceForElectricity = entity.PriceForElectricity.DecimalToString();

        return Ok(new
        {
            status = "Success",
            message = "Contract found",
            data = contract
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

        var entity = await _serviceWrapper.Contracts.GetContractById(id, token);

        switch (entity)
        {
            case not null when userRole is "Renter" && entity.RenterId != Parse(User.Identity.Name):
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "You are not authorized to access this resource due to invalid renter ID",
                    data = ""
                });

            case not null when userRole is "Renter" && renterId != Parse(User.Identity.Name):
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "You are not authorized to access this resource due to invalid token",
                    data = ""
                });

            case not null when userRole != "Renter":
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
                var renter = await _serviceWrapper.Renters.GetRenterById(entity.RenterId, token);
                if (renter == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Renter not found",
                        data = ""
                    });

                var building = await _serviceWrapper.Buildings.GetBuildingById(entity.BuildingId, token);
                if (building == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Building not found",
                        data = ""
                    });

                var employeeId = await _serviceWrapper.GetId.GetSupervisorIdByBuildingId(entity.BuildingId, token);

                switch (employeeId)
                {
                    case 0:
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = "Employee not found for this building",
                            data = ""
                        });
                    case -1:
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Something went wrong",
                            data = ""
                        });
                }

                var imageUrls = new[]
                {
                    entity.ContractImageUrl1,
                    entity.ContractImageUrl2
                };


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
                    ContractSerialNumber = entity.ContractSerialNumber,
                    ContractName = entity.ContractName,
                    DateSigned = entity.DateSigned,
                    StartDate = entity.StartDate,
                    CreatedDate = entity.CreatedDate,
                    Description = entity.Description,
                    EndDate = entity.EndDate,
                    LastUpdated = entity.LastUpdated,
                    ContractStatus = entity.ContractStatus,
                    // TODO : Fix mobile to List
                    // ImageUrl = entity.ContractImageUrl1,
                    PriceForRent = entity.PriceForRent.DecimalToString(),
                    PriceForService = entity.PriceForService.DecimalToString(),
                    PriceForWater = entity.PriceForWater.DecimalToString(),
                    PriceForElectricity = entity.PriceForElectricity.DecimalToString(),
                    ImageUrls = imageUrls
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

        var contractEntity = await _serviceWrapper.Contracts.GetContractByRenterIdWithActiveStatus(entity.ContractId);

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
    public async Task<IActionResult> PutContract(int id, [FromBody] ContractUpdateRequest contract,
        CancellationToken token)
    {
        //var imageExtension = ImageExtension.ImageExtensionChecker(contract.Image?.FileName);

        var contractEntity = await _serviceWrapper.Contracts.GetContractById(id, token);

        if (contractEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        var validation = await _validator.ValidateParams(contract, id, token);

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
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus ?? "Active",
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
        var employeeId = Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

        switch (buildingId)
        {
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                    data = ""
                });
            case -1:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Người quản lý không quản lý tòa nhà nào",
                    data = ""
                });
        }

        var contractValidation = await _validator.ValidateParams(contract, buildingId, token);

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
            Email = contract.RenterEmail,
            PhoneNumber = contract.RenterPhone,
            BirthDate = contract.RenterBirthDate.ToDateTime(),
            Address = contract.Address,
            Gender = contract.Gender,
            CitizenCardFrontImageUrl = contract.CitizenCardFrontImageUrl,
            CitizenCardBackImageUrl = contract.CitizenCardBackImageUrl,
            CitizenNumber = contract.CitizenNumber
        };

        var newContract = new Contract
        {
            ContractName = contract.ContractName,
            ContractSerialNumber = contract.RenterUsername + "-" + contract.RoomId + "-" + contract.FlatId,
            DateSigned = contract.DateSigned.ToDateTime(),
            StartDate = contract.StartDate.ToDateTime(),
            CreatedDate = DateTimeUtils.GetCurrentDateTime(),
            Description = contract.Description,
            EndDate = contract.EndDate.ToDateTime(),
            LastUpdated = DateTimeUtils.GetCurrentDateTime(),
            ContractStatus = contract.ContractStatus,
            PriceForRent = decimal.Parse(contract.PriceForRent, CultureInfo.InvariantCulture),
            PriceForElectricity = decimal.Parse(contract.PriceForElectricity, CultureInfo.InvariantCulture),
            PriceForWater = decimal.Parse(contract.PriceForWater, CultureInfo.InvariantCulture),
            PriceForService = decimal.Parse(contract.PriceForService, CultureInfo.InvariantCulture),
            BuildingId = buildingId,
            FlatId = contract.FlatId,
            RoomId = contract.RoomId
        };

        var result = await _serviceWrapper.Contracts.AddContractWithRenter(newContract, newRenter, token);

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

    [SwaggerOperation(Summary = "[Authorize] Create Contract (For management)", Description = "date format d/M/YYYY")]
    [Authorize(Roles = "Supervisor")]
    [HttpPost("sign/renter/{renterId:int}")]
    public async Task<IActionResult> PostContract(int renterId, [FromBody] ContractCreateUserExistRequest contract,
        CancellationToken token)
    {
        var employeeId = Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

        switch (buildingId)
        {
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Người quản lý đang quản lý nhiều hơn 1 tòa nhà",
                    data = ""
                });
            case -1:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Người quản lý không quản lý tòa nhà nào",
                    data = ""
                });
        }

        var renterLatestContract = await _serviceWrapper.Contracts.GetLatestContractByUserId(renterId, token);

        switch (renterLatestContract)
        {
            case null:
            case not null:
                switch (renterLatestContract?.ContractStatus)
                {
                    case "active":
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = "Người thuê này hiện đang có hợp đồng với bên hệ thống",
                            data = ""
                        });
                }

                var contractValidation = await _validator.ValidateParams(contract, renterId, buildingId, token);

                if (!contractValidation.IsValid)
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = contractValidation.Failures.FirstOrDefault(),
                        data = ""
                    });

                var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId, token);

                if (renterCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Người thuê không tồn tại",
                        data = ""
                    });

                var newContract = new Contract
                {
                    ContractName = contract.ContractName,
                    ContractSerialNumber = renterCheck.Username + "N" + "-" + contract.RoomId + "-" + contract.FlatId,
                    DateSigned = contract.DateSigned.ToDateTime(),
                    StartDate = contract.StartDate.ToDateTime(),
                    CreatedDate = DateTimeUtils.GetCurrentDateTime(),
                    Description = contract.Description,
                    EndDate = contract.EndDate.ToDateTime(),
                    LastUpdated = DateTimeUtils.GetCurrentDateTime(),
                    ContractStatus = contract.ContractStatus,
                    PriceForRent = decimal.Parse(contract.PriceForRent, CultureInfo.InvariantCulture),
                    PriceForElectricity = decimal.Parse(contract.PriceForElectricity, CultureInfo.InvariantCulture),
                    PriceForWater = decimal.Parse(contract.PriceForWater, CultureInfo.InvariantCulture),
                    PriceForService = decimal.Parse(contract.PriceForService, CultureInfo.InvariantCulture),
                    BuildingId = buildingId,
                    FlatId = contract.FlatId,
                    RoomId = contract.RoomId,
                    RenterId = renterId
                };

                var result = await _serviceWrapper.Contracts.AddContractWithRenter(newContract, token);

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
using API.Extension;
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/upload")]
public class TestUploadImageController : ControllerBase
{
    private const string Container = "images";
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public TestUploadImageController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpPut]
    [Authorize(Roles = "Renter")]
    [Route("renter")]
    public async Task<IActionResult> UploadFileRenter([FromForm] ImageUploadRequest imageUploadRequest)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var fileNameUserImage = renterCheck.ImageUrl?.Split('/').Last() ?? "";

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var finalizeUpdate = new Renter
        {
            RenterId = renterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image,
                fileNameUserImage, "User", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Renters.UpdateImageRenter(finalizeUpdate);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            }),
            true => Ok(new
            {
                status = "Success",
                message = "Image uploaded successfully",
                data = finalizeUpdate.ImageUrl
            })
        };
    }

    [SwaggerOperation]
    [Authorize(Roles = "Supervisor")]
    [HttpPut("building/image/1")]
    public async Task<IActionResult> PutBuilding1([FromForm] ImageUploadRequest imageUploadRequest)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId);

        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        var fileNameUserImage = buildingCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var updateBuilding = new Building
        {
            BuildingId = buildingId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image, fileNameUserImage,
                "Building", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Buildings.UpdateBuildingImages(updateBuilding, 1);

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

    [SwaggerOperation]
    [Authorize(Roles = "Supervisor")]
    [HttpPut("building/image/2")]
    public async Task<IActionResult> PutBuilding2([FromForm] ImageUploadRequest imageUploadRequest)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId);

        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        var fileNameUserImage = buildingCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var updateBuilding = new Building
        {
            BuildingId = buildingId,
            ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image, fileNameUserImage,
                "Building", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Buildings.UpdateBuildingImages(updateBuilding, 2);

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

    [SwaggerOperation]
    [Authorize(Roles = "Supervisor")]
    [HttpPut("building/image/3")]
    public async Task<IActionResult> PutBuilding3([FromForm] ImageUploadRequest imageUploadRequest)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId);

        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        var fileNameUserImage = buildingCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var updateBuilding = new Building
        {
            BuildingId = buildingId,
            ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image, fileNameUserImage,
                "Building", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Buildings.UpdateBuildingImages(updateBuilding, 3);

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

    [SwaggerOperation]
    [Authorize(Roles = "Admin")]
    [HttpPut("area/{areaId:int}")]
    public async Task<IActionResult> PutArea(int areaId, [FromForm] ImageUploadRequest imageUploadRequest)
    {
        var area = await _serviceWrapper.Areas.GetAreaById(areaId);

        if (area == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Area not found",
                data = ""
            });

        var fileNameUserImage = area.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var updateArea = new Area
        {
            AreaId = areaId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image, fileNameUserImage,
                "Area", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Areas.UpdateAreaImage(updateArea);

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

    [SwaggerOperation]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpPut("employee")]
    public async Task<IActionResult> PutEmployee([FromForm] ImageUploadRequest imageUploadRequest)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var employeeCheck = await _serviceWrapper.Employees.GetEmployeeById(employeeId);

        if (employeeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Employee not found",
                data = ""
            });

        var fileNameUserImage = employeeCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var updateArea = new Employee
        {
            EmployeeId = employeeId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image, fileNameUserImage,
                "Employee", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Employees.UpdateEmployeeProfilePicture(updateArea);

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


    [HttpPut]
    [Authorize(Roles = "Supervisor")]
    [Route("contract")]
    public async Task<IActionResult> UploadFileContract([FromForm] ImageUploadRequest imageUploadRequest,
        int contractId)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var employeeCheck = await _serviceWrapper.Employees.GetEmployeeById(employeeId);

        if (employeeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Employee not found",
                data = ""
            });

        var contract = await _serviceWrapper.Contracts.GetContractById(contractId);

        if (contract == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        var fileNameContract = contract.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var finalizeUpdate = new Contract
        {
            ContractId = contractId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(contract.Image, fileNameContract,
                "Contract", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Contracts.UpdateContract(finalizeUpdate);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            }),
            true => Ok(new
            {
                status = "Success",
                message = "Image uploaded successfully",
                data = result
            })
        };
    }

    [HttpPut]
    [Authorize(Roles = "Renter")]
    [Route("ticket/image/1")]
    public async Task<IActionResult> UploadTicketImage1([FromForm] ImageUploadRequest imageUploadRequest, int ticketId)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var renterTicketCheck = await _serviceWrapper.Tickets.GetTicketById(ticketId, renterId);

        if (renterTicketCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No ticket with this id found with this user",
                data = ""
            });


        var fileNameContract = renterTicketCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var finalizeUpdate = new Ticket
        {
            ContractId = renterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(renterTicketCheck.Image, fileNameContract,
                "Ticket", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Tickets.UpdateTicketImage(finalizeUpdate, 1);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            }),
            true => Ok(new
            {
                status = "Success",
                message = "Image uploaded successfully",
                data = result
            })
        };
    }

    [HttpPut]
    [Authorize(Roles = "Renter")]
    [Route("ticket/image/2")]
    public async Task<IActionResult> UploadTicketImage2([FromForm] ImageUploadRequest imageUploadRequest, int ticketId)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var renterTicketCheck = await _serviceWrapper.Tickets.GetTicketById(ticketId, renterId);

        if (renterTicketCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No ticket with this id found with this user",
                data = ""
            });


        var fileNameContract = renterTicketCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var finalizeUpdate = new Ticket
        {
            ContractId = renterId,
            ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(renterTicketCheck.Image, fileNameContract,
                "Ticket", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Tickets.UpdateTicketImage(finalizeUpdate, 2);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            }),
            true => Ok(new
            {
                status = "Success",
                message = "Image uploaded successfully",
                data = result
            })
        };
    }

    [HttpPut]
    [Authorize(Roles = "Renter")]
    [Route("ticket/image/3")]
    public async Task<IActionResult> UploadTicketImage3([FromForm] ImageUploadRequest imageUploadRequest, int ticketId)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var renterTicketCheck = await _serviceWrapper.Tickets.GetTicketById(ticketId, renterId);

        if (renterTicketCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No ticket with this id found with this user",
                data = ""
            });


        var fileNameContract = renterTicketCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image?.FileName);

        var finalizeUpdate = new Ticket
        {
            ContractId = renterId,
            ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(renterTicketCheck.Image, fileNameContract,
                "Ticket", imageExtension, false))?.Blob.Uri
        };

        var result = await _serviceWrapper.Tickets.UpdateTicketImage(finalizeUpdate, 3);

        return result.IsSuccess switch
        {
            false => BadRequest(new
            {
                status = "Bad Request",
                message = result.Message,
                data = ""
            }),
            true => Ok(new
            {
                status = "Success",
                message = "Image uploaded successfully",
                data = result
            })
        };
    }
}
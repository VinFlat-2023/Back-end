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
                fileNameUserImage, "User", imageExtension))?.Blob.Uri
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
    [HttpPut("building")]
    public async Task<IActionResult> PutBuilding([FromForm] ImageUploadRequest imageUploadRequest)
    {
        var supervisorId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(supervisorId);

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
                "User", imageExtension))?.Blob.Uri
        };

        var result = await _serviceWrapper.Buildings.UpdateBuildingImages(updateBuilding);

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
    public async Task<IActionResult> UploadFileContract([FromForm] ImageUploadRequest imageUploadRequest)
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

        var contract = await _serviceWrapper.Contracts.GetContractById(renterId);

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
            ContractId = renterId,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(contract.Image, fileNameContract, "Contract",
                imageExtension))?.Blob.Uri
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
}
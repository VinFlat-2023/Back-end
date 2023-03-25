using API.Extension;
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

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

    [HttpPatch]
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

        var fileNameUserImage = renterCheck.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(renterCheck.Image?.FileName);

        var finalizeUpdate = new Renter
        {
            RenterId = imageUploadRequest.Id,
            ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(imageUploadRequest.Image, fileNameUserImage,
                "User", imageExtension))?.Blob.Uri
        };

        var result = await _serviceWrapper.Renters.UpdateRenter(finalizeUpdate);

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

    [HttpPatch]
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

        var contract = await _serviceWrapper.Contracts.GetContractById(imageUploadRequest.Id);

        if (contract == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        var fileNameContract = contract.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(renterCheck.Image?.FileName);

        var finalizeUpdate = new Contract
        {
            ContractId = imageUploadRequest.Id,
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
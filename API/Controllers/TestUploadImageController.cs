using API.Extension;
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
    private readonly IServiceWrapper _serviceWrapper;

    public TestUploadImageController(IServiceWrapper serviceWrapper)
    {
        _serviceWrapper = serviceWrapper;
    }

    [HttpPut]
    [Authorize(Roles = "Renter")]
    [Route("renter")]
    public async Task<IActionResult> UploadFileRenter([FromForm] ImageUploadRequest imageUploadRequest,
        CancellationToken token)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId, token);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var fileNameUserImage = renterCheck.ImageUrl?.Split('/').Last() ?? "";

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image.FileName);

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
    [Authorize(Roles = "Admin")]
    [HttpPut("area/{areaId:int}")]
    public async Task<IActionResult> PutArea(int areaId,
        [FromForm] MultipleImageUploadRequest? multipleImageUploadRequest, CancellationToken token)
    {
        var areaCheck = await _serviceWrapper.Areas.GetAreaById(areaId, token);

        if (areaCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Khu vực không tồn tại",
                data = ""
            });

        if (multipleImageUploadRequest == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Không có ảnh nào được tải lên",
                data = ""
            });

        if (multipleImageUploadRequest.ImageUploadRequest.Count == 0 ||
            !multipleImageUploadRequest.ImageUploadRequest.Any())
            return NotFound(new
            {
                status = "Success",
                message = "Không có ảnh nào được tải lên",
                data = ""
            });

        var counter = 0;

        foreach (var image in multipleImageUploadRequest.ImageUploadRequest)
        {
            counter++;
            var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

            switch (counter)
            {
                case 1:
                    var fileNameCheck1 = areaCheck.ImageUrl?.Split('/').Last();

                    var finalizeUpdate1 = new Area
                    {
                        AreaId = areaId,
                        ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Area", imageExtension, false))?.Blob.Uri
                    };
                    var result1 = await _serviceWrapper.Areas.UpdateAreaImage(finalizeUpdate1, counter);

                    if (!result1.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result1.Message,
                            data = ""
                        });

                    break;
                case 2:
                    var fileNameCheck2 = areaCheck.ImageUrl2?.Split('/').Last();

                    var finalizeUpdate2 = new Area
                    {
                        AreaId = areaId,
                        ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Area", imageExtension, false))?.Blob.Uri
                    };
                    var result2 = await _serviceWrapper.Areas.UpdateAreaImage(finalizeUpdate2, counter);

                    if (!result2.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result2.Message,
                            data = ""
                        });

                    break;

                case 3:
                    var fileNameCheck3 = areaCheck.ImageUrl3?.Split('/').Last();

                    var finalizeUpdate3 = new Area
                    {
                        AreaId = areaId,
                        ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Area", imageExtension, false))?.Blob.Uri
                    };
                    var result3 = await _serviceWrapper.Areas.UpdateAreaImage(finalizeUpdate3, counter);

                    if (!result3.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result3.Message,
                            data = ""
                        });

                    break;
                case 4:
                    var fileNameCheck4 = areaCheck.ImageUrl4?.Split('/').Last();

                    var finalizeUpdate4 = new Area
                    {
                        AreaId = areaId,
                        ImageUrl4 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck4,
                            "Area", imageExtension, false))?.Blob.Uri
                    };
                    var result4 = await _serviceWrapper.Areas.UpdateAreaImage(finalizeUpdate4, counter);

                    if (!result4.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result4.Message,
                            data = ""
                        });

                    break;
                case >= 5:
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "Bạn chỉ có thể upload tối đa 4 ảnh",
                        data = ""
                    });
            }
        }

        return Ok(new
        {
            status = "Success",
            message = counter + " image(s) uploaded successfully",
            data = ""
        });
    }

    [SwaggerOperation]
    [Authorize(Roles = "Admin, Supervisor, Technician")]
    [HttpPut("employee")]
    public async Task<IActionResult> PutEmployee([FromForm] ImageUploadRequest imageUploadRequest,
        CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var employeeCheck = await _serviceWrapper.Employees.GetEmployeeById(employeeId, token);

        if (employeeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Nhân viên không tồn tại",
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
        int contractId, CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var employeeCheck = await _serviceWrapper.Employees.GetEmployeeById(employeeId, token);

        if (employeeCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Nhân viên không tồn tại",
                data = ""
            });

        var contract = await _serviceWrapper.Contracts.GetContractById(contractId, token);

        if (contract == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found",
                data = ""
            });

        var fileNameContract = contract.ImageUrl?.Split('/').Last();

        var imageExtension = ImageExtension.ImageExtensionChecker(imageUploadRequest.Image.FileName);

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
    [Route("ticket/{ticketId:int}/image")]
    public async Task<IActionResult> UploadTicketImage([FromForm] MultipleImageUploadRequest multipleImageUploadRequest,
        int ticketId, CancellationToken token)
    {
        var renterId = int.Parse(User.Identity?.Name);

        var renterCheck = await _serviceWrapper.Renters.GetRenterById(renterId, token);

        if (renterCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Renters not found",
                data = ""
            });

        var renterTicketCheck = await _serviceWrapper.Tickets.GetTicketById(ticketId, renterId, token);

        if (renterTicketCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "No ticket with this id found with this user",
                data = ""
            });


        var counter = 0;

        if (multipleImageUploadRequest.ImageUploadRequest.Count == 0 ||
            !multipleImageUploadRequest.ImageUploadRequest.Any())
            return Ok(new
            {
                status = "Success",
                message = "No image uploaded",
                data = ""
            });

        foreach (var image in multipleImageUploadRequest.ImageUploadRequest)
        {
            counter++;
            var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

            switch (counter)
            {
                case 1:
                    var fileNameCheck1 = renterTicketCheck.ImageUrl?.Split('/').Last();

                    var finalizeUpdate1 = new Ticket
                    {
                        TicketId = ticketId,
                        ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Ticket", imageExtension, false))?.Blob.Uri
                    };
                    var result1 = await _serviceWrapper.Tickets.UpdateTicketImage(finalizeUpdate1, counter);
                    if (!result1.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result1.Message,
                            data = ""
                        });
                    break;

                case 2:
                    var fileNameCheck2 = renterTicketCheck.ImageUrl2?.Split('/').Last();

                    var finalizeUpdate2 = new Ticket
                    {
                        TicketId = ticketId,
                        ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Ticket", imageExtension, false))?.Blob.Uri
                    };
                    var result2 = await _serviceWrapper.Tickets.UpdateTicketImage(finalizeUpdate2, counter);
                    if (!result2.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result2.Message,
                            data = ""
                        });
                    break;

                case 3:
                    var fileNameCheck3 = renterTicketCheck.ImageUrl3?.Split('/').Last();

                    var finalizeUpdate3 = new Ticket
                    {
                        TicketId = ticketId,
                        ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Ticket", imageExtension, false))?.Blob.Uri
                    };
                    var result3 = await _serviceWrapper.Tickets.UpdateTicketImage(finalizeUpdate3, counter);
                    if (!result3.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result3.Message,
                            data = ""
                        });
                    break;
                case >= 4:
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "You can only upload 3 images",
                        data = ""
                    });
            }
        }

        return Ok(new
        {
            status = "Success",
            message = counter + " image(s) uploaded successfully",
            data = ""
        });
    }


    [SwaggerOperation]
    [Authorize(Roles = "Supervisor")]
    [HttpPut("building/image")]
    public async Task<IActionResult> PutBuildingSupervisor(
        [FromForm] MultipleImageUploadRequest multipleImageUploadRequest, CancellationToken token)
    {
        var employeeId = int.Parse(User.Identity?.Name);

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);

        switch (buildingId)
        {
            case -1:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "No building found for this supervisor",
                    data = ""
                });
            case -2:
                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "More than one building found for this supervisor",
                    data = ""
                });
        }


        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        if (multipleImageUploadRequest.ImageUploadRequest.Count == 0 ||
            !multipleImageUploadRequest.ImageUploadRequest.Any())
            return Ok(new
            {
                status = "Success",
                message = "No image uploaded",
                data = ""
            });

        var counter = 0;

        foreach (var image in multipleImageUploadRequest.ImageUploadRequest)
        {
            counter++;
            var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

            switch (counter)
            {
                case 1:
                    var fileNameCheck1 = buildingCheck.ImageUrl?.Split('/').Last();

                    var finalizeUpdate1 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result1 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate1, counter);
                    if (!result1.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result1.Message,
                            data = ""
                        });
                    break;

                case 2:
                    var fileNameCheck2 = buildingCheck.ImageUrl2?.Split('/').Last();

                    var finalizeUpdate2 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result2 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate2, counter);
                    if (!result2.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result2.Message,
                            data = ""
                        });
                    break;

                case 3:
                    var fileNameCheck3 = buildingCheck.ImageUrl3?.Split('/').Last();

                    var finalizeUpdate3 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result3 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate3, counter);
                    if (!result3.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result3.Message,
                            data = ""
                        });
                    break;
                case >= 4:
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "You can only upload 3 images",
                        data = ""
                    });
            }
        }

        return Ok(new
        {
            status = "Success",
            message = counter + " image(s) uploaded successfully",
            data = ""
        });
    }

    [SwaggerOperation]
    [Authorize(Roles = "Admin")]
    [HttpPut("building/{buildingId:int}/image")]
    public async Task<IActionResult> PutBuildingAdmin([FromForm] MultipleImageUploadRequest multipleImageUploadRequest,
        int buildingId, CancellationToken token)
    {
        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        if (multipleImageUploadRequest.ImageUploadRequest.Count == 0 ||
            !multipleImageUploadRequest.ImageUploadRequest.Any())
            return Ok(new
            {
                status = "Success",
                message = "No image uploaded",
                data = ""
            });

        var counter = 0;

        foreach (var image in multipleImageUploadRequest.ImageUploadRequest)
        {
            counter++;
            var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

            switch (counter)
            {
                case 1:
                    var fileNameCheck1 = buildingCheck.ImageUrl?.Split('/').Last();

                    var finalizeUpdate1 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result1 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate1, counter);
                    if (!result1.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result1.Message,
                            data = ""
                        });
                    break;

                case 2:
                    var fileNameCheck2 = buildingCheck.ImageUrl2?.Split('/').Last();

                    var finalizeUpdate2 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result2 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate2, counter);
                    if (!result2.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result2.Message,
                            data = ""
                        });
                    break;

                case 3:
                    var fileNameCheck3 = buildingCheck.ImageUrl3?.Split('/').Last();

                    var finalizeUpdate3 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result3 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate3, counter);
                    if (!result3.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result3.Message,
                            data = ""
                        });
                    break;
                case >= 4:
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "You can only upload 3 images",
                        data = ""
                    });
            }
        }

        return Ok(new
        {
            status = "Success",
            message = counter + " image(s) uploaded successfully",
            data = ""
        });
    }

    [SwaggerOperation]
    [Authorize(Roles = "Admin")]
    [HttpPut("building/{buildingId:int}/image/{imageId:int}")]
    public async Task<IActionResult> PutSingleImageBuildingAdmin(
        [FromForm] MultipleImageUploadRequest multipleImageUploadRequest,
        int buildingId, CancellationToken token)
    {
        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        if (multipleImageUploadRequest.ImageUploadRequest.Count == 0 ||
            !multipleImageUploadRequest.ImageUploadRequest.Any())
            return Ok(new
            {
                status = "Success",
                message = "No image uploaded",
                data = ""
            });

        var counter = 0;

        foreach (var image in multipleImageUploadRequest.ImageUploadRequest)
        {
            counter++;
            var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

            switch (counter)
            {
                case 1:
                    var fileNameCheck1 = buildingCheck.ImageUrl?.Split('/').Last();

                    var finalizeUpdate1 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result1 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate1, counter);
                    if (!result1.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result1.Message,
                            data = ""
                        });
                    break;

                case 2:
                    var fileNameCheck2 = buildingCheck.ImageUrl2?.Split('/').Last();

                    var finalizeUpdate2 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result2 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate2, counter);
                    if (!result2.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result2.Message,
                            data = ""
                        });
                    break;

                case 3:
                    var fileNameCheck3 = buildingCheck.ImageUrl3?.Split('/').Last();

                    var finalizeUpdate3 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result3 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate3, counter);
                    if (!result3.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result3.Message,
                            data = ""
                        });
                    break;
                case >= 4:
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "You can only upload 3 images",
                        data = ""
                    });
            }
        }

        return Ok(new
        {
            status = "Success",
            message = counter + " image(s) uploaded successfully",
            data = ""
        });
    }

    [SwaggerOperation]
    [Authorize(Roles = "Supervisor")]
    [HttpPut("building/image/{imageId:int}")]
    public async Task<IActionResult> PutSingleImageBuildingSupervisor(
        [FromForm] MultipleImageUploadRequest multipleImageUploadRequest,
        int buildingId, CancellationToken token)
    {
        var buildingCheck = await _serviceWrapper.Buildings.GetBuildingById(buildingId, token);

        if (buildingCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        if (multipleImageUploadRequest.ImageUploadRequest.Count == 0 ||
            !multipleImageUploadRequest.ImageUploadRequest.Any())
            return Ok(new
            {
                status = "Success",
                message = "No image uploaded",
                data = ""
            });

        var counter = 0;

        foreach (var image in multipleImageUploadRequest.ImageUploadRequest)
        {
            counter++;
            var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

            switch (counter)
            {
                case 1:
                    var fileNameCheck1 = buildingCheck.ImageUrl?.Split('/').Last();

                    var finalizeUpdate1 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result1 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate1, counter);
                    if (!result1.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result1.Message,
                            data = ""
                        });
                    break;

                case 2:
                    var fileNameCheck2 = buildingCheck.ImageUrl2?.Split('/').Last();

                    var finalizeUpdate2 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result2 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate2, counter);
                    if (!result2.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result2.Message,
                            data = ""
                        });
                    break;

                case 3:
                    var fileNameCheck3 = buildingCheck.ImageUrl3?.Split('/').Last();

                    var finalizeUpdate3 = new Building
                    {
                        BuildingId = buildingId,
                        ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Building", imageExtension, false))?.Blob.Uri
                    };
                    var result3 = await _serviceWrapper.Buildings.UpdateBuildingImages(finalizeUpdate3, counter);
                    if (!result3.IsSuccess)
                        return BadRequest(new
                        {
                            status = "Bad Request",
                            message = result3.Message,
                            data = ""
                        });
                    break;
                case >= 4:
                    return BadRequest(new
                    {
                        status = "Bad Request",
                        message = "You can only upload 3 images",
                        data = ""
                    });
            }
        }

        return Ok(new
        {
            status = "Success",
            message = counter + " image(s) uploaded successfully",
            data = ""
        });
    }
}
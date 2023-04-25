﻿using System.Security.Claims;
using API.Extension;
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Ticket;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Utils;
using Domain.ViewModel.ImageUrls;
using Domain.ViewModel.TicketEntity;
using Domain.ViewModel.TicketTypeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IValidator;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/tickets")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    private readonly ITicketValidator _validator;

    // GET: api/Requests
    public TicketsController(IMapper mapper, IServiceWrapper serviceWrapper,
        ITicketValidator validator)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _validator = validator;
    }

    [HttpGet]
    [Authorize(Roles = "Technician, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket list with pagination and filter (For management and renter)")]
    public async Task<IActionResult> GetTickets([FromQuery] TicketFilterRequest ticketFilterRequest,
        CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var userId = int.Parse(User.Identity?.Name);

        var filter = _mapper.Map<TicketFilter>(ticketFilterRequest);

        switch (userRole)
        {
            case "Admin":
                var list = await _serviceWrapper.Tickets.GetTicketList(filter, token);

                if (list == null || !list.Any())
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Ticket list is empty",
                        data = ""
                    });

                var resultList = _mapper.Map<IEnumerable<TicketDetailEntity>>(list);

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = resultList,
                    totalPage = list.TotalPages,
                    totalCount = list.TotalCount
                });

            case "Supervisor" or "Technician":

                if (userRole.ToLower() == "Supervisor".ToLower())
                {
                    var buildingIdBasedOnSupervisor =
                        await _serviceWrapper.GetId.GetBuildingIdBasedOnSupervisorId(userId, token);
                    switch (buildingIdBasedOnSupervisor)
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

                    var supervisorTicketList =
                        await _serviceWrapper.Tickets.GetTicketList(filter, buildingIdBasedOnSupervisor, token);

                    if (supervisorTicketList == null)
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = "Không có danh sách phiếu",
                            data = ""
                        });

                    var supervisorTicketListReturn = _mapper.Map<IEnumerable<TicketDetailEntity>>(supervisorTicketList);

                    return Ok(new
                    {
                        status = "Success",
                        message = "Hiện thị danh sách",
                        data = supervisorTicketListReturn,
                        totalPage = supervisorTicketList.TotalPages,
                        totalCount = supervisorTicketList.TotalCount
                    });
                }

                if (userRole.ToLower() == "Technician".ToLower())
                {
                    var buildingIdTechnician =
                        await _serviceWrapper.GetId.GetBuildingIdBasedOnTechnicianId(userId, token);
                    switch (buildingIdTechnician)
                    {
                        case 0:
                            return NotFound(new
                            {
                                status = "Not Found",
                                message = "Người kĩ thuật viên không hỗ trợ tòa nhà nào",
                                data = ""
                            });
                    }

                    var technicianTicketList =
                        await _serviceWrapper.Tickets.GetTicketList(filter, buildingIdTechnician, token);

                    if (technicianTicketList == null)
                        return NotFound(new
                        {
                            status = "Not Found",
                            message = "Không có danh sách phiếu",
                            data = ""
                        });

                    var technicianTicketListReturn = _mapper.Map<IEnumerable<TicketDetailEntity>>(technicianTicketList);

                    return Ok(new
                    {
                        status = "Success",
                        message = "Hiện thị danh sách",
                        data = technicianTicketListReturn,
                        totalPage = technicianTicketList.TotalPages,
                        totalCount = technicianTicketList.TotalCount
                    });
                }

                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Tài khoản đang đăng nhập không hợp lệ",
                    data = ""
                });

            case "Renter":
                var renterTicketCheck =
                    await _serviceWrapper.Tickets.GetTicketList(filter, userId, false, token);

                if (renterTicketCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Người thuê này hiện tại không có phiếu nào",
                        data = ""
                    });

                var renterTicketList = _mapper.Map<IEnumerable<TicketDetailEntity>>(renterTicketCheck);

                return Ok(new
                {
                    status = "Success",
                    message = "Hiển thị danh sách",
                    data = renterTicketList,
                    totalPage = renterTicketCheck.TotalPages,
                    totalCount = renterTicketCheck.TotalCount
                });

            case null:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Tài khoản không hợp lệ",
                    data = ""
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request with ticket controller !!!",
            data = ""
        });
    }

    [HttpPut("{id:int}/accept")]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation("[Authorize] Accept ticket resolution [For renter]")]
    public async Task<IActionResult> ApproveTicket(int id, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var entity = await _serviceWrapper.Tickets.GetTicketById(id, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không có phiếu nào được tìm thấy",
                data = ""
            });

        switch (userRole)
        {
            case "Renter" when User.Identity?.Name == entity.Contract.RenterId.ToString():

                var renterTicketCheck =
                    await _serviceWrapper.Tickets.GetTicketById(id, entity.Contract.RenterId, token);

                if (renterTicketCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "No ticket with this id found with this user",
                        data = ""
                    });

                if (renterTicketCheck.Status.ToLower() == "Confirming".ToLower())
                {
                    var approveTicket = await _serviceWrapper.Tickets.ApproveTicket(id, token);
                    switch (approveTicket.IsSuccess)
                    {
                        case true:
                            return Ok(new
                            {
                                status = "Success",
                                message = approveTicket.Message,
                                data = ""
                            });
                        case false:
                            return BadRequest(new
                            {
                                status = "Bad Request",
                                message = approveTicket.Message,
                                data = ""
                            });
                    }
                }

                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Chỉ có thể xác nhận khi trạng thái là đã xử lí",
                    data = ""
                });

            case null:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Không có phiếu nào được tìm thấy",
                    data = ""
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request !!!",
            data = ""
        });
    }

    // GET: api/Requests/5
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Technician, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket by id (For management and renter)")]
    public async Task<IActionResult> GetTicket(int id, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        var entity = await _serviceWrapper.Tickets.GetTicketById(id, token);

        if (entity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Phiếu không tồn tại",
                data = ""
            });

        switch (userRole)
        {
            case "Technician" or "Supervisor":
                return Ok(new
                {
                    status = "Success",
                    message = "Đã tìm thấy",
                    data = entity
                });

            case "Renter" when User.Identity?.Name == entity.Contract.RenterId.ToString():

                var renterTicketCheck =
                    await _serviceWrapper.Tickets.GetTicketById(id, entity.Contract.RenterId, token);

                if (renterTicketCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Không tìm thấy phiếu này từ tài khoản người dùng",
                        data = ""
                    });

                var ticket = new TicketDetailEntity
                {
                    TicketId = renterTicketCheck.TicketId,
                    Description = renterTicketCheck.Description,
                    TicketName = renterTicketCheck.TicketName,
                    CreateDate = renterTicketCheck.CreateDate,
                    SolveDate = renterTicketCheck.SolveDate,
                    Amount = renterTicketCheck.TotalAmount,
                    Status = renterTicketCheck.Status,
                    ContractId = renterTicketCheck.ContractId,
                    EmployeeId = renterTicketCheck.EmployeeId,
                    TicketTypeId = renterTicketCheck.TicketTypeId,
                    ImageUrls = new List<TicketImageUrlViewModel>
                    {
                        new()
                        {
                            ImageUrl1 = renterTicketCheck.ImageUrl1 ?? "",
                            ImageUrl2 = renterTicketCheck.ImageUrl2 ?? "",
                            ImageUrl3 = renterTicketCheck.ImageUrl3 ?? ""
                        }
                    }
                };

                return Ok(new
                {
                    status = "Success",
                    message = "Đã tìm thấy",
                    data = ticket
                });

            case null:
                return NotFound(new
                {
                    status = "Not Found",
                    message = "Không có phiếu nào được tìm thấy",
                    data = ""
                });
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bad request !!!",
            data = ""
        });
    }

    [HttpPut("{id:int}/accept-ticket")]
    [Authorize(Roles = "Technician, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Accept ticket to solve [For management]")]
    public async Task<IActionResult> AcceptTicket(int id, CancellationToken token)
    {
        var ticketEntity = await _serviceWrapper.Tickets.GetTicketById(id, token);

        if (ticketEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không có phiếu nào được tìm thấy",
                data = ""
            });

        var userId = int.Parse(User.Identity.Name);

        if (ticketEntity.Status.ToLower() == "Active".ToLower())
        {
            var acceptTicketResult = await _serviceWrapper.Tickets.AcceptTicket(id, userId, token);

            return acceptTicketResult.IsSuccess switch
            {
                true => Ok(new
                {
                    status = "Success",
                    message = acceptTicketResult.Message,
                    data = ""
                }),
                false => NotFound(new
                {
                    status = "Not Found",
                    message = acceptTicketResult.Message,
                    data = ""
                })
            };
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bạn chỉ có thể tiếp nhận phiếu chưa xử lí",
            data = ""
        });
    }

    [HttpPut("{id:int}/solve-ticket")]
    [Authorize(Roles = "Technician, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Accept ticket to solve [For management]")]
    public async Task<IActionResult> IsTicketSolved(int id, CancellationToken token)
    {
        var ticketEntity = await _serviceWrapper.Tickets.GetTicketById(id, token);

        if (ticketEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không có phiếu nào được tìm thấy",
                data = ""
            });

        if (ticketEntity.Status.ToLower() == "Processing".ToLower())
        {
            var acceptTicketResult = await _serviceWrapper.Tickets.SolveTicket(id, token);

            return acceptTicketResult.IsSuccess switch
            {
                true => Ok(new
                {
                    status = "Success",
                    message = acceptTicketResult.Message,
                    data = ""
                }),
                false => NotFound(new
                {
                    status = "Not Found",
                    message = acceptTicketResult.Message,
                    data = ""
                })
            };
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Bạn chỉ có thể xác nhận phiếu đang trong quá trình xử lí",
            data = ""
        });
    }

    // PUT: api/Requests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Technician, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update ticket by id (For management)",
        Description = "date format d/M/YYYY")]
    public async Task<IActionResult> PutTicket(int id, [FromBody] TicketUpdateRequest ticketUpdateRequest,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(ticketUpdateRequest, id, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var ticketEntity = await _serviceWrapper.Tickets.GetTicketById(id, token);

        if (ticketEntity == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Không có phiếu nào được tìm thấy",
                data = ""
            });

        var updateTicket = new Ticket
        {
            TicketId = id,
            TicketName = ticketUpdateRequest.TicketName ?? ticketEntity.TicketName,
            Description = ticketUpdateRequest.Description ?? ticketEntity.Description,
            TicketTypeId = ticketUpdateRequest.TicketTypeId ?? ticketEntity.TicketTypeId,
            Status = ticketUpdateRequest.Status ?? "Active",
            ImageUrl1 = ticketUpdateRequest.ImageUrl1 ?? ticketEntity.ImageUrl1,
            ImageUrl2 = ticketUpdateRequest.ImageUrl2 ?? ticketEntity.ImageUrl2,
            ImageUrl3 = ticketUpdateRequest.ImageUrl3 ?? ticketEntity.ImageUrl3,
            TotalAmount = ticketUpdateRequest.Amount ?? ticketEntity.TotalAmount ?? 0,
            SolveDate = ticketUpdateRequest.SolveDate.ConvertToDateTime() ?? ticketEntity.SolveDate,
            EmployeeId = ticketUpdateRequest.EmployeeId ?? int.Parse(User.Identity?.Name)
        };

        var result = await _serviceWrapper.Tickets.UpdateTicket(updateTicket);
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

    // POST: api/Requests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Renter")]
    [SwaggerOperation(Summary = "[Authorize] Create ticket (For renter)", Description = "date format d/M/YYYY")]
    public async Task<IActionResult> PostTicket([FromForm] TicketCreateRequest ticketCreateRequest,
        CancellationToken token)
    {
        var userId = int.Parse(User.Identity?.Name);

        var userCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

        if (userCheck == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "User not found",
                data = ""
            });

        var buildingId = await _serviceWrapper.GetId.GetBuildingIdBasedOnRenter(userId, token);

        if (buildingId == 0)
            return NotFound(new
            {
                status = "Not Found",
                message = "Building not found",
                data = ""
            });

        var supervisorId = await _serviceWrapper.GetId.GetSupervisorIdByBuildingId(buildingId, token);

        switch (supervisorId)
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
                    message = "More than one employee found for this building",
                    data = ""
                });
        }

        var contractId = await _serviceWrapper.GetId.GetContractIdBasedOnRenterId(userId, token);

        if (contractId == 0)
            return NotFound(new
            {
                status = "Not Found",
                message = "Contract not found for this renter, please contact management",
                data = ""
            });

        var validation = await _validator.ValidateParams(ticketCreateRequest, token);

        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });


        var newTicket = new Ticket
        {
            Description = ticketCreateRequest.Description,
            TicketName = ticketCreateRequest.TicketName,
            CreateDate = DateTime.UtcNow,
            TicketTypeId = ticketCreateRequest.TicketTypeId,
            // TODO : Auto assign to active invoice -> invoice detail if not assigned manually
            Status = "Active",
            TotalAmount = 0,
            ContractId = contractId,
            EmployeeId = supervisorId
        };

        var result = await _serviceWrapper.Tickets.AddTicket(newTicket);
        if (result == null)
            return BadRequest(new
            {
                status = "Bad Request",
                message = "Ticket failed to create",
                data = ""
            });

        var counter = 0;

        if (ticketCreateRequest.ImageUploadRequest != null)
            foreach (var image in ticketCreateRequest.ImageUploadRequest)
            {
                counter++;
                var imageExtension = ImageExtension.ImageExtensionChecker(image.FileName);

                switch (counter)
                {
                    case 1:
                        var fileNameCheck1 = newTicket.ImageUrl1?.Split('/').Last();

                        newTicket.ImageUrl1 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck1,
                            "Ticket", imageExtension, false))?.Blob.Uri;

                        break;

                    case 2:
                        var fileNameCheck2 = newTicket.ImageUrl2?.Split('/').Last();

                        newTicket.ImageUrl2 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck2,
                            "Ticket", imageExtension, false))?.Blob.Uri;

                        break;

                    case 3:
                        var fileNameCheck3 = newTicket.ImageUrl3?.Split('/').Last();

                        newTicket.ImageUrl3 = (await _serviceWrapper.AzureStorage.UpdateAsync(image, fileNameCheck3,
                            "Ticket", imageExtension, false))?.Blob.Uri;

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
            message = "Ticket created successfully",
            data = ""
        });
    }

    // DELETE: api/Requests/5
    [HttpDelete("{id:int}/user")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Delete ticket by id (For management and renter)")]
    public async Task<IActionResult> DeleteTicket(int id, CancellationToken token)
    {
        var userRole = User.Identities
            .FirstOrDefault()?.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)
            ?.Value ?? string.Empty;

        /*
        if (userRole is not ("Admin" or "Supervisor") || (User.Identity?.Name != id.ToString() && userRole != "Renter"))
            return BadRequest(new
            {
                status = "Bad Request",
                message = "You are not authorized to access this resource",
                data = ""
            });
        */

        var userId = int.Parse(User.Identity.Name);

        switch (userRole)
        {
            case "Renter":
                var renterCheck = await _serviceWrapper.Renters.GetRenterById(userId, token);

                if (renterCheck == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Người dùng không tìm thấy",
                        data = ""
                    });

                // pass renter Id and ticket Id to get, management can bypass restriction bound by token id
                var ticketEntity = await _serviceWrapper.Tickets.GetTicketById(id, userId, token);

                if (ticketEntity == null)
                    return NotFound(new
                    {
                        status = "Not Found",
                        message = "Phiếu yêu cầu không tìm thấy",
                        data = ""
                    });

                if (ticketEntity.Status.ToLower() == "Active".ToLower())
                {
                    var result = await _serviceWrapper.Tickets.DeleteTicket(id);
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

                return BadRequest(new
                {
                    status = "Bad Request",
                    message = "Bạn không thể xoá những phiếu đang xử lí",
                    data = ""
                });


            case "Supervisor":
                var resultSuper = await _serviceWrapper.Tickets.DeleteTicket(id);
                return resultSuper.IsSuccess switch
                {
                    true => Ok(new
                    {
                        status = "Success",
                        message = resultSuper.Message,
                        data = ""
                    }),
                    false => NotFound(new
                    {
                        status = "Not Found",
                        message = resultSuper.Message,
                        data = ""
                    })
                };
        }

        return BadRequest(new
        {
            status = "Bad Request",
            message = "Tài khoản không hợp lệ",
            data = ""
        });
    }

    // GET: api/RequestTypes
    [HttpGet("type")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket type list (For management and renter)")]
    public async Task<IActionResult> GetTicketTypes([FromQuery] TicketTypeFilterRequest request,
        CancellationToken token)
    {
        var filter = _mapper.Map<TicketTypeFilter>(request);

        var list = await _serviceWrapper.TicketTypes.GetTicketTypeList(filter, token);

        var resultList = _mapper.Map<IEnumerable<TicketTypeDetailEntity>>(list);

        if (list == null || !list.Any())
            return NotFound(new
            {
                status = "Not Found",
                message = "List not found",
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

    // GET: api/RequestTypes/5
    [HttpGet("type/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor, Renter")]
    [SwaggerOperation(Summary = "[Authorize] Get ticket type by id (For management and renter)")]
    public async Task<IActionResult> GetTicketType(int id, CancellationToken token)
    {
        var entity = await _serviceWrapper.TicketTypes.GetTicketTypeById(id, token);
        return entity == null
            ? NotFound(new
            {
                status = "Not Found",
                message = "Loại phiếu không tìm thấy",
                data = ""
            })
            : Ok(new
            {
                status = "Success",
                message = "Đã tìm thấy loại phiếu",
                data = _mapper.Map<TicketTypeDetailEntity>(entity)
            });
    }

    /*

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("type/{id:int}")]
    [Authorize(Roles = "Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Update ticket type by id (For management)")]
    public async Task<IActionResult> PutTicketType(int id,
        [FromBody] TicketTypeUpdateRequest ticketTypeUpdateRequestType)
    {
        var updateRequestType = new TicketType
        {
            TicketTypeId = id,
            Description = ticketTypeUpdateRequestType.Description,
            TicketTypeName = ticketTypeUpdateRequestType.Name,
            Status = true
        };

        var validation = await _validator.ValidateParams(updateRequestType, id);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var result = await _serviceWrapper.TicketTypes
            .UpdateTicketType(updateRequestType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Request type not found",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Request type updated",
            data = _mapper.Map<TicketTypeDto>(result)
        });
    }
    
    */

    /*
    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("type")]
    [Authorize(Roles = "Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Create ticket type (For management)")]
    public async Task<IActionResult> PostTicketType([FromBody] TicketTypeCreateRequest ticketTypeCreateRequestType,
        CancellationToken token)
    {
        var validation = await _validator.ValidateParams(ticketTypeCreateRequestType, token);
        if (!validation.IsValid)
            return BadRequest(new
            {
                status = "Bad Request",
                message = validation.Failures.FirstOrDefault(),
                data = ""
            });

        var newRequestType = new TicketType
        {
            Description = ticketTypeCreateRequestType.Description,
            TicketTypeName = ticketTypeCreateRequestType.Name,
            Status = true
        };


        var result = await _serviceWrapper.TicketTypes.AddTicketType(newRequestType);
        if (result == null)
            return NotFound(new
            {
                status = "Not Found",
                message = "Loại phiếu không tồn tại",
                data = ""
            });

        return Ok(new
        {
            status = "Success",
            message = "Loại phiếu đã được tạo",
            data = ""
        });
    }

    // DELETE: api/RequestTypes/5
    [HttpDelete("type/{id:int}")]
    [Authorize(Roles = " Admin, Supervisor")]
    [SwaggerOperation(Summary = "[Authorize] Delete ticket type by id (For management)")]
    public async Task<IActionResult> DeleteTicketType(int id)
    {
        var result = await _serviceWrapper.TicketTypes.DeleteTicketType(id);
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
    */
}
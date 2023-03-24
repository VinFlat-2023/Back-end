/*
using AutoMapper;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Wallet;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/wallets")]
[ApiController]
public class WalletController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public WalletController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallets")]
    [SwaggerOperation(Summary = "[Authorize] Get Wallet By authorized renter")]
    public async Task<IActionResult> GetWalletByAccountId()
    {
        var accountId = User.Identity.Name;
        if (accountId.IsNullOrEmpty() || accountId == "0")
            return BadRequest("The account is not available in our system!");
        var wallets = await _serviceWrapper.Wallets.GetWalletsByAccountId(int.Parse(accountId)).ToListAsync();
        if (wallets.Count == 0)
            return NotFound("This user does not have any wallet yet!");

        return Ok(_mapper.Map<List<WalletDto>>(wallets));
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallets")]
    [SwaggerOperation(Summary = "[Authorize] Create a Wallet")]
    public async Task<IActionResult> CreateWallet(WalletCreateRequest request)
    {
        var renterId = User.Identity.Name;

        if (renterId.IsNullOrEmpty() || renterId == "0")
            return BadRequest("The account is not available in our system!");

        var newWallet = new Wallet
        {
            WalletId = Guid.NewGuid(),
            RenterId = int.Parse(renterId),
            Balance = 0,
            CreatedDate = DateTime.Now,
            Status = 1,
            WalletTypeId = (int)request.WalletType
        };

        var result = await _serviceWrapper.Wallets.CreateWallet(newWallet);
        return result == null
            ? BadRequest("Create wallet failed!")
            : StatusCode(201, _mapper.Map<WalletDto>(result));
    }


    [HttpPut]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallets")]
    [SwaggerOperation(Summary = "[Authorize] Update a Wallet")]
    public async Task<IActionResult> UpdateWallet(WalletUpdateRequest request)
    {
        var renterId = User.Identity.Name;

        if (renterId.IsNullOrEmpty() || renterId == "0")
            return BadRequest("The account is not available in our system!");

        var wallet = new Wallet
        {
            WalletId = request.WalletId,
            Balance = request.Balance
        };

        var result = await _serviceWrapper.Wallets.UpdateWallet(wallet);
        return result == null
            ? BadRequest("Update wallet failed!")
            : StatusCode(200, _mapper.Map<WalletDto>(result));
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallets")]
    [SwaggerOperation(Summary = "[Authorize] Disable a Wallet")]
    public async Task<IActionResult> DisableWallet(Guid id)
    {
        var accountId = User.Identity?.Name;

        if (accountId.IsNullOrEmpty() || accountId == "0")
            return BadRequest("The account is not available in our system!");

        var result = await _serviceWrapper.Wallets
            .DisableWallet(id, int.Parse(accountId));
        return !result
            ? BadRequest("Cannot delete this wallet, please try again")
            : StatusCode(200, "Deleted");
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallets/types")]
    [SwaggerOperation(Summary = "[Authorize] Get All Wallet Types")]
    public async Task<IActionResult> GetAllWalletTypes()
    {
        var walletTypes = await _serviceWrapper.Wallets.GetAllWalletType().ToListAsync();
        if (!walletTypes.Any())
            return NotFound("There's no wallet type!");
        return Ok(_mapper.Map<List<WalletTypeDto>>(walletTypes));
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallet/type")]
    [SwaggerOperation(Summary = "[Authorize] Get wallet by its type")]
    public async Task<IActionResult> GetWalletByRenterIdAndType(WalletTypeEnum walletType)
    {
        var renterId = User.Identity.Name;

        if (renterId == null && !renterId.IsNullOrEmpty() && renterId != "0")
            return BadRequest("The renter is not available in our system!");

        var wallet = await _serviceWrapper.Wallets
            .GetWalletByRenterIdAndType(
                int.Parse(renterId),
                (int)walletType);
        if (wallet == null) return NotFound("Wallet not found!");
        var respond = _mapper.Map<WalletDto>(wallet);
        return Ok(respond);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Renter, Supervisor")]
    [Route("wallet/{id:guid}")]
    [SwaggerOperation(Summary = "[Authorize] Get Wallet By its ID")]
    public async Task<IActionResult> GetWalletById(Guid id)
    {
        var walletFound = await _serviceWrapper.Wallets.GetWalletById(id);
        if (walletFound == null) return NotFound("This wallet is not found!");
        return Ok(_mapper.Map<WalletDto>(walletFound));
    }
}
*/


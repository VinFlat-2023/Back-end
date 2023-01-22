using Application.IRepository;
using Domain.EntitiesForManagement;
using Service.IService;

namespace Service.Service;

public class WalletService : IWalletService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public WalletService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Wallet?> CreateWallet(Wallet wallet)
    {
        return await _repositoryWrapper.Wallets.CreateWallet(wallet);
    }

    public async Task<bool> DisableWallet(Guid walletId, int accountId)
    {
        return await _repositoryWrapper.Wallets.DisableWallet(walletId, accountId);
    }

    public IQueryable<WalletType?> GetAllWalletType()
    {
        return _repositoryWrapper.Wallets.GetAllWalletType();
    }

    public Task<Wallet?> GetWalletByRenterIdAndType(int accountId, int type)
    {
        return _repositoryWrapper.Wallets.GetWalletByRenterIdAndType(accountId, type);
    }

    public Task<Wallet?> GetWalletById(Guid walletId)
    {
        return _repositoryWrapper.Wallets.GetWalletById(walletId);
    }

    public IQueryable<Wallet> GetWalletsByAccountId(int accountId)
    {
        return _repositoryWrapper.Wallets.GetWalletsByRenterId(accountId);
    }

    public async Task<Wallet?> UpdateWallet(Wallet? wallet)
    {
        return await _repositoryWrapper.Wallets.UpdateWallet(wallet);
    }
}
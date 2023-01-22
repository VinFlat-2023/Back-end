using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IWalletService
{
    public IQueryable<WalletType?> GetAllWalletType();
    public IQueryable<Wallet> GetWalletsByAccountId(int accountId);
    public Task<Wallet?> GetWalletByRenterIdAndType(int accountId, int type);
    public Task<Wallet?> GetWalletById(Guid walletId);
    public Task<Wallet?> CreateWallet(Wallet wallet);
    public Task<Wallet?> UpdateWallet(Wallet? wallet);
    public Task<bool> DisableWallet(Guid walletId, int accountId);
}
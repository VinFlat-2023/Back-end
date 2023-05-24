/*
 using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IWalletRepository
{
    public IQueryable<WalletType?> GetAllWalletType();
    public IQueryable<Wallet> GetWalletsByRenterId(int renterId);
    public Task<Wallet?> GetWalletByRenterIdAndType(int renterId, int type);
    public Task<Wallet?> GetWalletById(Guid walletId);
    public Task<Wallet?> CreateWallet(Wallet wallet);
    public Task<Wallet?> UpdateWallet(Wallet? wallet);
    public Task<bool> DisableWallet(Guid walletId, int renterId);
}
*/


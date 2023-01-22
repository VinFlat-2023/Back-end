using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class WalletRepository : IWalletRepository
{
    private readonly ApplicationContext _context;

    public WalletRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Wallet?> CreateWallet(Wallet wallet)
    {
        await _context.Wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
        return await _context.Wallets.Where(w => w.WalletId == wallet.WalletId)
            .AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<bool> DisableWallet(Guid walletId, int renterId)
    {
        var wallet = await _context.Wallets
            .Where(w => w.WalletId == walletId && w.RenterId == renterId)
            .FirstOrDefaultAsync();
        if (wallet == null)
            return false;
        wallet.Status = 0;
        _context.Wallets.Update(wallet);
        await _context.SaveChangesAsync();
        return true;
    }

    public IQueryable<WalletType?> GetAllWalletType()
    {
        return _context.WalletTypes;
    }


    public IQueryable<Wallet> GetWalletsByRenterId(int renterId)
    {
        return _context.Wallets.Include(w => w.WalletType)
            .Where(w => w.Status == 1 && w.RenterId == renterId);
    }

    public async Task<Wallet?> GetWalletByRenterIdAndType(int renterId, int type)
    {
        return await _context.Wallets.Include(w => w.WalletType)
            .Where(w => w.Status == 1 && w.RenterId == renterId && w.WalletTypeId == type)
            .FirstOrDefaultAsync();
    }

    public async Task<Wallet?> GetWalletById(Guid walletId)
    {
        return await _context.Wallets.Include(w => w.WalletType)
            .Where(w => w.WalletId == walletId).FirstOrDefaultAsync();
    }

    public async Task<Wallet?> UpdateWallet(Wallet? wallet)
    {
        var walletFound = await _context.Wallets.Where(w => w.WalletId == wallet!.WalletId).FirstOrDefaultAsync();
        if (walletFound == null)
            return null;

        walletFound.Balance = wallet?.Balance ?? walletFound.Balance;
        _context.Wallets.Update(walletFound);
        await _context.SaveChangesAsync();
        return wallet;
    }
}
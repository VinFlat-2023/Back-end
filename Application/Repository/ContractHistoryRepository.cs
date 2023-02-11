using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ContractHistoryRepository : IContractHistoryRepository
{
    private readonly ApplicationContext _context;

    public ContractHistoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all contract history
    /// </summary>
    /// <returns></returns>
    public IQueryable<ContractHistory> GetContractHistoryList(ContractHistoryFilter filters)
    {
        return _context.ContractHistories
            .Where(x =>
                (filters.Description == null || x.Description.Contains(filters.Description))
                && (filters.ContractHistoryStatus == null || x.ContractHistoryStatus == filters.ContractHistoryStatus)
                && (filters.ContractId == null || x.ContractId == filters.ContractId))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get contract history by id
    /// </summary>
    /// <param name="contractHistoryId"></param>
    /// <returns></returns>
    public IQueryable<ContractHistory> GetContractHistoryDetail(int? contractHistoryId)
    {
        return _context.ContractHistories
            .Where(x => x.ContractHistoryId == contractHistoryId);
    }

    /// <summary>
    ///     AddExpenseHistory contract history
    /// </summary>
    /// <param name="contractHistory"></param>
    /// <returns></returns>
    public async Task<ContractHistory> AddContractHistory(ContractHistory contractHistory)
    {
        await _context.ContractHistories.AddAsync(contractHistory);
        await _context.SaveChangesAsync();
        return contractHistory;
    }

    /// <summary>
    ///     UpdateExpenseHistory contract history
    /// </summary>
    /// <param name="contractHistory"></param>
    /// <returns></returns>
    public async Task<ContractHistory?> UpdateContractHistory(ContractHistory? contractHistory)
    {
        var contractHistoryData = await _context.ContractHistories
            .FirstOrDefaultAsync(x => x.ContractId == contractHistory!.ContractHistoryId);
        if (contractHistoryData == null)
            return null;

        contractHistoryData.Description = contractHistory?.Description ?? contractHistoryData.Description;
        contractHistoryData.Price = contractHistory?.Price ?? contractHistoryData.Price;
        contractHistoryData.ContractExpiredDate =
            contractHistory?.ContractExpiredDate ?? contractHistoryData.ContractExpiredDate;
        contractHistoryData.ContractHistoryStatus =
            contractHistory?.ContractHistoryStatus ?? contractHistoryData.ContractHistoryStatus;

        await _context.SaveChangesAsync();

        return contractHistoryData;
    }

    /// <summary>
    ///     DeleteExpenseHistory contract history
    /// </summary>
    /// <param name="contractHistoryId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteContractHistory(int contractHistoryId)
    {
        var contractHistoryFound = await _context.ContractHistories
            .FirstOrDefaultAsync(x => x.ContractHistoryId == contractHistoryId);
        if (contractHistoryFound == null)
            return false;
        _context.ContractHistories.Remove(contractHistoryFound);
        await _context.SaveChangesAsync();
        return true;
    }
}
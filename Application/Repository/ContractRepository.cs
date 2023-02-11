using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ContractRepository : IContractRepository
{
    private readonly ApplicationContext _context;

    public ContractRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get a list of all contracts
    /// </summary>
    /// <returns></returns>
    public IQueryable<Contract> GetContractList(ContractFilter filters)
    {
        return _context.Contracts
            .Where(x =>
                (filters.Description == null || x.Description.Contains(filters.Description))
                && (filters.ContractStatus == null || x.ContractStatus == filters.ContractStatus)
                && (filters.Price == null || x.Price == filters.Price))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get contract details by id
    /// </summary>
    /// <param name="contractId"></param>
    /// <returns></returns>
    public IQueryable<Contract> GetContractDetail(int? contractId)
    {
        return _context.Contracts
            .Where(x => x.ContractId == contractId);
    }

    /// <summary>
    ///     AddExpenseHistory new contract
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    public async Task<Contract> AddContract(Contract contract)
    {
        await _context.Contracts.AddAsync(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    /// <summary>
    ///     UpdateExpenseHistory contract details by id
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    public async Task<Contract?> UpdateContract(Contract? contract)
    {
        var contractData = await _context.Contracts
            .FirstOrDefaultAsync(x => x.ContractId == contract!.ContractId);

        if (contractData == null)
            return null;

        //contractData.FlatId = contract?.FlatId ?? contractData.FlatId;
        contractData.DateSigned = contract?.DateSigned ?? contractData.DateSigned;
        contractData.EndDate = contract?.EndDate ?? contractData.EndDate;
        contractData.StartDate = contract?.StartDate ?? contractData.StartDate;
        contractData.ContractStatus = contract?.ContractStatus ?? contractData.ContractStatus;
        contractData.Price = contract?.Price ?? contractData.Price;
        // TODO : Check if flatId and its corresponding flat is available for rent
        // TODO : Check if this is correct and do we want to update all fields
        contractData.LastUpdated = DateTime.Now;
        // TODO : AddExpenseHistory a contract history table and add a new record to it using old contract data

        await _context.SaveChangesAsync();

        return contractData;
    }

    /// <summary>
    ///     DeleteExpenseHistory contract by id
    /// </summary>
    /// <param name="contractId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteContract(int contractId)
    {
        var contractFound = await _context.Contracts
            .FirstOrDefaultAsync(x => x.ContractId == contractId);
        if (contractFound == null)
            return false;
        _context.Contracts.Remove(contractFound);
        await _context.SaveChangesAsync();
        return true;
    }
}
using System.Globalization;
using Application.IRepository;
using Domain.CustomEntities;
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
        // TODO : Compare date time
        return _context.Contracts
            .Include(x => x.Renter)
            .Where(x =>
                (filters.ContractName == null ||
                 x.ContractName.ToLower().Contains(filters.ContractName.ToLower()))
                && (filters.Description == null ||
                    x.Description.ToLower().Contains(filters.Description.ToLower()))
                && (filters.PriceForWater == null || x.PriceForWater == filters.PriceForWater)
                && (filters.PriceForRent == null || x.PriceForRent == filters.PriceForRent)
                && (filters.PriceForElectricity == null || x.PriceForElectricity == filters.PriceForElectricity)
                && (filters.PriceForService == null || x.PriceForService == filters.PriceForService)
                && (filters.ContractStatus == null || x.ContractStatus.ToLower() == filters.ContractStatus.ToLower())
                && (filters.DateSigned == null || x.DateSigned == filters.DateSigned)
                && (filters.EndDate == null || x.EndDate == filters.EndDate)
                && (filters.StartDate == null || x.StartDate == filters.StartDate)
                && (filters.RenterId == null || x.RenterId == filters.RenterId)
                && (filters.LastUpdated == null || x.LastUpdated == filters.LastUpdated)
                && (filters.RenterUsername == null || x.Renter.Username.ToLower()
                    .Contains(filters.RenterUsername.ToLower()))
                && (filters.RenterPhoneNumber == null || x.Renter.Phone.ToLower()
                    .Contains(filters.RenterPhoneNumber.ToLower()))
                && (filters.RenterEmail == null || x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                && (filters.RenterFullname == null ||
                    x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower())))
            .AsNoTracking();
    }

    public IQueryable<Contract> GetContractList(ContractFilter filters, int userId, int? buildingId, bool isManagement)
    {
        return isManagement switch
        {
            // true = supervisor
            true => _context.Contracts
                .Include(x => x.Renter)
                .Where(x => x.Flat.Building.EmployeeId == userId)
                .Where(x =>
                    (filters.ContractName == null ||
                     x.ContractName.ToLower().Contains(filters.ContractName.ToLower()))
                    && (filters.Description == null ||
                        x.Description.ToLower().Contains(filters.Description.ToLower()))
                    && (filters.PriceForWater == null || x.PriceForWater == filters.PriceForWater)
                    && (filters.PriceForRent == null || x.PriceForRent == filters.PriceForRent)
                    && (filters.PriceForElectricity == null || x.PriceForElectricity == filters.PriceForElectricity)
                    && (filters.PriceForService == null || x.PriceForService == filters.PriceForService)
                    && (filters.ContractStatus == null ||
                        x.ContractStatus.ToLower() == filters.ContractStatus.ToLower())
                    && (filters.DateSigned == null || x.DateSigned == filters.DateSigned)
                    && (filters.EndDate == null || x.EndDate == filters.EndDate)
                    && (filters.StartDate == null || x.StartDate == filters.StartDate)
                    && (filters.LastUpdated == null || x.LastUpdated == filters.LastUpdated)
                    && (filters.RenterUsername == null || x.Renter.Username.ToLower()
                        .Contains(filters.RenterUsername.ToLower()))
                    && (filters.RenterPhoneNumber == null || x.Renter.Phone.ToLower()
                        .Contains(filters.RenterPhoneNumber.ToLower()))
                    && (filters.RenterEmail == null || x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                    && (filters.RenterFullname == null ||
                        x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower())))
                .AsNoTracking(),

            // false = renter
            false => _context.Contracts
                .Include(x => x.Renter)
                .Include(x => x.Flat)
                .ThenInclude(x => x.Building)
                .Where(x => x.RenterId == userId && x.BuildingId == buildingId)
                .Where(x =>
                    (filters.ContractName == null ||
                     x.ContractName.ToLower().Contains(filters.ContractName.ToLower()))
                    && (filters.Description == null ||
                        x.Description.ToLower().Contains(filters.Description.ToLower()))
                    && (filters.PriceForWater == null || x.PriceForWater == filters.PriceForWater)
                    && (filters.PriceForRent == null || x.PriceForRent == filters.PriceForRent)
                    && (filters.PriceForElectricity == null || x.PriceForElectricity == filters.PriceForElectricity)
                    && (filters.PriceForService == null || x.PriceForService == filters.PriceForService)
                    && (filters.ContractStatus == null ||
                        x.ContractStatus.ToLower() == filters.ContractStatus.ToLower())
                    && (filters.DateSigned == null || x.DateSigned == filters.DateSigned)
                    && (filters.EndDate == null || x.EndDate == filters.EndDate)
                    && (filters.StartDate == null || x.StartDate == filters.StartDate)
                    && (filters.RenterId == null || x.RenterId == filters.RenterId)
                    && (filters.LastUpdated == null || x.LastUpdated == filters.LastUpdated)
                    && (filters.RenterUsername == null || x.Renter.Username.ToLower()
                        .Contains(filters.RenterUsername.ToLower()))
                    && (filters.RenterPhoneNumber == null || x.Renter.Phone.ToLower()
                        .Contains(filters.RenterPhoneNumber.ToLower()))
                    && (filters.RenterEmail == null || x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                    && (filters.RenterFullname == null ||
                        x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower())))
                .AsNoTracking()
        };
    }

    public IQueryable<Contract> GetContractHistoryList(ContractHistoryFilter filters)
    {
        return _context.Contracts
            .TemporalAll()
            .Include(x => x.Renter)
            .Where(x => x.Renter.RenterId == x.RenterId)
            // filter starts here
            .Where(x =>
                (filters.ContractName == null ||
                 x.ContractName.ToLower().Contains(filters.ContractName.ToLower()))
                && (filters.ContractId == null || x.ContractId == filters.ContractId)
                && (filters.ContractStatus == null || x.ContractStatus == filters.ContractStatus)
                && (filters.RenterId == null || x.RenterId == filters.RenterId))
            .Reverse();
    }

    /// <summary>
    ///     Get contract details by id
    /// </summary>
    /// <param name="contractId"></param>
    /// <returns></returns>
    public IQueryable<Contract?> GetContractDetail(int? contractId)
    {
        return _context.Contracts
            .Include(x => x.Renter)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Rooms)
            .Where(x => x.ContractId == contractId)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Building)
            .ThenInclude(x => x.Employee);
    }

    public IQueryable<Contract?> GetContractByRenterId(int renterId)
    {
        return _context.Contracts
            .Include(x => x.Renter)
            .Where(x => x.RenterId == renterId);
    }

    public IQueryable<Contract?> GetContractHistoryDetail(int contractId)
    {
        return _context.Contracts
            .Where(x => x.ContractId == contractId);
    }

    /// <summary>
    ///     AddExpenseHistory new contract
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    public async Task<Contract?> AddContract(Contract contract)
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
    public async Task<RepositoryResponse> UpdateContract(Contract? contract)
    {
        var contractData = await _context.Contracts
            .FirstOrDefaultAsync(x => x.ContractId == contract!.ContractId);

        if (contractData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Contract not found"
            };

        //contractData.FlatId = contract?.FlatId ?? contractData.FlatId;
        contractData.DateSigned = contract?.DateSigned ?? contractData.DateSigned;
        contractData.ContractName = contract?.ContractName ?? contractData.ContractName;
        contractData.EndDate = contract?.EndDate ?? contractData.EndDate;
        contractData.StartDate = contract?.StartDate ?? contractData.StartDate;
        contractData.ContractStatus = contract?.ContractStatus ?? contractData.ContractStatus;
        contractData.PriceForElectricity = contract?.PriceForElectricity ?? contractData.PriceForElectricity;
        contractData.PriceForService = contract?.PriceForService ?? contractData.PriceForService;
        contractData.PriceForWater = contract?.PriceForWater ?? contractData.PriceForWater;
        contractData.PriceForRent = contract?.PriceForRent ?? contractData.PriceForRent;
        contractData.LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
            "dd/MM/yyyy HH:mm:ss", null);

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Contract updated"
        };
    }

    /// <summary>
    ///     DeleteExpenseHistory contract by id
    /// </summary>
    /// <param name="contractId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteContract(int contractId)
    {
        var contractFound = await _context.Contracts
            .FirstOrDefaultAsync(x => x.ContractId == contractId);
        if (contractFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Contract not found"
            };
        _context.Contracts.Remove(contractFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Contract deleted"
        };
    }
}
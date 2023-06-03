using System.Data;
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
                && (filters.RenterPhoneNumber == null || x.Renter.PhoneNumber.ToLower()
                    .Contains(filters.RenterPhoneNumber.ToLower()))
                && (filters.RenterEmail == null || x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                && (filters.RenterFullname == null ||
                    x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower())))
            .AsNoTracking();
    }

    public IQueryable<Contract> GetContractList(ContractFilter filters, int? buildingId, int? userId, bool isManagement)
    {
        return isManagement switch
        {
            // true = supervisor
            true => _context.Contracts
                .Include(x => x.Renter)
                .Include(x => x.Flat)
                .Where(x => x.BuildingId == buildingId)
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
                    && (filters.RenterPhoneNumber == null || x.Renter.PhoneNumber.ToLower()
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
                .Where(x => x.RenterId == userId)
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
                    && (filters.RenterPhoneNumber == null || x.Renter.PhoneNumber.ToLower()
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
    public IQueryable<Contract?> GetContractById(int? contractId)
    {
        return _context.Contracts
            .Include(x => x.Renter)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Rooms)
            .Where(x => x.ContractId == contractId && x.ContractStatus.ToLower() == "active")
            .Include(x => x.Flat)
            .ThenInclude(x => x.Building)
            .ThenInclude(x => x.Employee);
    }

    public IQueryable<Contract?> GetContractById(int? contractId, int buildingId)
    {
        return _context.Contracts
            .Include(x => x.Renter)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Building)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Rooms)
            .Where(x => x.ContractId == contractId && x.BuildingId == buildingId)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Building)
            .ThenInclude(x => x.Employee);
    }

    public IQueryable<Contract?> GetContractByRenterId(int? renterId)
    {
        return _context.Contracts
            .Include(x => x.Renter)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Rooms)
            .Include(x => x.Flat)
            .ThenInclude(x => x.Building)
            .ThenInclude(x => x.Employee)
            .Where(x => x.RenterId == renterId && x.ContractStatus.ToLower() == "active");
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
    public async Task<RepositoryResponse> UpdateContract(Contract contract)
    {
        var contractData = await _context.Contracts
            .FirstOrDefaultAsync(x => x.ContractId == contract!.ContractId);

        if (contractData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Hợp đồng không tồn tại"
            };

        //contractData.FlatId = contract?.FlatId ?? contractData.FlatId;

        contractData.ContractName = contract.ContractName;
        contractData.Description = contract.Description;

        contractData.DateSigned = contract.DateSigned;
        contractData.StartDate = contract.StartDate;
        contractData.EndDate = contract.EndDate;
        contractData.LastUpdated = contract.LastUpdated;

        contractData.ContractStatus = contract.ContractStatus;

        contractData.PriceForElectricity = contract.PriceForElectricity;
        contractData.PriceForService = contract.PriceForService;
        contractData.PriceForWater = contract.PriceForWater;
        contractData.PriceForRent = contract.PriceForRent;

        contractData.ContractImageUrl1 = contract.ContractImageUrl1;
        contractData.ContractImageUrl2 = contract.ContractImageUrl2;
        contractData.ContractImageUrl3 = contract.ContractImageUrl3;
        contractData.ContractImageUrl4 = contract.ContractImageUrl4;

        _context.Attach(contractData).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Hợp đồng đã được cập nhật"
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
                Message = "Hợp đồng không tồn tại"
            };
        _context.Contracts.Remove(contractFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Contract deleted"
        };
    }

    public async Task<RepositoryResponse> AddContractWithRenter(Contract newContract, Renter newRenter,
        CancellationToken token)
    {
        await using var transaction =
            await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, token);
        try
        {
            await _context.Renters.AddAsync(newRenter, token);

            await _context.SaveChangesAsync(token);

            newContract.RenterId = newRenter.RenterId;

            await _context.Contracts.AddAsync(newContract, token);

            await _context.SaveChangesAsync(token);

            var roomCheck = await _context.Rooms.FirstOrDefaultAsync(x
                => x.RoomId == newContract.RoomId
                   && x.FlatId == newContract.FlatId
                   && x.Status.ToLower() == "active", token);

            if (roomCheck is not { AvailableSlots: > 0 })
            {
                await transaction.RollbackAsync(token);
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Phòng đã đầy"
                };
            }

            // update room slot
            var availableSlots = roomCheck.AvailableSlots -= 1;

            // if slot = 0, change room status to full
            if (availableSlots == 0) roomCheck.Status = "Full";

            await _context.SaveChangesAsync(token);

            await transaction.CommitAsync(token);

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tạo hợp đồng thành công"
            };
        }
        catch
        {
            await transaction.RollbackAsync(token);
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo hợp đồng thất bại"
            };
        }
    }

    public async Task<RepositoryResponse> AddContractWithRenter(Contract newContract, CancellationToken token)
    {
        await using var transaction =
            await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, token);
        try
        {
            await _context.Contracts.AddAsync(newContract, token);

            await _context.SaveChangesAsync(token);

            var roomCheck = await _context.Rooms.FirstOrDefaultAsync(x
                => x.RoomId == newContract.RoomId
                   && x.FlatId == newContract.FlatId
                   && x.Status.ToLower() == "active", token);

            if (roomCheck is not { AvailableSlots: > 0 })
            {
                await transaction.RollbackAsync(token);
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Phòng đã đầy"
                };
            }

            // update room slot
            var availableSlots = roomCheck.AvailableSlots -= 1;

            // if slot = 0, change room status to full
            if (availableSlots == 0) roomCheck.Status = "Full";

            _context.Attach(roomCheck).State = EntityState.Modified;

            await _context.SaveChangesAsync(token);

            await transaction.CommitAsync(token);

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tạo hợp đồng thành công"
            };
        }
        catch
        {
            await transaction.RollbackAsync(token);
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo hợp đồng thất bại"
            };
        }
    }

    public IQueryable<int> GetTotalRenterWithActiveContract(MetricRenterContractFilter filter, int buildingId)
    {
        return _context.Contracts
            .Where(x => x.BuildingId == buildingId)
            .Where(x => filter.Status == null || x.ContractStatus == filter.Status)
            .DistinctBy(x => x.RenterId)
            .Select(x => x.ContractId);
    }
}
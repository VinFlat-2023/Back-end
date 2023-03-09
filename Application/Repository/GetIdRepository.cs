using Application.IRepository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class GetIdRepository : IGetIdRepository
{
    private readonly ApplicationContext _context;

    public GetIdRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<int?> GetBuildingIdBasedOnRenter(int renterId)
    {
        var contract = await _context.Contracts
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (contract == null)
            return null;

        return await _context.Contracts
            .Where(x => x.ContractId == contract.ContractId)
            .Select(x => x.BuildingId)
            .FirstOrDefaultAsync();
    }

    public async Task<int?> GetAccountIdBasedOnBuildingId(int? buildingId)
    {
        var room = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId);

        if (room == null)
            return null;

        return await _context.Buildings
            .Where(x => x.BuildingId == buildingId)
            .Select(x => x.AccountId)
            .FirstOrDefaultAsync();
    }

    public async Task<int?> GetContractIdBasedOnRenterId(int? renterId)
    {
        return await _context.Contracts
            .Where(x => x.RenterId == renterId && x.ContractStatus == "Active")
            .Select(x => x.ContractId)
            .FirstOrDefaultAsync();
    }
}
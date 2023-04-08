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

    public async Task<int> GetBuildingIdBasedOnRenter(int renterId, CancellationToken token)
    {
        var contract = await _context.Contracts
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (contract == null)
            return 0;

        return await _context.Contracts
            .Where(x => x.ContractId == contract.ContractId)
            .Select(x => x.BuildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<int> GetContractIdBasedOnRenterId(int renterId, CancellationToken token)
    {
        return await _context.Contracts
            .Where(x => x.RenterId == renterId)
            .Select(x => x.ContractId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<int> GetActiveContractIdBasedOnRenterId(int renterId, CancellationToken token)
    {
        return await _context.Contracts
            .Where(x => x.RenterId == renterId && x.ContractStatus == "Active")
            .Select(x => x.ContractId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<int> GetRoomIdBasedOnFlatId(int flatId, CancellationToken token)
    {
        return await _context.Rooms
            .Where(x => x.FlatId == flatId)
            .Select(x => x.RoomId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId, CancellationToken token)
    {
        return await _context.Buildings
            .Where(x => x.EmployeeId == employeeId)
            .Select(x => x.BuildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<int> GetSupervisorIdByBuildingId(int entityBuildingId, CancellationToken token)
    {
        var employeeList = await _context.Employees
            .Include(x => x.Role)
            .Where(x => x.Role.RoleName.ToLower() == "Supervisor".ToLower())
            .Select(x => x.EmployeeId)
            .ToListAsync(token);

        return await _context.Buildings
            .Include(x => x.Employee)
            .ThenInclude(x => x.Role)
            //.Where(x => x.BuildingId == entityBuildingId)
            .Where(x => x.BuildingId == entityBuildingId
                        && employeeList.Contains(x.EmployeeId))
            .Select(x => x.EmployeeId)
            .FirstOrDefaultAsync(token);
    }
}
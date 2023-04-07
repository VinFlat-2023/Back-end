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

    public async Task<int> GetBuildingIdBasedOnRenter(int renterId)
    {
        var contract = await _context.Contracts
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (contract == null)
            return 0;

        return await _context.Contracts
            .Where(x => x.ContractId == contract.ContractId)
            .Select(x => x.BuildingId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetEmployeeIdBasedOnBuildingId(int buildingId)
    {
        var room = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId);

        if (room == null)
            return 0;

        return await _context.Buildings
            .Where(x => x.BuildingId == buildingId)
            .Select(x => x.EmployeeId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetContractIdBasedOnRenterId(int renterId)
    {
        return await _context.Contracts
            .Where(x => x.RenterId == renterId)
            .Select(x => x.ContractId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetActiveContractIdBasedOnRenterId(int renterId)
    {
        return await _context.Contracts
            .Where(x => x.RenterId == renterId && x.ContractStatus == "Active")
            .Select(x => x.ContractId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetRoomIdBasedOnFlatId(int flatId)
    {
        return await _context.Rooms
            .Where(x => x.FlatId == flatId)
            .Select(x => x.RoomId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId)
    {
        return await _context.Buildings
            .Where(x => x.EmployeeId == employeeId)
            .Select(x => x.BuildingId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetSupervisorIdByBuildingId(int entityBuildingId)
    {
        return await _context.Buildings
            .Where(x => x.BuildingId == entityBuildingId)
            .Include(x => x.Employee)
            .ThenInclude(x => x.Role)
            .Where(x => x.Employee.Role.RoleName == "Supervisor")
            .Select(x => x.Employee.EmployeeId)
            .FirstOrDefaultAsync();
    }
}
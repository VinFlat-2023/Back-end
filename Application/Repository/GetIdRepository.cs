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
            .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

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

    /*
    public async Task<int> GetRoomIdBasedOnFlatId(int flatId, CancellationToken token)
    {
        return await _context.Rooms
            .Where(x => x.FlatId == flatId)
            .Select(x => x.RoomId)
            .FirstOrDefaultAsync(token);
    }
    */

    public async Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId, CancellationToken token)
    {
        var buildingList = _context.Buildings
            .Where(x => x.EmployeeId == employeeId && x.Status == true)
            .Select(x => x.BuildingId);

        var count = buildingList.Count();

        return count switch
        {
            // -2 = More than one building with status "Active" found
            > 1 => -2,
            // -1 = No building found with status "Active" or no building found at all
            < 1 => -1,
            _ => await buildingList.FirstOrDefaultAsync(token)
        };
    }

    public async Task<int> GetBuildingIdBasedOnTechnicianId(int technicianId, CancellationToken token)
    {
        var building = await _context.Employees
            .Where(x => x.EmployeeId == technicianId && x.Status == true)
            .Select(x => x.TechnicianBuildingId)
            .FirstOrDefaultAsync(token);
        if (building == 0 || building == null)
            return 0;
        return building.Value;
    }

    public async Task<int?> GetSupervisorIdByBuildingId(int entityBuildingId, CancellationToken token)
    {
        var employeeList = await _context.Employees
            .Include(x => x.Role)
            .Where(x =>
                x.Role.RoleName.ToLower() == "supervisor".ToLower()
                && x.SupervisorBuildingId == entityBuildingId)
            .Select(x => x.EmployeeId)
            .ToListAsync(token);

        if (employeeList.Count == 0)
            return 0;

        var employee = _context.Buildings
            .Include(x => x.Employee)
            .ThenInclude(x => x.Role)
            //.Where(x => x.BuildingId == entityBuildingId)
            .Where(x => x.BuildingId == entityBuildingId
                        && employeeList.Contains(x.EmployeeId.Value) && x.Status == true)
            .Select(x => x.EmployeeId);

        if (employee.Count() > 1 || !employee.Any())
            return -1;

        return await employee.FirstOrDefaultAsync(token);
    }
}
namespace Application.IRepository;

public interface IGetIdRepository
{
    Task<int> GetBuildingIdBasedOnRenter(int renterId);

    Task<int> GetEmployeeIdBasedOnBuildingId(int buildingId);

    Task<int> GetContractIdBasedOnRenterId(int renterId);
    Task<int> GetActiveContractIdBasedOnRenterId(int renterId);
    Task<int> GetRoomIdBasedOnFlatId(int flatId);
    Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId);
    Task<int> GetSupervisorIdByBuildingId(int entityBuildingId);
}
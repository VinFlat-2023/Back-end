namespace Service.IService;

public interface IGetIdService
{
    Task<int> GetBuildingIdBasedOnRenterActiveContract(int renterId, CancellationToken token);
    Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId, CancellationToken token);
    Task<int> GetContractIdBasedOnRenterId(int renterId, CancellationToken token);

    Task<int> GetActiveContractIdBasedOnRenterId(int renterId, CancellationToken token);

    // Task<int> GetRoomIdBasedOnFlatId(int flatId, CancellationToken token);
    Task<int> GetBuildingIdBasedOnTechnicianId(int employeeId, CancellationToken token);
    Task<int?> GetSupervisorIdByBuildingId(int entityBuildingId, CancellationToken token);
}
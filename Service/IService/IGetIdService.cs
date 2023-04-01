namespace Service.IService;

public interface IGetIdService
{
    Task<int> GetBuildingIdBasedOnRenter(int renterId);
    Task<int> GetAccountIdBasedOnBuildingId(int buildingId);
    Task<int> GetBuildingIdBasedOnSupervisorId(int accountId);
    Task<int> GetContractIdBasedOnRenterId(int renterId);
    Task<int> GetActiveContractIdBasedOnRenterId(int renterId);
    Task<int> GetRoomIdBasedOnFlatId(int flatId);
    Task<int> GetSupervisorIdByBuildingId(int entityBuildingId);
}
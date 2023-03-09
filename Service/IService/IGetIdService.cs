namespace Service.IService;

public interface IGetIdService
{
    Task<int?> GetBuildingIdBasedOnRenter(int renterId);
    Task<int?> GetAccountIdBasedOnBuildingId(int? buildingId);
    Task<int?> GetContractIdBasedOnRenterId(int? renterId);
}
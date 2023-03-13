namespace Application.IRepository;

public interface IGetIdRepository
{
    Task<int?> GetBuildingIdBasedOnRenter(int renterId);

    Task<int?> GetAccountIdBasedOnBuildingId(int? buildingId);

    Task<int?> GetContractIdBasedOnRenterId(int? renterId);
    Task<int?> GetActiveContractIdBasedOnRenterId(int? renterId);
    Task<int?> GetRoomIdBasedOnFlatId(int? flatId);
}
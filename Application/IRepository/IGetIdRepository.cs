namespace Application.IRepository;

public interface IGetIdRepository
{
    Task<int?> GetBuildingIdBasedOnRenter(int renterId);

    Task<int?> GetAccountIdBasedOnBuildingId(int? buildingId);

    Task<int?> GetContractIdBasedOnRenterId(int? renterId);
}
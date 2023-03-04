using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class GetIdService : IGetIdService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetIdService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<int?> GetBuildingIdBasedOnRenter(int renterId)
    {
        return await _repositoryWrapper.GetId.GetBuildingIdBasedOnRenter(renterId);
    }

    public async Task<int?> GetAccountIdBasedOnBuildingId(int? buildingId)
    {
        return await _repositoryWrapper.GetId.GetAccountIdBasedOnBuildingId(buildingId);
    }

    public async Task<int?> GetContractIdBasedOnRenterId(int? renterId)
    {
        return await _repositoryWrapper.GetId.GetContractIdBasedOnRenterId(renterId);
    }
}
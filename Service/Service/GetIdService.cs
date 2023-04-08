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

    public async Task<int> GetBuildingIdBasedOnRenter(int renterId, CancellationToken token)
    {
        return await _repositoryWrapper.GetId.GetBuildingIdBasedOnRenter(renterId, token);
    }

    public async Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId, CancellationToken token)
    {
        return await _repositoryWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId, token);
    }

    public async Task<int> GetContractIdBasedOnRenterId(int renterId, CancellationToken token)
    {
        return await _repositoryWrapper.GetId.GetContractIdBasedOnRenterId(renterId, token);
    }

    public async Task<int> GetActiveContractIdBasedOnRenterId(int renterId, CancellationToken token)
    {
        return await _repositoryWrapper.GetId.GetActiveContractIdBasedOnRenterId(renterId, token);
    }

    public async Task<int> GetRoomIdBasedOnFlatId(int flatId, CancellationToken token)
    {
        return await _repositoryWrapper.GetId.GetRoomIdBasedOnFlatId(flatId, token);
    }

    public async Task<int> GetSupervisorIdByBuildingId(int entityBuildingId, CancellationToken token)
    {
        return await _repositoryWrapper.GetId.GetSupervisorIdByBuildingId(entityBuildingId, token);
    }
}
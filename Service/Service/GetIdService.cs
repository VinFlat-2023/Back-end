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

    public async Task<int> GetBuildingIdBasedOnRenter(int renterId)
    {
        return await _repositoryWrapper.GetId.GetBuildingIdBasedOnRenter(renterId);
    }

    public async Task<int> GetEmployeeIdBasedOnBuildingId(int buildingId)
    {
        return await _repositoryWrapper.GetId.GetEmployeeIdBasedOnBuildingId(buildingId);
    }

    public async Task<int> GetBuildingIdBasedOnSupervisorId(int employeeId)
    {
        return await _repositoryWrapper.GetId.GetBuildingIdBasedOnSupervisorId(employeeId);
    }

    public async Task<int> GetContractIdBasedOnRenterId(int renterId)
    {
        return await _repositoryWrapper.GetId.GetContractIdBasedOnRenterId(renterId);
    }

    public async Task<int> GetActiveContractIdBasedOnRenterId(int renterId)
    {
        return await _repositoryWrapper.GetId.GetActiveContractIdBasedOnRenterId(renterId);
    }

    public async Task<int> GetRoomIdBasedOnFlatId(int flatId)
    {
        return await _repositoryWrapper.GetId.GetRoomIdBasedOnFlatId(flatId);
    }

    public async Task<int> GetSupervisorIdByBuildingId(int entityBuildingId)
    {
        return await _repositoryWrapper.GetId.GetSupervisorIdByBuildingId(entityBuildingId);
    }
}
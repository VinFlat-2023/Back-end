using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IContractHistoryService
{
    public Task<PagedList<ContractHistory>?> GetContractHistoryList(ContractHistoryFilter filters,
        CancellationToken token);

    public Task<ContractHistory?> GetContractHistoryById(int? contractHistoryId);
    public Task<ContractHistory?> AddContractHistory(ContractHistory contractHistory);
    public Task<ContractHistory?> UpdateContractHistory(ContractHistory contractHistory);
    public Task<bool> DeleteContractHistory(int contractHistoryId);
}
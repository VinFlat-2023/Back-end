using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IContractHistoryRepository
{
    public IQueryable<ContractHistory> GetContractHistoryList(ContractHistoryFilter filters);
    public IQueryable<ContractHistory> GetContractHistoryDetail(int? contractHistoryId);
    public Task<ContractHistory> AddContractHistory(ContractHistory contractHistory);
    public Task<ContractHistory?> UpdateContractHistory(ContractHistory contractHistory);
    public Task<bool> DeleteContractHistory(int contractHistory);
}
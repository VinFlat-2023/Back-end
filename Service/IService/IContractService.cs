using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IContractService
{
    public Task<PagedList<Contract>?> GetContractList(ContractFilter filters, CancellationToken token);
    public Task<Contract?> GetContractHistoryById(int contractId);
    public Task<PagedList<Contract>?> GetContractHistoryList(ContractHistoryFilter filters, CancellationToken token);
    public Task<Contract?> GetContractById(int? contractId);
    public Task<Contract?> GetContractByIdWithActiveStatus(int contractId);
    public Task<Contract?> GetLatestContractByUserId(int renterId, CancellationToken token);
    public Task<Contract?> AddContract(Contract contract);
    public Task<RepositoryResponse> UpdateContract(Contract contract);
    public Task<RepositoryResponse> DeleteContract(int contractId);
}
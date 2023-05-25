using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.FilterRequests;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IContractRepository
{
    public IQueryable<Contract> GetContractList(ContractFilter filters);
    public IQueryable<Contract> GetContractList(ContractFilter filters, int? id, bool isManagement);
    public IQueryable<Contract> GetContractHistoryList(ContractHistoryFilter filters);
    public IQueryable<Contract?> GetContractById(int? contractId);
    public IQueryable<Contract?> GetContractById(int? contractId, int buildingId);
    public IQueryable<Contract?> GetContractByRenterId(int? renterId);
    public IQueryable<Contract?> GetContractHistoryDetail(int contractId);
    public Task<Contract?> AddContract(Contract contract);
    public Task<RepositoryResponse> UpdateContract(Contract contract);
    public Task<RepositoryResponse> DeleteContract(int contractId);

    public Task<RepositoryResponse> AddContractWithRenter(Contract newContract, Renter newRenter,
        CancellationToken token);

    public Task<RepositoryResponse> AddContractWithRenter(Contract newContract, CancellationToken token);
    public IQueryable<int> GetTotalRenterWithActiveContract(MetricRenterContractFilter filter, int buildingId);
}
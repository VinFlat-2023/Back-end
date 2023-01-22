using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IContractRepository
{
    public IQueryable<Contract> GetContractList(ContractFilter filters);
    public IQueryable<Contract> GetContractDetail(int? contractId);
    public Task<Contract> AddContract(Contract contract);
    public Task<Contract?> UpdateContract(Contract contract);
    public Task<bool> DeleteContract(int contractId);
}
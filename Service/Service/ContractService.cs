using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class ContractService : IContractService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Contract>?> GetContractHistoryList(ContractHistoryFilter filters,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Contracts.GetContractHistoryList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Contract>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Contract>?> GetContractList(ContractFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Contracts.GetContractList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Contract>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Contract>?> GetContractList(ContractFilter filters, int? id,
        bool isManagement,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Contracts.GetContractList(filters, id, isManagement);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Contract>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Contract?> GetContractById(int? contractId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractDetail(contractId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Contract?> GetContractByRenterIdWithActiveStatus(int contractId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractDetail(contractId)
            .FirstOrDefaultAsync(x => x != null && x.ContractStatus == "Active", token);
    }

    public async Task<Contract?> GetLatestContractByUserId(int renterId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractByRenterId(renterId)
            .OrderBy(x => x.CreatedDate)
            .LastOrDefaultAsync(token);
    }

    public async Task<Contract?> GetContractHistoryById(int contractId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractHistoryDetail(contractId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Contract?> AddContract(Contract contract)
    {
        return await _repositoryWrapper.Contracts.AddContract(contract);
    }

    public async Task<RepositoryResponse> UpdateContract(Contract contract)
    {
        return await _repositoryWrapper.Contracts.UpdateContract(contract);
    }

    public async Task<RepositoryResponse> DeleteContract(int contractId)
    {
        return await _repositoryWrapper.Contracts.DeleteContract(contractId);
    }

    public async Task<RepositoryResponse> AddContractWithRenter(Contract newContract, Renter newRenter,
        CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.AddContractWithRenter(newContract, newRenter, token);
    }
}
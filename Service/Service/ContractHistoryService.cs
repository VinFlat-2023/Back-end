using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class ContractHistoryService : IContractHistoryService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractHistoryService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<ContractHistory>?> GetContractHistoryList(ContractHistoryFilter filters,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.ContractHistories.GetContractHistoryList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<ContractHistory>
            .Create(queryable, page, size, token);

        return pagedList;
    }
 
    public async Task<ContractHistory?> GetContractHistoryById(int? contractHistoryId)
    {
        return await _repositoryWrapper.ContractHistories.GetContractHistoryDetail(contractHistoryId)
            .FirstOrDefaultAsync();
    }

    public async Task<ContractHistory?> AddContractHistory(ContractHistory contractHistory)
    {
        return await _repositoryWrapper.ContractHistories.AddContractHistory(contractHistory);
    }

    public async Task<ContractHistory?> UpdateContractHistory(ContractHistory contractHistory)
    {
        return await _repositoryWrapper.ContractHistories.UpdateContractHistory(contractHistory);
    }

    public async Task<bool> DeleteContractHistory(int contractHistoryId)
    {
        return await _repositoryWrapper.ContractHistories.DeleteContractHistory(contractHistoryId);
    }
}
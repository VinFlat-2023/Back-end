using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class ContractService : IContractService
{
    private readonly string _cacheKey = "contract";
    private readonly string _cacheKeyPageNumber = "page-number-contract";
    private readonly string _cacheKeyPageSize = "page-size-contract";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Contract>?> GetContractHistoryList(ContractHistoryFilter filters,
        CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Area>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                /*
                var matches = cacheDataList.Where(p =>
                    (filters.Name == null || p.Name == filters.Name)
                    && (filters.Status == null || p.Status == filters.Status)
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;
                */

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.Contracts.GetContractHistoryList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Contract>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<PagedList<Contract>?> GetContractList(ContractFilter filters, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Contract>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                var matches = cacheDataList.Where(x =>
                    (filters.ContractName == null ||
                     x.ContractName.ToLower().Contains(filters.ContractName.ToLower()))
                    && (filters.Description == null ||
                        x.Description.ToLower().Contains(filters.Description.ToLower()))
                    && (filters.PriceForWater == null || x.PriceForWater == filters.PriceForWater)
                    && (filters.PriceForRent == null || x.PriceForRent == filters.PriceForRent)
                    && (filters.PriceForElectricity == null || x.PriceForElectricity == filters.PriceForElectricity)
                    && (filters.PriceForService == null || x.PriceForService == filters.PriceForService)
                    && (filters.ContractStatus == null ||
                        x.ContractStatus.ToLower() == filters.ContractStatus.ToLower())
                    && (filters.DateSigned == null || x.DateSigned == filters.DateSigned)
                    && (filters.EndDate == null || x.EndDate == filters.EndDate)
                    && (filters.StartDate == null || x.StartDate == filters.StartDate)
                    && (filters.RenterId == null || x.RenterId == filters.RenterId)
                    && (filters.LastUpdated == null || x.LastUpdated == filters.LastUpdated)
                    && (filters.RenterUsername == null || x.Renter.Username.ToLower()
                        .Contains(filters.RenterUsername.ToLower()))
                    && (filters.RenterPhoneNumber == null || x.Renter.PhoneNumber.ToLower()
                        .Contains(filters.RenterPhoneNumber.ToLower()))
                    && (filters.RenterEmail == null || x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                    && (filters.RenterFullname == null ||
                        x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower()))
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.Contracts.GetContractList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Contract>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<PagedList<Contract>?> GetContractList(ContractFilter filters, int? id,
        bool isManagement,
        CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        /*
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Contract>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                var matches = cacheDataList.Where(x =>
                    (filters.ContractName == null ||
                     x.ContractName.ToLower().Contains(filters.ContractName.ToLower()))
                    && (filters.Description == null ||
                        x.Description.ToLower().Contains(filters.Description.ToLower()))
                    && (filters.PriceForWater == null || x.PriceForWater == filters.PriceForWater)
                    && (filters.PriceForRent == null || x.PriceForRent == filters.PriceForRent)
                    && (filters.PriceForElectricity == null || x.PriceForElectricity == filters.PriceForElectricity)
                    && (filters.PriceForService == null || x.PriceForService == filters.PriceForService)
                    && (filters.ContractStatus == null ||
                        x.ContractStatus.ToLower() == filters.ContractStatus.ToLower())
                    && (filters.DateSigned == null || x.DateSigned == filters.DateSigned)
                    && (filters.EndDate == null || x.EndDate == filters.EndDate)
                    && (filters.StartDate == null || x.StartDate == filters.StartDate)
                    && (filters.RenterId == null || x.RenterId == filters.RenterId)
                    && (filters.LastUpdated == null || x.LastUpdated == filters.LastUpdated)
                    && (filters.RenterUsername == null || x.Renter.Username.ToLower()
                        .Contains(filters.RenterUsername.ToLower()))
                    && (filters.RenterPhoneNumber == null || x.Renter.PhoneNumber.ToLower()
                        .Contains(filters.RenterPhoneNumber.ToLower()))
                    && (filters.RenterEmail == null || x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                    && (filters.RenterFullname == null ||
                        x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower()))
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }
        */

        var queryable = _repositoryWrapper.Contracts.GetContractList(filters, id, isManagement);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Contract>
            .Create(queryable, pageNumber, pageSize, token);

        /*
        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        */

        return pagedList;
    }

    public async Task<Contract?> GetContractById(int? contractId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractById(contractId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Contract?> GetContractById(int? contractId, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractById(contractId, buildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Contract?> GetContractByRenterIdWithActiveStatus(int contractId, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetContractById(contractId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Contract?> GetLatestContractByUserId(int? renterId, CancellationToken token)
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

    public async Task<RepositoryResponse> AddContractWithRenter(Contract newContract, CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.AddContractWithRenter(newContract, token);
    }

    public async Task<int?> GetTotalRenterWithActiveContract(MetricRenterContractFilter filter, int buildingId,
        CancellationToken token)
    {
        return await _repositoryWrapper.Contracts.GetTotalRenterWithActiveContract(filter, buildingId)
            .SumAsync(token);
    }
}
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

public class RenterService : IRenterService
{
    private readonly string _cacheKey = "renter";
    private readonly string _cacheKeyBuildingId = "renter-building-id";
    private readonly string _cacheKeyPageNumber = "page-number-renter";
    private readonly string _cacheKeyPageSize = "page-size-renter";
    private readonly string _cacheKeyRenterList = "renter-list";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RenterService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, int buildingId, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Renter>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);
        var cacheDataBuildingId = await _redis.GetCachePagedDataAsync<int>(_cacheKeyBuildingId);

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
                await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
            }
            else
            {
                var matches =
                    cacheDataList.Where(y =>
                        (filters.Username == null || y.Username.ToLower().Contains(filters.Username.ToLower()))
                        && (filters.Status == null || y.Status == filters.Status)
                        && (filters.Address == null || y.Address.ToLower().Contains(filters.Address.ToLower()))
                        && (filters.PhoneNumber == null || y.PhoneNumber.Contains(filters.PhoneNumber))
                        && (filters.Email == null || y.Email.ToLower().Contains(filters.Email.ToLower()))
                        && (filters.Gender == null || y.Gender == filters.Gender)
                        && (filters.FullName == null || y.FullName.ToLower().Contains(filters.FullName.ToLower()))
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize
                        && cacheDataBuildingId == buildingId);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
                await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
            }
        }

        var queryable = _repositoryWrapper.Renters.GetRenterList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Renter>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyBuildingId, buildingId, 10, 5);

        return pagedList;
    }

    public async Task<List<Renter>?> GetRenterListBasedOnFlat(int flatId, CancellationToken token)
    {
        return await _repositoryWrapper.Renters.GetRenterListBasedOnFlat(flatId)
            .ToListAsync(token);
    }

    public Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<Renter?> GetRenterById(int? renterId, CancellationToken token)
    {
        return await _repositoryWrapper.Renters.GetRenterById(renterId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Renter?> GetRenterByUsername(string username)
    {
        return await _repositoryWrapper.Renters.GetRenterByUsername(username).FirstOrDefaultAsync();
    }

    public async Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token)
    {
        return await _repositoryWrapper.Renters.RenterUsernameCheck(username, token);
    }

    public async Task<RepositoryResponse> IsRenterEmailExist(string? email, CancellationToken token)
    {
        return await _repositoryWrapper.Renters.IsRenterEmailExist(email, token);
    }

    public async Task<RepositoryResponse> IsRenterEmailExist(string? email, int? renterId, CancellationToken token)
    {
        return await _repositoryWrapper.Renters.IsRenterEmailExist(email, renterId, token);
    }

    public async Task<Renter?> RenterDetailWithEmployeeId(int userId)
    {
        return await _repositoryWrapper.Renters.GetRenterDetailWithContractId(userId)
            .FirstOrDefaultAsync();
    }

    public async Task<RepositoryResponse> UpdatePasswordRenter(Renter renter)
    {
        var response = await _repositoryWrapper.Renters.UpdatePasswordRenter(renter);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
        await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
        return response;
    }

    public async Task<List<Renter>?> GetRenterList(int buildingId, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<List<Renter>>(_cacheKeyRenterList);

        if (cacheDataList != null)
            return cacheDataList;

        var response = await _repositoryWrapper.Renters.GetRenterList(buildingId)
            .ToListAsync(token);

        await _redis.SetCacheDataAsync(_cacheKeyRenterList, response, 10, 5);

        return response;
    }

    public async Task<Renter?> AddRenter(Renter renter)
    {
        var response = await _repositoryWrapper.Renters.AddRenter(renter);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
        await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
        return response;
    }

    public async Task<RepositoryResponse> UpdateRenter(Renter renter)
    {
        var response = await _repositoryWrapper.Renters.UpdateRenter(renter);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
        await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
        return response;
    }

    public async Task<RepositoryResponse> UpdateImageRenter(Renter renter)
    {
        var response = await _repositoryWrapper.Renters.UpdateImageRenter(renter);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
        await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
        return response;
    }

    public async Task<RepositoryResponse> ToggleRenterStatus(Renter renter)
    {
        var response = await _repositoryWrapper.Renters.ToggleRenter(renter);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuildingId);
        await _redis.RemoveCacheDataAsync(_cacheKeyRenterList);
        return response;
    }

    public async Task<RepositoryResponse> DeleteRenter(int renterId)
    {
        return await _repositoryWrapper.Renters.DeleteRenter(renterId);
    }

    public async Task<Renter?> RenterLogin(string usernameOrPhoneNumber, string password,
        CancellationToken token)
    {
        return await _repositoryWrapper.Renters.RenterLogin(usernameOrPhoneNumber, password, token);
    }
}
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

public class TicketTypeService : ITicketTypeService
{
    private readonly string _cacheKey = "ticket-type";
    private readonly string _cacheKeyPageNumber = "page-number-ticket-type";
    private readonly string _cacheKeyPageSize = "page-size-ticket-type";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public TicketTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<TicketType>?> GetTicketTypeList(TicketTypeFilter filters, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<TicketType>>(_cacheKey);
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
                var matches =
                    cacheDataList.Where(x =>
                        (filters.Name == null || x.TicketTypeName.ToLower().Contains(filters.Name.ToLower()))
                        && (filters.Status == null || x.Status == filters.Status)
                        && (filters.Description == null ||
                            x.Description.ToLower().Contains(filters.Description.ToLower()))
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.TicketTypes.GetTicketTypeList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<TicketType>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<TicketType?> GetTicketTypeById(int? ticketTypeId, CancellationToken token)
    {
        return await _repositoryWrapper.TicketTypes.GetTicketTypeDetail(ticketTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<TicketType?> AddTicketType(TicketType ticketType)
    {
        return await _repositoryWrapper.TicketTypes.AddTicketType(ticketType);
    }

    public async Task<RepositoryResponse> UpdateTicketType(TicketType ticketType)
    {
        return await _repositoryWrapper.TicketTypes.UpdateTicketType(ticketType);
    }

    public async Task<RepositoryResponse> DeleteTicketType(int ticketTypeId)
    {
        return await _repositoryWrapper.TicketTypes.DeleteTicketType(ticketTypeId);
    }
}
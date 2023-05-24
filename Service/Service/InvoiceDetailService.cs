using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class InvoiceDetailService : IInvoiceDetailService
{
    private readonly string _cacheKey = "invoice-detail";
    private readonly string _cacheKeyPageNumber = "page-number-invoice-detail";
    private readonly string _cacheKeyPageSize = "page-size-invoice-detail";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceDetailService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<InvoiceDetail?> UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
    {
        return await _repositoryWrapper.InvoiceDetails.UpdateInvoiceDetail(invoiceDetail);
    }

    public async Task<InvoiceDetail?> AddInvoiceDetail(InvoiceDetail invoiceDetail)
    {
        return await _repositoryWrapper.InvoiceDetails.AddInvoiceDetail(invoiceDetail);
    }

    public async Task<List<InvoiceDetail>> GetInvoiceDetailListByUserId(int id, CancellationToken token)
    {
        return await _repositoryWrapper.InvoiceDetails.GetInvoiceDetailListByUserId(id, token);
    }

    public async Task<InvoiceDetail?> GetActiveInvoiceDetailByUserId(int id, CancellationToken token)
    {
        return await _repositoryWrapper.InvoiceDetails.GetActiveInvoiceDetailByUserId(id, token);
    }

    public async Task<InvoiceDetail?> GetInvoiceDetailById(int? id, CancellationToken token)
    {
        return await _repositoryWrapper.InvoiceDetails.GetInvoiceDetailById(id);
    }

    public async Task<PagedList<InvoiceDetail>?> GetInvoiceDetails(InvoiceDetailFilter filters, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<InvoiceDetail>>(_cacheKey);
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
                        (filters.ServiceId == null || x.ServiceId == filters.ServiceId)
                        && (filters.InvoiceId == null || x.InvoiceId == filters.InvoiceId)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.InvoiceDetails.GetInvoiceDetails(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<InvoiceDetail>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<RepositoryResponse> DeleteInvoiceDetail(int id)
    {
        return await _repositoryWrapper.InvoiceDetails.DeleteInvoiceDetail(id);
    }
}
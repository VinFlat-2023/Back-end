using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class InvoiceTypeService : IInvoiceTypeService
{
    private readonly string _cacheKey = "invoice-type";
    private readonly string _cacheKeyPageNumber = "page-number-invoice-type";
    private readonly string _cacheKeyPageSize = "page-size-invoice-type";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType)
    {
        return await _repositoryWrapper.InvoiceTypes.AddInvoiceType(invoiceType);
    }

    public async Task<InvoiceType?> GetInvoiceTypeById(int? id, CancellationToken token)
    {
        return await _repositoryWrapper.InvoiceTypes.GetInvoiceTypeById(id);
    }

    public async Task<PagedList<InvoiceType>?> GetInvoiceTypes(InvoiceTypeFilter filters, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<InvoiceType>>(_cacheKey);
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
                        (filters.InvoiceTypeName == null ||
                         x.InvoiceTypeName.ToLower().Contains(filters.InvoiceTypeName.ToLower()))
                        && (filters.Status == null || x.Status == filters.Status)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.InvoiceTypes.GetInvoiceTypes(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<InvoiceType>
            .Create(queryable, page, size, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);

        return pagedList;
    }

    public async Task<RepositoryResponse> UpdateInvoiceType(InvoiceType invoiceType)
    {
        return await _repositoryWrapper.InvoiceTypes.UpdateInvoiceType(invoiceType);
    }

    public async Task<RepositoryResponse> DeleteInvoiceType(int id)
    {
        return await _repositoryWrapper.InvoiceTypes.DeleteInvoiceType(id);
    }
}
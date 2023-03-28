using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class InvoiceDetailService : IInvoiceDetailService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceDetailService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
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

    public async Task<InvoiceDetail?> GetInvoiceDetailById(int? id)
    {
        return await _repositoryWrapper.InvoiceDetails.GetInvoiceDetailById(id);
    }

    public async Task<PagedList<InvoiceDetail>?> GetInvoiceDetails(InvoiceDetailFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.InvoiceDetails.GetInvoiceDetails(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<InvoiceDetail>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<RepositoryResponse> DeleteInvoiceDetail(int id)
    {
        return await _repositoryWrapper.InvoiceDetails.DeleteInvoiceDetail(id);
    }
}
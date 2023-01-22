using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class InvoiceService : IInvoiceService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Invoices.GetInvoiceList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Invoice>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Invoice?> GetInvoiceById(int invoiceId)
    {
        return await _repositoryWrapper.Invoices.GetInvoiceDetail(invoiceId);
    }

    public async Task<Invoice?> AddInvoice(Invoice invoice)
    {
        return await _repositoryWrapper.Invoices.AddInvoice(invoice);
    }

    public async Task<Invoice?> UpdateInvoice(Invoice invoice)
    {
        return await _repositoryWrapper.Invoices.UpdateInvoice(invoice);
    }

    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        return await _repositoryWrapper.Invoices.DeleteInvoice(invoiceId);
    }
}
using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class InvoiceTypeService : IInvoiceTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;


    public InvoiceTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType)
    {
        return await _repositoryWrapper.InvoiceTypes.AddInvoiceType(invoiceType);
    }

    public async Task<InvoiceType?> GetInvoiceTypeById(int id)
    {
        return await _repositoryWrapper.InvoiceTypes.GetInvoiceTypeById(id);
    }

    public async Task<PagedList<InvoiceType>?> GetInvoiceTypes(InvoiceTypeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.InvoiceTypes.GetInvoiceTypes(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<InvoiceType>
            .Create(queryable, page, size, token);

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
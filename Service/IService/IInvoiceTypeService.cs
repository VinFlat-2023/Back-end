using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IInvoiceTypeService
{
    Task<InvoiceType?> GetInvoiceTypeById(int id);
    Task<PagedList<InvoiceType>?> GetInvoiceTypes(InvoiceTypeFilter filters, CancellationToken token);
    Task<RepositoryResponse> UpdateInvoiceType(InvoiceType invoiceType);
    Task<RepositoryResponse> DeleteInvoiceType(int id);
    Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType);
}
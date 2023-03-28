using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IInvoiceTypeRepository
{
    Task<InvoiceType?> GetInvoiceTypeById(int id);
    IQueryable<InvoiceType> GetInvoiceTypes(InvoiceTypeFilter filters);
    Task<RepositoryResponse> UpdateInvoiceType(InvoiceType invoiceType);
    Task<RepositoryResponse> DeleteInvoiceType(int id);
    Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType);
}
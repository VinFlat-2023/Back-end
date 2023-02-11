using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IInvoiceTypeRepository
{
    Task<InvoiceType?> GetInvoiceTypeById(int id);
    IQueryable<InvoiceType> GetInvoiceTypes(InvoiceTypeFilter filters);
    Task<InvoiceType?> UpdateInvoiceType(InvoiceType invoiceType);
    Task<bool> DeleteInvoiceType(int id);
    Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType);
}
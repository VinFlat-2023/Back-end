using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IInvoiceDetailRepository
{
    Task<InvoiceDetail?> UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
    Task<InvoiceDetail?> AddInvoiceDetail(InvoiceDetail invoiceDetail);
    Task<List<InvoiceDetail>> GetInvoiceDetailListByUserId(int id, CancellationToken token);
    Task<InvoiceDetail?> GetActiveInvoiceDetailByUserId(int id, CancellationToken token);
    Task<InvoiceDetail?> GetInvoiceDetailById(int? id);
    IQueryable<InvoiceDetail> GetInvoiceDetails(InvoiceDetailFilter filters);
    Task<RepositoryResponse> DeleteInvoiceDetail(int id);
}
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IInvoiceDetailService
{
    Task<InvoiceDetail?> UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
    Task<InvoiceDetail?> AddInvoiceDetail(InvoiceDetail invoiceDetail);
    Task<List<InvoiceDetail>> GetInvoiceDetailListByUserId(int id, CancellationToken token);
    Task<InvoiceDetail?> GetActiveInvoiceDetailByUserId(int id, CancellationToken token);
    Task<InvoiceDetail?> GetInvoiceDetailById(int? id);
    Task<PagedList<InvoiceDetail>?> GetInvoiceDetails(InvoiceDetailFilter filters, CancellationToken token);
    Task<RepositoryResponse> DeleteInvoiceDetail(int id);
}
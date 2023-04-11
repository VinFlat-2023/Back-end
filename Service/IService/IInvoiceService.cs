using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.QueryFilter;

namespace Service.IService;

public interface IInvoiceService
{
    public Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filter, CancellationToken token);
    public Task<Invoice?> GetInvoiceById(int? invoiceId);
    public Task<Invoice?> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
    public Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId);
    public Task<bool> AutoGenerateEmptyInvoice();
    public Task<bool> AutoFinishInvoice();
    public Task<int> GetLatestUnpaidInvoiceByRenter(int renterId);
    public Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId, IEnumerable<int> serviceId);
    public Task<RepositoryResponse> BatchInsertInvoice(IEnumerable<MassInvoiceCreateRequest> invoices);
}
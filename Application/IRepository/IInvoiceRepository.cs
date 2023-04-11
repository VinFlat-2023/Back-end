using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IInvoiceRepository
{
    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter);
    public Task<Invoice?> GetInvoiceDetail(int? invoiceId);
    public Task<Invoice> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
    public List<Invoice> GetUnpaidInvoice();
    public Task<int> GetLatestUnpaidInvoiceByRenter(int renterId);
    public Task<Invoice?> GetInvoiceIncludeRenter(int invoiceId);
    public Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId);
    public Task<Invoice?> GetUnpaidInvoiceByRenterAndMonth(int renterId, int month);
    public IEnumerable<Invoice> GetInvoiceListByMonth(int month);
    public Task<RepositoryResponse> BatchInsertInvoice(IEnumerable<MassInvoiceCreateRequest> invoices);
    public Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId, IEnumerable<int> serviceId);
}
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IInvoiceRepository
{
    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter);
    public Task<Invoice?> GetInvoiceDetail(int invoiceId);
    public Task<Invoice> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
    public List<Invoice> GetUnpaidInvoice();
    public Task<Invoice?> GetInvoiceIncludeRenter(int invoiceId);
    public Task<Invoice?> GetInvoiceByRenter(int renterId);
    public Task<Invoice?> GetUnpaidInvoiceByRenterAndMonth(int renterId, int month);
    IEnumerable<Invoice> GetInvoiceListByMonth(int month);
    public Task<bool> BatchInsertInvoice(IEnumerable<MassInvoiceCreateRequest> invoices);
}
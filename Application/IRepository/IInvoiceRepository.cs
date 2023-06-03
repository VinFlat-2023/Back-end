using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IInvoiceRepository
{
    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter);
    public Task<Invoice?> GetInvoiceDetail(int? invoiceId, CancellationToken token);
    public Task<Invoice> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
    public Task<List<Invoice>> GetUnpaidInvoice(int buildingId, CancellationToken token);
    public Task<int> GetLatestUnpaidInvoiceByRenter(int renterId, CancellationToken token);
    public Task<Invoice?> GetInvoiceIncludeRenter(int invoiceId, CancellationToken token);

    public Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId,
        CancellationToken token);

    public Task<Invoice?> GetUnpaidInvoiceByRenterAndMonth(int renterId, int month, CancellationToken token);
    public IEnumerable<Invoice> GetInvoiceListByMonth(int month);

    public Task<RepositoryResponse> BatchInsertMonthlyInvoice(IEnumerable<int> invoices, int employeeId,
        CancellationToken token);


    public Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId, IEnumerable<int> serviceId,
        CancellationToken token);

    IQueryable<Invoice> GetInvoiceList(InvoiceFilter filters, int? buildingId, int? userId, bool isManagement);

    public Task<RepositoryResponse> BatchInsertMonthlyInvoice(int buildingId, int employeeId,
        CancellationToken token);

    public Task<RepositoryResponse> BatchInsertMonthlyInvoiceWithData(int buildingId, int employeeId,
        CancellationToken token);
}
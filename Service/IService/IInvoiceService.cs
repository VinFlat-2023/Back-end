using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IInvoiceService
{
    public Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filter, CancellationToken token);

    Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filter, int? buildingId, int? userId, bool isManagement,
        CancellationToken token);

    public Task<Invoice?> GetInvoiceById(int? invoiceId, CancellationToken token);
    public Task<Invoice?> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
    public Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId, CancellationToken token);
    public Task<bool> AutoGenerateEmptyInvoice(CancellationToken token);
    public Task<bool> AutoFinishInvoice();
    public Task<int> GetLatestUnpaidInvoiceByRenter(int renterId, CancellationToken token);

    public Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId, IEnumerable<int> serviceId,
        CancellationToken token);

    /*
    public Task<RepositoryResponse> BatchInsertMonthlyInvoice(IEnumerable<int> invoices, int employeeId,
        CancellationToken token);
    */
    public Task<RepositoryResponse>
        BatchInsertMonthlyInvoice(int buildingForCurrentSupervisor, int employeeId, CancellationToken token);

    public Task<RepositoryResponse> BatchInsertMonthlyInvoiceWithData(int buildingForCurrentSupervisor, int employeeId,
        CancellationToken token);
}
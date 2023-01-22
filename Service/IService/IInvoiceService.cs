using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IInvoiceService
{
    public Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filter, CancellationToken token);

    // TODO : Get invoice based on room id
    public Task<Invoice?> GetInvoiceById(int invoiceId);
    public Task<Invoice?> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
}
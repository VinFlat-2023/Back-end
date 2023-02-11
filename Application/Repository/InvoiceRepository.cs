using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationContext _context;

    public InvoiceRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all invoices
    /// </summary>
    /// <returns></returns>
    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter)
    {
        return _context.Invoices
            .Include(x => x.Account)
            .Include(x => x.Renter)
            .Where(x => x.AccountId == x.Account.AccountId)
            .Where(x => x.RenterId == x.Renter.RenterId)
            // Filter starts here
            .Where(x =>
                (filter.Name == null || x.Name.Contains(filter.Name))
                && (filter.Status == null || x.Status == filter.Status)
                && (filter.Amount == null || x.Amount == filter.Amount)
                && (filter.Detail == null || x.Detail == filter.Detail)
                && (filter.RenterId == null || x.RenterId == filter.RenterId)
                && (filter.AccountId == null || x.AccountId == filter.AccountId)
                && (filter.InvoiceTypeId == null || x.InvoiceTypeId == filter.InvoiceTypeId))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get invoice by id
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<Invoice?> GetInvoiceDetail(int invoiceId)
    {
        return await _context.Invoices
            .Include(x => x.Account)
            .Include(x => x.Renter)
            .Where(x => x.RenterId == x.Renter.RenterId)
            .Where(x => x.AccountId == x.Account.AccountId)
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
    }

    /// <summary>
    ///     Get invoice by id (Include renter id)
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<Invoice?> GetInvoiceIncludeRenter(int invoiceId)
    {
        return await _context.Invoices.Include(e => e.Renter)
            .SingleOrDefaultAsync(e => e.InvoiceId == invoiceId);
    }

    public async Task<Invoice?> GetInvoiceByRenter(int renterId)
    {
        return await _context.Invoices
            .Where(x => x.Status == true)
            .FirstOrDefaultAsync(x => x.RenterId == renterId);
    }

    public async Task<Invoice?> GetUnpaidInvoiceByRenterAndMonth(int renterId, int month)
    {
        return await _context.Invoices
            .Where(x => x.Status == false)
            .FirstOrDefaultAsync(x => x.RenterId == renterId && x.CreatedTime.Month == month);
    }

    /// <summary>
    ///     Add new invoice
    /// </summary>
    /// <param name="invoice"></param>
    /// <returns></returns>
    public async Task<Invoice> AddInvoice(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
        return invoice;
    }

    /// <summary>
    ///     Update invoice
    /// </summary>
    /// <param name="invoice"></param>
    /// <returns></returns>
    public async Task<Invoice?> UpdateInvoice(Invoice? invoice)
    {
        var invoiceData = await _context.Invoices
            .FirstOrDefaultAsync(x => x.InvoiceId == invoice!.InvoiceId);
        if (invoiceData == null)
            return null;

        invoiceData.Name = invoice?.Name ?? invoiceData.Name;
        invoiceData.Amount = invoice?.Amount ?? invoiceData.Amount;
        invoiceData.Status = invoice?.Status ?? invoiceData.Status;
        invoiceData.ImageUrl = invoice?.ImageUrl ?? invoiceData.ImageUrl;
        invoiceData.Detail = invoice?.Detail ?? invoiceData.Detail;
        invoiceData.AccountId = invoice?.AccountId ?? invoiceData.AccountId;
        invoiceData.RenterId = invoice?.RenterId ?? invoiceData.RenterId;
        invoiceData.InvoiceTypeId = invoice?.InvoiceTypeId ?? invoiceData.InvoiceTypeId;

        await _context.SaveChangesAsync();
        return invoiceData;
    }

    /// <summary>
    ///     Delete invoice
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        var invoiceFound = await _context.Invoices
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
        if (invoiceFound == null)
            return false;
        _context.Invoices.Remove(invoiceFound);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Get unpaid invoices
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<Invoice> GetUnpaidInvoice()
    {
        var unpaidInvoices = _context.Invoices
            .Include(e => e.Renter)
            .Include(e => e.InvoiceDetails)
            .ThenInclude(e => e.Service)
            .Where(e => !e.Status).ToList();
        return unpaidInvoices;
    }

    public IEnumerable<Invoice> GetInvoiceListByMonth(int month)
    {
        return _context.Invoices
            .Where(x => x.Status == false && x.CreatedTime.Month == month);
        //.Where(x.CreatedTime.Month == month);
    }
}
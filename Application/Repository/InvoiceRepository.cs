using System.Globalization;
using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
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
            .Include(x => x.Employee)
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .Include(x => x.InvoiceType)
            // filter starts here
            .Where(x =>
                (filter.Name == null || x.Name.ToLower().Contains(filter.Name.ToLower()))
                && (filter.Status == null || x.Status == filter.Status)
                && (filter.Amount == null || x.Amount == filter.Amount)
                && (filter.Detail == null || x.Detail == filter.Detail)
                && (filter.RenterId == null || x.RenterId == filter.RenterId)
                && (filter.RenterUsername == null ||
                    x.Renter.Username.ToLower().Contains(filter.RenterUsername.ToLower()))
                && (filter.RenterFullname == null ||
                    x.Renter.FullName.ToLower().Contains(filter.RenterFullname.ToLower()))
                && (filter.RenterPhoneNumber == null ||
                    x.Renter.Phone.ToLower().Contains(filter.RenterPhoneNumber.ToLower()))
                && (filter.RenterEmail == null || x.Renter.Email.ToLower().Contains(filter.RenterEmail.ToLower()))
                && (filter.EmployeeId == null || x.EmployeeId == filter.EmployeeId)
                && (filter.EmployeeName == null ||
                    x.Employee.FullName.ToLower().Contains(filter.EmployeeName.ToLower()))
                && (filter.InvoiceTypeId == null || x.InvoiceTypeId == filter.InvoiceTypeId))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get invoice by id
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<Invoice?> GetInvoiceDetail(int? invoiceId, CancellationToken token)
    {
        return await _context.Invoices
            .Include(x => x.Employee)
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .Include(x => x.InvoiceType)
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId, token);
    }

    public async Task<int> GetLatestUnpaidInvoiceByRenter(int renterId, CancellationToken token)
    {
        return await _context.Invoices
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .Include(x => x.InvoiceType)
            // false = unpaid invoice
            .Where(x => x.RenterId == renterId && x.Status == false)
            .OrderByDescending(x => x.CreatedTime)
            .Select(x => x.InvoiceId)
            .FirstOrDefaultAsync(token);
    }

    /// <summary>
    ///     Get invoice by id (Include renter id)
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<Invoice?> GetInvoiceIncludeRenter(int invoiceId, CancellationToken token)
    {
        return await _context.Invoices.Include(e => e.Renter)
            .FirstOrDefaultAsync(e => e.InvoiceId == invoiceId, token);
    }

    public async Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId,
        CancellationToken cancellationToken)
    {
        return await _context.Invoices
            .Include(x => x.Renter)
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId && x.RenterId == renterId, cancellationToken);
    }

    public async Task<Invoice?> GetUnpaidInvoiceByRenterAndMonth(int renterId, int month, CancellationToken token)
    {
        return await _context.Invoices
            .Where(x => x.Status == false)
            .FirstOrDefaultAsync(x => x.RenterId == renterId && x.CreatedTime.Value.Month == month, token);
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
        invoiceData.EmployeeId = invoice?.EmployeeId ?? invoiceData.EmployeeId;
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
    public async Task<List<Invoice>> GetUnpaidInvoice(CancellationToken token)
    {
        return await _context.Invoices
            .Include(e => e.Renter)
            .Include(e => e.InvoiceDetails)
            .ThenInclude(e => e.Service)
            .Where(e => !e.Status).ToListAsync(token);
    }

    public IEnumerable<Invoice> GetInvoiceListByMonth(int month)
    {
        return _context.Invoices
            .Where(x => x.Status == false && x.CreatedTime.Value.Month == month);
        //.Where(x.CreatedTime.Month == month);
    }

    public async Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId,
        IEnumerable<int> serviceId)
    {
        await using
            var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            foreach (var service in serviceId)
            {
                var serviceEntity = new InvoiceDetail
                {
                    InvoiceId = invoiceId,
                    ServiceId = service
                };

                _context.InvoiceDetails.Add(serviceEntity);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Service(s) added to invoice"
            };
        }
        catch
        {
            await transaction.RollbackAsync();
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Service(s) not added to invoice"
            };
        }
    }

    public async Task<RepositoryResponse> BatchInsertInvoice(IEnumerable<MassInvoiceCreateRequest> invoices)
    {
        await using
            var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            foreach (var invoiceEntity in invoices
                         .Select(invoice => new Invoice
                         {
                             Name = invoice.Name,
                             DueDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                                 "dd/MM/yyyy HH:mm:ss", null).AddMonths(1),
                             Status = true,
                             Detail = invoice.Detail,
                             EmployeeId = invoice.EmployeeId,
                             RenterId = invoice.RenterId,
                             InvoiceTypeId = invoice.InvoiceTypeId,
                             CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                                 "dd/MM/yyyy HH:mm:ss", null)
                         }))
                _context.Invoices.Add(invoiceEntity);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Batch inserted invoice successfully"
            };
        }
        catch
        {
            await transaction.RollbackAsync();
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Batch inserted invoice failed"
            };
        }
    }
}
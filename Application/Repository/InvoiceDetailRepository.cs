using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class InvoiceDetailRepository : IInvoiceDetailRepository
{
    private readonly ApplicationContext _context;

    public InvoiceDetailRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<InvoiceDetail> GetInvoiceDetails(InvoiceDetailFilter filters)
    {
        return _context.InvoiceDetails
            .Include(x => x.Service)
            // .Where(x => x.ServiceId == x.Service.ServiceId)
            //.Include(x => x.Ticket)
            //.Where(x => x.TicketId == x.Ticket.TicketId)
            .Include(x => x.Invoice)
            // .Where(x => x.InvoiceId == x.Invoice.InvoiceId)
            // filter starts here
            .Where(x =>
                (filters.ServiceId == null || x.ServiceId == filters.ServiceId)
                && (filters.InvoiceId == null || x.InvoiceId == filters.InvoiceId))
            .AsNoTracking();
    }

    public async Task<InvoiceDetail?> GetInvoiceDetailById(int? id)
    {
        return await _context.InvoiceDetails
            .Include(x => x.Service)
            //.Include(x => x.Ticket)
            .FirstOrDefaultAsync(x => x.InvoiceId == id);
    }

    public async Task<List<InvoiceDetail>> GetInvoiceDetailListByUserId(int id, CancellationToken token)
    {
        return await _context.InvoiceDetails
            .Include(x => x.Invoice)
            .Where(x => x.Invoice.RenterId == id)
            .ToListAsync(token);
    }

    public async Task<InvoiceDetail?> GetActiveInvoiceDetailByUserId(int id, CancellationToken token)
    {
        return await _context.InvoiceDetails
            .Include(x => x.Invoice)
            .Where(x => x.Invoice.Status == false
                        && x.Invoice.RenterId == id)
            .FirstOrDefaultAsync(token);
    }

    public async Task<RepositoryResponse> DeleteInvoiceDetail(int id)
    {
        var invoiceDetail = await _context.InvoiceDetails
            .FirstOrDefaultAsync(x => x.InvoiceDetailId == id);
        if (invoiceDetail == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Chi tiết hoá đơn không tồn tại"
            };

        _context.InvoiceDetails.Remove(invoiceDetail);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Chi tiết hoá đơn đã được xóa thành công"
        };
    }

    // TODO : FIX INVOICE DETAIL

    public async Task<InvoiceDetail?> UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
    {
        _context.Entry(invoiceDetail).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return invoiceDetail;
    }

    public async Task<InvoiceDetail?> AddInvoiceDetail(InvoiceDetail invoiceDetail)
    {
        _context.InvoiceDetails.Add(invoiceDetail);
        await _context.SaveChangesAsync();
        return invoiceDetail;
    }
}
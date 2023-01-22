using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class InvoiceTypeRepository : IInvoiceTypeRepository
{
    private readonly ApplicationContext _context;

    public InvoiceTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<InvoiceType> GetInvoiceTypes(InvoiceTypeFilter filters)
    {
        return _context.InvoiceTypes
            .Where(x =>
                (filters.InvoiceTypeName == null || x.InvoiceTypeName.Contains(filters.InvoiceTypeName))
                && (filters.Status == null || x.Status == filters.Status))
            .AsNoTracking();
    }

    public async Task<InvoiceType?> GetInvoiceTypeById(int id)
    {
        return await _context.InvoiceTypes
            .FirstOrDefaultAsync(x => x.InvoiceTypeId == id);
    }

    public async Task<InvoiceType?> UpdateInvoiceType(InvoiceType? invoiceType)
    {
        var invoiceTypeData = await _context.InvoiceTypes
            .FirstOrDefaultAsync(x => x.InvoiceTypeId == invoiceType!.InvoiceTypeId);
        if (invoiceTypeData == null)
            return null;

        invoiceTypeData.InvoiceTypeName = invoiceType?.InvoiceTypeName ?? invoiceTypeData.InvoiceTypeName;
        invoiceTypeData.Status = invoiceType?.Status ?? invoiceTypeData.Status;
        // TODO : Check if wanted to change invoice destination

        await _context.SaveChangesAsync();
        return invoiceTypeData;
    }

    public async Task<bool> DeleteInvoiceType(int id)
    {
        var invoiceType = await _context.InvoiceTypes
            .FirstOrDefaultAsync(x => x.InvoiceTypeId == id);
        if (invoiceType == null)
            return false;

        _context.InvoiceTypes.Remove(invoiceType);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType)
    {
        await _context.InvoiceTypes.AddAsync(invoiceType);
        await _context.SaveChangesAsync();
        return invoiceType;
    }
}
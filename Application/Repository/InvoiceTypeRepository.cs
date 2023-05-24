using Application.IRepository;
using Domain.CustomEntities;
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
                (filters.InvoiceTypeName == null ||
                 x.InvoiceTypeName.ToLower().Contains(filters.InvoiceTypeName.ToLower()))
                && (filters.Status == null || x.Status == filters.Status))
            .AsNoTracking();
    }

    public async Task<InvoiceType?> GetInvoiceTypeById(int? id)
    {
        return await _context.InvoiceTypes
            .FirstOrDefaultAsync(x => x.InvoiceTypeId == id);
    }

    public async Task<RepositoryResponse> UpdateInvoiceType(InvoiceType invoiceType)
    {
        var invoiceTypeData = await _context.InvoiceTypes
            .FirstOrDefaultAsync(x => x.InvoiceTypeId == invoiceType.InvoiceTypeId);
        if (invoiceTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "InvoiceType not found"
            };

        invoiceTypeData.InvoiceTypeName = invoiceType.InvoiceTypeName;
        invoiceTypeData.Status = invoiceType.Status;

        _context.Attach(invoiceTypeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "InvoiceType updated successfully"
        };
    }

    public async Task<RepositoryResponse> DeleteInvoiceType(int id)
    {
        var invoiceType = await _context.InvoiceTypes
            .FirstOrDefaultAsync(x => x.InvoiceTypeId == id);
        if (invoiceType == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "InvoiceType not found"
            };

        _context.InvoiceTypes.Remove(invoiceType);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "InvoiceType deleted successfully"
        };
    }

    public async Task<InvoiceType?> AddInvoiceType(InvoiceType invoiceType)
    {
        await _context.InvoiceTypes.AddAsync(invoiceType);
        await _context.SaveChangesAsync();
        return invoiceType;
    }
}
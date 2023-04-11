using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class FlatTypeRepository : IFlatTypeRepository
{
    private readonly ApplicationContext _context;

    public FlatTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all flat types
    /// </summary>
    /// <returns></returns>
    public IQueryable<FlatType> GetFlatTypeList(FlatTypeFilter filters)
    {
        return _context.FlatTypes
            .Where(x =>
                (filters.Status == null || x.Status == filters.Status)
                && (filters.RoomCapacity == null || x.RoomCapacity == filters.RoomCapacity))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get flat type by id
    /// </summary>
    /// <param name="flatTypeId"></param>
    /// <returns></returns>
    public IQueryable<FlatType> GetFlatTypeDetail(int? flatTypeId)
    {
        return _context.FlatTypes
            .Where(x => x.FlatTypeId == flatTypeId);
    }

    /// <summary>
    ///     AddInvoiceHistory new flat type
    /// </summary>
    /// <param name="flatType"></param>
    /// <returns></returns>
    public async Task<FlatType> AddFlatType(FlatType flatType)
    {
        await _context.FlatTypes.AddAsync(flatType);
        await _context.SaveChangesAsync();
        return flatType;
    }

    /// <summary>
    ///     Update flat type
    /// </summary>
    /// <param name="flatType"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateFlatType(FlatType? flatType)
    {
        var flatTypeData = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.FlatTypeId == flatType!.FlatTypeId);
        if (flatTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Flat type not found"
            };

        flatTypeData.RoomCapacity = flatType?.RoomCapacity ?? flatTypeData.RoomCapacity;
        flatTypeData.Status = flatType?.Status ?? flatTypeData.Status;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Flat type updated successfully"
        };
    }

    /// <summary>
    ///     Delete flat type
    /// </summary>
    /// <param name="flatTypeId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteFlatType(int flatTypeId)
    {
        var flatTypeFound = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.FlatTypeId == flatTypeId);
        if (flatTypeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Flat type not found"
            };
        _context.FlatTypes.Remove(flatTypeFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Flat type deleted successfully"
        };
    }
}
using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class AreaRepository : IAreaRepository
{
    private readonly ApplicationContext _context;

    public AreaRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get list of areas
    /// </summary>
    /// <returns></returns>
    public IQueryable<Area> GetAreaList(AreaFilter filters)
    {
        return _context.Areas
            .Where(x =>
                (filters.Name == null || x.Name.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Location == null || x.Location.Contains(filters.Location)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get area detail by id
    /// </summary>
    /// <param name="areaId"></param>
    /// <returns></returns>
    public async Task<Area?> GetAreaDetail(int? areaId)
    {
        return await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == areaId);
    }

    /// <summary>
    ///     AddExpenseHistory new area
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> AddArea(Area area)
    {
        await _context.Areas.AddAsync(area);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Area added successfully"
        };
    }

    /// <summary>
    ///     UpdateExpenseHistory area detail
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateArea(Area? area)
    {
        var areaData = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == area!.AreaId);

        if (areaData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Area not found"
            };

        areaData.Location = area?.Location ?? areaData.Location;
        areaData.Name = area?.Name ?? areaData.Name;
        areaData.Status = area?.Status ?? areaData.Status;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Area updated successfully"
        };
    }

    /// <summary>
    ///     Toggle area status
    /// </summary>
    /// <param name="areaId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> ToggleArea(int areaId)
    {
        var areaFound = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == areaId);

        if (areaFound == null)
            return new RepositoryResponse
            {
                Message = "Area not found",
                IsSuccess = false
            };
        _ = areaFound.Status == !areaFound.Status;
        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            Message = "Area status toggled successfully",
            IsSuccess = true
        };
    }

    /// <summary>
    ///     DeleteFeedback area
    /// </summary>
    /// <param name="areaId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteArea(int areaId)
    {
        var areaFound = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == areaId);

        if (areaFound == null)
            return new RepositoryResponse
            {
                Message = "Area not found",
                IsSuccess = false
            };

        _context.Areas.Remove(areaFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            Message = "Area deleted successfully",
            IsSuccess = true
        };
    }
}
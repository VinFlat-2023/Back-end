using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class FlatRepository : IFlatRepository
{
    private readonly ApplicationContext _context;

    public FlatRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all flats
    /// </summary>
    /// <returns></returns>
    public IQueryable<Flat> GetFlatList(FlatFilter filters)
    {
        return _context.Flats
            .Include(x => x.Building)
            .ThenInclude(x => x.Area)
            //.Where(x => x.BuildingId == x.Building.BuildingId)
            .Include(x => x.FlatType)
            .Include(x => x.UtilitiesFlats)
            .ThenInclude(x => x.Utility)
            //.Where(x => x.FlatTypeId == x.FlatType.FlatTypeId)
            // filter starts here
            .Where(f =>
                (filters.Name == null || f.Name.Contains(filters.Name.ToLower()))
                && (filters.Description == null || f.Description.Contains(filters.Description.ToLower()))
                && (filters.Status == null || f.Status == filters.Status)
                && (filters.FlatTypeId == null || f.FlatTypeId == filters.FlatTypeId)
                && (filters.FlatTypeName == null ||
                    f.FlatType.FlatTypeName.ToLower().Contains(filters.FlatTypeName.ToLower()))
                && (filters.BuildingId == null || f.BuildingId == filters.BuildingId)
                && (filters.BuildingName == null ||
                    f.Building.BuildingName.ToLower().Contains(filters.BuildingName.ToLower())))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get flat by id
    /// </summary>
    /// <param name="flatId"></param>
    /// <returns></returns>
    public IQueryable<Flat> GetFlatDetail(int? flatId)
    {
        return _context.Flats
            .Include(x => x.Building)
            .ThenInclude(x => x.Area)
            .Include(x => x.FlatType)
            .Include(x => x.UtilitiesFlats)
            .ThenInclude(x => x.Utility)
            .Where(x => x.FlatId == flatId);
    }

    public async Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken cancellationToken)
    {
        var roomInFlat = await _context.Flats
            .Where(x => x.FlatId == flatId)
            .Include(x => x.Rooms)
            .FirstOrDefaultAsync(cancellationToken);

        if (roomInFlat == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng này không tồn tại"
            };

        switch (roomInFlat)
        {
            case not null when roomInFlat.Rooms.Any(x => x.AvailableSlots == 0):
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "This flat's room is not available"
                };

            case not null when roomInFlat.Rooms.Any(x => x.AvailableSlots >= 1):
            {
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "This flat's room is still available"
                };
            }

            case null:
            case not null when roomInFlat.Rooms.Any(_ => false):
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Flat service is unavailable"
                };
        }

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Internal server error for flat services"
        };
    }

    /// <summary>
    ///     AddInvoiceHistory new flat
    /// </summary>
    /// <param name="flat"></param>
    /// <returns></returns>
    public async Task<Flat> AddFlat(Flat flat)
    {
        await _context.Flats.AddAsync(flat);
        await _context.SaveChangesAsync();
        return flat;
    }

    /// <summary>
    ///     Update Flat details
    /// </summary>
    /// <param name="flat"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateFlat(Flat flat)
    {
        var flatData = await _context.Flats
            .FirstOrDefaultAsync(x => x.FlatId == flat!.FlatId);

        if (flatData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Flat not found"
            };

        flatData.Name = flat?.Name ?? flatData.Name;
        flatData.Description = flat?.Description ?? flatData.Description;
        flatData.Status = flat?.Status ?? flatData.Status;
        flatData.WaterMeterBefore = flat?.WaterMeterBefore ?? flatData.WaterMeterBefore;
        flatData.ElectricityMeterBefore = flat?.ElectricityMeterBefore ?? flatData.ElectricityMeterBefore;
        flatData.WaterMeterAfter = flat?.WaterMeterAfter ?? flatData.WaterMeterAfter;
        flatData.ElectricityMeterAfter = flat?.ElectricityMeterAfter ?? flatData.ElectricityMeterAfter;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Flat updated successfully"
        };
    }

    /// <summary>
    ///     Delete Flat
    /// </summary>
    /// <param name="flatId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteFlat(int flatId)
    {
        var flatFound = await _context.Flats
            .FirstOrDefaultAsync(x => x.FlatId == flatId);
        if (flatFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Flat not found"
            };
        _context.Flats.Remove(flatFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Flat deleted successfully"
        };
    }
}
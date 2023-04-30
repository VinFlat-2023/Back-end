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
            //.Include(x => x.UtilitiesFlats)
            //.ThenInclude(x => x.Utility)
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
            //.Include(x => x.UtilitiesFlats)
            //.ThenInclude(x => x.Utility)
            .Where(x => x.FlatId == flatId);
    }

    public async Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken cancellationToken)
    {
        var roomInFlat = await _context.Flats
            .Where(x => x.FlatId == flatId)
            .Include(x => x.RoomFlats)
            .FirstOrDefaultAsync(cancellationToken);

        if (roomInFlat == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phòng này không tồn tại"
            };

        switch (roomInFlat)
        {
            case not null when roomInFlat.RoomFlats.Any(x => x.AvailableSlots == 0):
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "This flat's room is not available"
                };

            case not null when roomInFlat.RoomFlats.Any(x => x.AvailableSlots >= 1):
            {
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "This flat's room is still available"
                };
            }

            case null:
            case not null when roomInFlat.RoomFlats.Any(_ => false):
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
            .FirstOrDefaultAsync(x => x.FlatId == flat.FlatId);

        if (flatData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Căn hộ này không tồn tại"
            };

        flatData.Name = flat.Name;
        flatData.Description = flat.Description;
        flatData.Status = flat.Status;
        flatData.WaterMeterBefore = flat.WaterMeterBefore ?? flatData.WaterMeterBefore;
        flatData.ElectricityMeterBefore = flat.ElectricityMeterBefore ?? flatData.ElectricityMeterBefore;
        flatData.WaterMeterAfter = flat.WaterMeterAfter ?? flatData.WaterMeterAfter;
        flatData.ElectricityMeterAfter = flat.ElectricityMeterAfter ?? flatData.ElectricityMeterAfter;
        flatData.FlatImageUrl1 = flat.FlatImageUrl1 ?? flatData.FlatImageUrl1;
        flatData.FlatImageUrl2 = flat.FlatImageUrl2 ?? flatData.FlatImageUrl2;
        flatData.FlatImageUrl3 = flat.FlatImageUrl3 ?? flatData.FlatImageUrl3;
        flatData.FlatImageUrl4 = flat.FlatImageUrl4 ?? flatData.FlatImageUrl4;
        flatData.FlatImageUrl5 = flat.FlatImageUrl5 ?? flatData.FlatImageUrl5;
        flatData.FlatImageUrl6 = flat.FlatImageUrl6 ?? flatData.FlatImageUrl6;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Thông tin căn hộ đã được cập nhật"
        };
    }

    /// <summary>
    ///     Delete Flat
    /// </summary>
    /// <param name="flatId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteFlat(int flatId)
    {
        var flatFound = await _context.Flats
            .FirstOrDefaultAsync(x => x.FlatId == flatId);
        if (flatFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = ""
            };
        _context.Flats.Remove(flatFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Căn hộ đã xoá thành công"
        };
    }
}
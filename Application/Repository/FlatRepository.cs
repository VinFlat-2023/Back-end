using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Metric;
using Domain.QueryFilter;
using Domain.ViewModel.MetricNumber;
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
            .Include(x => x.Rooms)
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


    public IQueryable<Flat> GetFlatList(int buildingId)
    {
        return _context.Flats
            .Include(x => x.Building)
            .ThenInclude(x => x.Area)
            //.Where(x => x.BuildingId == x.Building.BuildingId)
            .Include(x => x.FlatType)
            .Include(x => x.Rooms)
            .Where(x => x.BuildingId == buildingId && x.Status.ToLower() == "active")
            .AsNoTracking();
    }

    public async Task<MetricNumberForTotal> GetTotalWaterAndElectricity(int buildingId, CancellationToken token)
    {
        var dataWater = await _context.Flats
            .Where(x => x.BuildingId == buildingId && x.Status.ToLower() != "inactive")
            .Select(x => x.WaterMeterAfter)
            .SumAsync(x => x, token);

        var dataElectricity = await _context.Flats
            .Where(x => x.BuildingId == buildingId && x.Status.ToLower() != "inactive")
            .Select(x => x.ElectricityMeterAfter)
            .SumAsync(x => x, token);

        return new MetricNumberForTotal
        {
            TotalWaterNumber = dataWater,
            TotalElectricityNumber = dataElectricity,
            LastFetch = DateTime.Now.ToString("dd/MM/yyyy")
        };
    }

    public async Task<MetricNumberForTotal> GetTotalWaterAndElectricityByFlat(int flatId, int buildingId,
        CancellationToken token)
    {
        var dataWater = await _context.Flats
            .Where(x => x.FlatId == flatId && x.BuildingId == buildingId && x.Status.ToLower() != "inactive")
            .Select(x => x.WaterMeterAfter)
            .SumAsync(x => x, token);

        var dataElectricity = await _context.Flats
            .Where(x => x.FlatId == flatId && x.BuildingId == buildingId && x.Status.ToLower() == "inactive")
            .Select(x => x.ElectricityMeterAfter)
            .SumAsync(x => x, token);

        return new MetricNumberForTotal
        {
            TotalWaterNumber = dataWater,
            TotalElectricityNumber = dataElectricity,
            LastFetch = DateTime.Now.ToString("dd/MM/yyyy")
        };
    }

    public async Task<RepositoryResponse> SetTotalWaterAndElectricityByFlat(UpdateMetricRequest request, int flatId,
        int buildingId,
        CancellationToken token)
    {
        var flatCheck = await _context.Flats
            .FirstOrDefaultAsync(x => x.FlatId == flatId && x.BuildingId == buildingId, token);

        if (flatCheck == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Căn hộ không tồn tại"
            };

        // TODO 
        flatCheck.WaterMeterBefore = request.WaterMeterBefore;
        flatCheck.WaterMeterAfter = request.WaterMeterAfter;

        flatCheck.ElectricityMeterBefore = request.ElectricityMeterBefore;
        flatCheck.ElectricityMeterAfter = request.ElectricityMeterAfter;

        _context.Attach(flatCheck).State = EntityState.Modified;

        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Cập nhật điện nước thành công"
        };
    }

    public IQueryable<Flat> GetFlatList(FlatFilter filters, int buildingId)
    {
        return _context.Flats
            .Include(x => x.Building)
            .ThenInclude(x => x.Area)
            //.Where(x => x.BuildingId == x.Building.BuildingId)
            .Include(x => x.FlatType)
            .Include(x => x.Rooms)
            .Where(x => x.Rooms.Any(room => room.BuildingId == buildingId))
            .Where(x => x.BuildingId == buildingId)
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
                && (filters.BuildingName == null ||
                    f.Building.BuildingName.ToLower().Contains(filters.BuildingName.ToLower())))
            .AsNoTracking();
    }

    public IQueryable<int> GetTotalFlatBasedOnFilter(MetricFlatFilter filters, int buildingId)
    {
        return _context.Flats
            .Where(x => x.BuildingId == buildingId)
            .Where(f => filters.Status == null || f.Status == filters.Status)
            .Select(x => x.FlatId);
    }

    /// <summary>
    ///     Get flat by id
    /// </summary>
    /// <param name="flatId"></param>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public IQueryable<Flat> GetFlatDetail(int? flatId, int buildingId)
    {
        return _context.Flats
            .Include(x => x.Building)
            .ThenInclude(x => x.Area)
            .Include(x => x.FlatType)
            .Include(x => x.Rooms)
            //.Include(x => x.UtilitiesFlats)
            //.ThenInclude(x => x.Utility)
            .Where(x => x.FlatId == flatId && x.BuildingId == buildingId);
    }

    public async Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken token)
    {
        var roomInFlat = await _context.Flats
            .Where(x => x.FlatId == flatId)
            .Include(x => x.Rooms)
            .FirstOrDefaultAsync(token);

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
                    Message = "Phòng này đã đầy"
                };

            case not null when roomInFlat.Rooms.Any(x => x.AvailableSlots >= 1):
            {
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "Phòng này còn trống"
                };
            }

            case null:
            case not null when roomInFlat.Rooms.Any(_ => false):
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Căn hộ đang bảo trì"
                };
        }

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Lỗi hệ thống ở căn hộ"
        };
    }

    /// <summary>
    ///     AddInvoiceHistory new flat
    /// </summary>
    /// <param name="flat"></param>
    /// <param name="roomTypeId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> AddFlat(Flat flat, List<int> roomTypeId, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await _context.Flats.AddAsync(flat, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var roomType in roomTypeId)
            {
                var roomTypeName = await _context.RoomTypes
                    .FirstOrDefaultAsync(x => x.RoomTypeId == roomType && x.Status.ToLower() == "active",
                        cancellationToken);

                if (roomTypeName == null)
                    return new RepositoryResponse
                    {
                        IsSuccess = false,
                        Message = "Loại phòng này không tồn tại"
                    };

                var newRoom = new Room
                {
                    RoomName = roomTypeName.RoomTypeName,
                    Status = roomTypeName.Status,
                    RoomTypeId = roomTypeName.RoomTypeId,
                    AvailableSlots = roomTypeName.TotalSlot,
                    FlatId = flat.FlatId,
                    ElectricityAttribute = roomTypeName.ElectricityAttribute,
                    WaterAttribute = roomTypeName.WaterAttribute,
                    BuildingId = roomTypeName.BuildingId
                };

                await _context.Rooms.AddAsync(newRoom, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tạo mới căn hộ thành công"
            };
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);

            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo mới tòa nhà thất bại"
            };
        }
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
        flatData.WaterMeterBefore = flat.WaterMeterBefore;
        flatData.WaterMeterAfter = flat.WaterMeterAfter;
        flatData.ElectricityMeterBefore = flat.ElectricityMeterBefore;
        flatData.ElectricityMeterAfter = flat.ElectricityMeterAfter;
        flatData.FlatImageUrl1 = flat.FlatImageUrl1 ?? flatData.FlatImageUrl1;
        flatData.FlatImageUrl2 = flat.FlatImageUrl2 ?? flatData.FlatImageUrl2;
        flatData.FlatImageUrl3 = flat.FlatImageUrl3 ?? flatData.FlatImageUrl3;
        flatData.FlatImageUrl4 = flat.FlatImageUrl4 ?? flatData.FlatImageUrl4;
        flatData.FlatImageUrl5 = flat.FlatImageUrl5 ?? flatData.FlatImageUrl5;
        flatData.FlatImageUrl6 = flat.FlatImageUrl6 ?? flatData.FlatImageUrl6;

        _context.Attach(flatData).State = EntityState.Modified;

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
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
    public IQueryable<FlatType> GetFlatTypeList(FlatTypeFilter filters, int buildingId)
    {
        return _context.FlatTypes
            .Where(x => x.BuildingId == buildingId)
            .Where(x =>
                (filters.Status == null || x.Status == filters.Status)
                && (filters.FlatTypeName == null || (x.FlatTypeName.ToLower().Contains(filters.FlatTypeName.ToLower())
                                                     && (filters.RoomCapacity == null ||
                                                         x.RoomCapacity == filters.RoomCapacity))))
            .AsNoTracking();
    }

    public IQueryable<FlatType> GetFlatTypeList(int buildingId)
    {
        return _context.FlatTypes
            .Where(x => x.BuildingId == buildingId)
            .AsTracking();
    }

    /// <summary>
    ///     Get flat type by id
    /// </summary>
    /// <param name="flatTypeId"></param>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public IQueryable<FlatType> GetFlatTypeDetail(int? flatTypeId, int buildingId)
    {
        return _context.FlatTypes
            .Where(x => x.FlatTypeId == flatTypeId && x.BuildingId == buildingId && x.Status == true);
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
    public async Task<RepositoryResponse> UpdateFlatType(FlatType flatType)
    {
        var flatTypeData = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.FlatTypeId == flatType.FlatTypeId);

        if (flatTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Loại căn hộ không tìm thấy"
            };

        flatTypeData.FlatTypeName = flatType.FlatTypeName;
        flatTypeData.RoomCapacity = flatType.RoomCapacity;
        flatTypeData.Status = flatType.Status;

        _context.Attach(flatTypeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Loại căn hộ đã được cập nhật thành công"
        };
    }

    public async Task<RepositoryResponse> ToggleStatus(int flatTypeId)
    {
        var flatTypeData = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.FlatTypeId == flatTypeId);

        if (flatTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Loại căn hộ không tìm thấy"
            };

        _ = flatTypeData.Status = !flatTypeData.Status;

        _context.Attach(flatTypeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Trạng thái của loại căn hộ đã được thay đổi thành công"
        };
    }

    public async Task<RepositoryResponse> IsAnyFlatIsInUseWithThisType(int? flatTypeId, int buildingId,
        CancellationToken token)
    {
        var flatTypeFound = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.FlatTypeId == flatTypeId, token);

        if (flatTypeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Loại căn hộ không tìm thấy"
            };

        var isAnyFlatFound = await _context.Flats
            .Where(x => x.BuildingId == buildingId && x.FlatTypeId == flatTypeId)
            .AnyAsync(token);

        if (!isAnyFlatFound)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Không có căn hộ nào đang sử dụng loại căn hộ này"
            };

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Đang có 1 hoặc nhiều căn hộ đang sử dụng loại căn hộ này"
        };
    }

    public async Task<RepositoryResponse> IsFlatTypeNameDuplicate(string flatTypeName, int buildingId,
        CancellationToken token)
    {
        var flatTypeFound = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId
                                      && x.FlatTypeName.ToLower() == flatTypeName.ToLower(), token);

        if (flatTypeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tên loại căn hộ này có thể sử dụng"
            };

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Tên loại căn hộ này đã tồn tại"
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
                Message = "Loại căn hộ không tìm thấy"
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
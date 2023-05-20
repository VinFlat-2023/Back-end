using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class AreaRepository : IAreaRepository
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
                (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                && (filters.Status == null || x.Status == filters.Status))
            //&& (filters.Location == null || x.Location.ToLower().Contains(filters.Location.ToLower())))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get area detail by id
    /// </summary>
    /// <param name="areaId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Area?> GetAreaById(int? areaId, CancellationToken cancellationToken)
    {
        return await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == areaId, cancellationToken: cancellationToken);
    }


    public async Task<RepositoryResponse> GetAreaByName(string? areaName, CancellationToken token)
    {
        if (areaName == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tên khu vực không được để trống"
            };

        var area = await _context.Areas
            .FirstOrDefaultAsync(x => x.Name.ToLower() == areaName.ToLower(),
                token);

        switch (area)
        {
            case null:
                return new RepositoryResponse
                {
                    IsSuccess = true,
                    Message = "Tên khu vực này đang khả dụng"
                };
            case not null:
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Tên khu vực này đã tồn tại"
                };
        }
    }

    public async Task<RepositoryResponse> GetAreaByName(string? areaName, int? areaId, CancellationToken token)
    {
        var area = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == areaId, token);

        if (area == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không tìm thấy khu vực này"
            };

        if (areaName == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tên khu vực không được để trống"
            };

        if (areaName.ToLower().Equals(area.Name.ToLower()))
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tên khu vực thuộc về khu vực này"
            };

        if (await _context.Areas
                .FirstOrDefaultAsync(x => x.Name.ToLower() == areaName.ToLower(),
                    token) == null)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tên khu vực này đang khả dụng"
            };

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Tên khu vực này đã tồn tại"
        };
    }

    /// <summary>
    ///     AddExpenseHistory new area
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public async Task<Area?> AddArea(Area area)
    {
        await _context.Areas.AddAsync(area);
        await _context.SaveChangesAsync();
        return area;
    }

    /// <summary>
    ///     UpdateExpenseHistory area detail
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateArea(Area? area)
    {
        if (area == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Thông tin khu vực không được để trống"
            };
        var areaData = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == area.AreaId);

        if (areaData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Area not found"
            };

        areaData.Name = area.Name;
        areaData.Status = area.Status;
        
        if (areaData.AreaImageUrl1 != null)
            areaData.AreaImageUrl1 = area.AreaImageUrl1;
        if (areaData.AreaImageUrl2 != null)
            areaData.AreaImageUrl2 = area.AreaImageUrl2;
        if (areaData.AreaImageUrl3 != null)
            areaData.AreaImageUrl3 = area.AreaImageUrl3;
        if (areaData.AreaImageUrl4 != null)
            areaData.AreaImageUrl4 = area.AreaImageUrl4;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Khu vực đã cập nhật thành công"
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
                Message = "Khu vực không tìm thấy",
                IsSuccess = false
            };

        _ = areaFound.Status == !areaFound.Status;
        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            Message = "Trạng thái của khu vực đã được thay đổi",
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
                Message = "Khu vực không tìm thấy",
                IsSuccess = false
            };


        _context.Areas.Remove(areaFound);
        await _context.SaveChangesAsync();


        return new RepositoryResponse
        {
            Message = "Khu vực đã được xoá khỏi hệ thống",
            IsSuccess = true
        };
    }

    public async Task<RepositoryResponse> UpdateAreaImage(Area updateArea, int number)
    {
        var areaData = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == updateArea.AreaId);

        if (areaData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Khu vực không tìm thấy"
            };

        switch (number)
        {
            case 1:
                areaData.AreaImageUrl1 = updateArea.AreaImageUrl1;
                break;
            case 2:
                areaData.AreaImageUrl2 = updateArea.AreaImageUrl2;
                break;
            case 3:
                areaData.AreaImageUrl3 = updateArea.AreaImageUrl3;
                break;
            case 4:
                areaData.AreaImageUrl4 = updateArea.AreaImageUrl4;
                break;
        }

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Hình ảnh của khu vực đã được cập nhật"
        };
    }


    public async Task<Area?> GetAreaByName(string areaName)
    {
        return await _context.Areas
            .FirstOrDefaultAsync(x => x.Name.ToLower() == areaName.ToLower());
    }
}
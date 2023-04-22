﻿using Application.IRepository;
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
                (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Location == null || x.Location.ToLower().Contains(filters.Location.ToLower())))
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


    public async Task<RepositoryResponse> GetAreaByName(string? areaName, CancellationToken cancellationToken)
    {
        if (areaName == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tên khu vực không được để trống"
            };

        var area = await _context.Areas
            .FirstOrDefaultAsync(x => x.Name.ToLower() == areaName.ToLower(),
                cancellationToken);

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
                areaData.ImageUrl = updateArea.ImageUrl;
                break;
            case 2:
                areaData.ImageUrl2 = updateArea.ImageUrl;
                break;
            case 3:
                areaData.ImageUrl3 = updateArea.ImageUrl;
                break;
            case 4:
                areaData.ImageUrl4 = updateArea.ImageUrl;
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
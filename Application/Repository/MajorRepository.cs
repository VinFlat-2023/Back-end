using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class MajorRepository : IMajorRepository
{
    private readonly ApplicationContext _context;

    public MajorRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all majors
    /// </summary>
    /// <returns></returns>
    public IQueryable<Major> GetMajorList(MajorFilter filters)
    {
        return _context.Majors
            .Include(x => x.University)
            // Filter starts here
            .Where(x =>
                (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                && (filters.UniversityName == null ||
                    x.University.UniversityName.ToLower().Contains(filters.UniversityName.ToLower())))
            .AsNoTracking();
    }

    public IQueryable<Major> GetMajorListNoFilter()
    {
        return _context.Majors.AsQueryable();
    }

    /// <summary>
    ///     Get major by id
    /// </summary>
    /// <param name="majorId"></param>
    /// <returns></returns>
    public IQueryable<Major> GetMajorDetail(int? majorId)
    {
        return _context.Majors
            .Where(x => x.MajorId == majorId);
    }

    /// <summary>
    ///     Add new major
    /// </summary>
    /// <param name="major"></param>
    /// <returns></returns>
    public async Task<Major> AddMajor(Major major)
    {
        await _context.Majors.AddAsync(major);
        await _context.SaveChangesAsync();
        return major;
    }

    /// <summary>
    ///     Update major
    /// </summary>
    /// <param name="major"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateMajor(Major major)
    {
        var majorData = await _context.Majors
            .FirstOrDefaultAsync(x => x.MajorId == major.MajorId);
        if (majorData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Major not found"
            };

        majorData.Name = major?.Name ?? majorData.Name;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Major updated successfully"
        };
    }

    /// <summary>
    ///     Delete major by id
    /// </summary>
    /// <param name="majorId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteMajor(int majorId)
    {
        var majorFound = await _context.Majors
            .FirstOrDefaultAsync(x => x.MajorId == majorId);
        if (majorFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Major not found"
            };
        _context.Majors.Remove(majorFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Major deleted successfully"
        };
    }
}
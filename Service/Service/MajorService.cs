using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class MajorService : IMajorService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public MajorService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Major>?> GetMajorList(MajorFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Majors.GetMajorList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Major>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<List<Major>> GetMajorListByUniversity(int? id)
    {
        return await _repositoryWrapper.Majors.GetMajorListNoFilter()
            .Where(x => x.UniversityId == id)
            .ToListAsync();
    }

    public async Task<Major?> GetMajorById(int? majorId)
    {
        return await _repositoryWrapper.Majors.GetMajorDetail(majorId)
            .FirstOrDefaultAsync();
    }

    public async Task<Major?> AddMajor(Major major)
    {
        return await _repositoryWrapper.Majors.AddMajor(major);
    }

    public async Task<RepositoryResponse> UpdateMajor(Major major)
    {
        return await _repositoryWrapper.Majors.UpdateMajor(major);
    }

    public async Task<RepositoryResponse> DeleteMajor(int majorId)
    {
        return await _repositoryWrapper.Majors.DeleteMajor(majorId);
    }
}
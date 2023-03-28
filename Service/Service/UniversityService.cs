using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class UniversityService : IUniversityService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public UniversityService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<University>?> GetUniversityList(UniversityFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Universities.GetUniversityList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<University>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<University?> GetUniversityById(int? universityId)
    {
        return await _repositoryWrapper.Universities.GetUniversityDetail(universityId)
            .FirstOrDefaultAsync();
    }

    public async Task<University?> AddUniversity(University university)
    {
        return await _repositoryWrapper.Universities.AddUniversity(university);
    }

    public async Task<RepositoryResponse> UpdateUniversity(University university)
    {
        return await _repositoryWrapper.Universities.UpdateUniversity(university);
    }

    public async Task<RepositoryResponse> DeleteUniversity(int universityId)
    {
        return await _repositoryWrapper.Universities.DeleteUniversity(universityId);
    }
}
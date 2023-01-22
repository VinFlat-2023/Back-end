using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IUniversityService
{
    public Task<PagedList<University>?> GetUniversityList(UniversityFilter filters, CancellationToken token);
    public Task<University?> GetUniversityById(int? universityId);
    public Task<University?> AddUniversity(University university);
    public Task<University?> UpdateUniversity(University university);
    public Task<bool> DeleteUniversity(int universityId);
}
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IUniversityRepository
{
    public IQueryable<University> GetUniversityList(UniversityFilter filters);
    public IQueryable<University> GetUniversityDetail(int? universityId);
    public Task<University> AddUniversity(University university);
    public Task<University?> UpdateUniversity(University university);
    public Task<bool> DeleteUniversity(int universityId);
}
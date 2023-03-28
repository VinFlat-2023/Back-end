using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IMajorRepository
{
    public IQueryable<Major> GetMajorList(MajorFilter filters);
    public IQueryable<Major> GetMajorListNoFilter();
    public IQueryable<Major> GetMajorDetail(int? majorId);
    public Task<Major> AddMajor(Major major);
    public Task<RepositoryResponse> UpdateMajor(Major major);
    public Task<RepositoryResponse> DeleteMajor(int majorId);
}
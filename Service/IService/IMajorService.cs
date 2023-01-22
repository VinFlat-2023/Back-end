using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IMajorService
{
    public Task<PagedList<Major>?> GetMajorList(MajorFilter filters, CancellationToken token);
    public Task<List<Major>> GetMajorListByUniversity(int? id);
    public Task<Major?> GetMajorById(int? majorId);
    public Task<Major?> AddMajor(Major major);
    public Task<Major?> UpdateMajor(Major major);
    public Task<bool> DeleteMajor(int majorId);
}
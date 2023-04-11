using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IFeedbackTypeService
{
    public Task<PagedList<FeedbackType>?> GetFeedbackTypeList(FeedbackTypeFilter filter, CancellationToken token);
    public Task<FeedbackType?> GetFeedbackTypeById(int? feedbackTypeId);
    public Task<FeedbackType?> AddFeedbackType(FeedbackType feedbackType);
    public Task<RepositoryResponse> UpdateFeedbackType(FeedbackType feedbackType);
    public Task<RepositoryResponse> DeleteFeedbackType(int feedbackTypeId);
}
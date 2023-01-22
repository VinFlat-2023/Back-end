using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFeedbackTypeRepository
{
    public IQueryable<FeedbackType> GetFeedbackTypeList(FeedbackTypeFilter filters);
    public IQueryable<FeedbackType> GetFeedbackTypeDetail(int feedbackTypeId);
    public Task<FeedbackType> AddFeedbackType(FeedbackType feedbackType);
    public Task<FeedbackType?> UpdateFeedbackType(FeedbackType feedbackType);
    public Task<bool> DeleteFeedbackType(int feedbackTypeId);
}
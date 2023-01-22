using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IFeedbackService
{
    public Task<PagedList<Feedback>?> GetFeedbackList(FeedbackFilter filter, CancellationToken token);
    public Task<Feedback?> GetFeedbackById(int? feedbackId);
    public Task<Feedback?> AddFeedback(Feedback feedback);
    public Task<Feedback?> UpdateFeedback(Feedback feedback);
    public Task<bool> DeleteFeedback(int feedbackId);
}
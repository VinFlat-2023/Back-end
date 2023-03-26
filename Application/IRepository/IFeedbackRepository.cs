using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFeedbackRepository
{
    public IQueryable<Feedback> GetFeedbackList(FeedbackFilter filters);
    public IQueryable<Feedback> GetFeedbackDetail(int? feedbackId);
    public Task<Feedback> AddFeedback(Feedback feedback);
    public Task<RepositoryResponse> UpdateFeedback(Feedback feedback);
    public Task<RepositoryResponse> DeleteFeedback(int feedbackId);
}
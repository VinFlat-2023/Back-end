using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class FeedbackService : IFeedbackService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FeedbackService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Feedback>?> GetFeedbackList(FeedbackFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Feedbacks.GetFeedbackList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Feedback>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Feedback?> GetFeedbackById(int? feedbackId, CancellationToken token)
    {
        return await _repositoryWrapper.Feedbacks.GetFeedbackDetail(feedbackId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Feedback?> AddFeedback(Feedback feedback)
    {
        return await _repositoryWrapper.Feedbacks.AddFeedback(feedback);
    }

    public async Task<RepositoryResponse> UpdateFeedback(Feedback feedback)
    {
        return await _repositoryWrapper.Feedbacks.UpdateFeedback(feedback);
    }

    public async Task<RepositoryResponse> DeleteFeedback(int feedbackId)
    {
        return await _repositoryWrapper.Feedbacks.DeleteFeedback(feedbackId);
    }
}
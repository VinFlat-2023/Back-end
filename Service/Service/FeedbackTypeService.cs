using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class FeedbackTypeService : IFeedbackTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FeedbackTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<FeedbackType>?> GetFeedbackTypeList(FeedbackTypeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.FeedbackTypes.GetFeedbackTypeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<FeedbackType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<FeedbackType?> GetFeedbackTypeById(int feedbackTypeId)
    {
        return await _repositoryWrapper.FeedbackTypes.GetFeedbackTypeDetail(feedbackTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<FeedbackType?> AddFeedbackType(FeedbackType feedbackType)
    {
        return await _repositoryWrapper.FeedbackTypes.AddFeedbackType(feedbackType);
    }

    public async Task<RepositoryResponse> UpdateFeedbackType(FeedbackType feedbackType)
    {
        return await _repositoryWrapper.FeedbackTypes.UpdateFeedbackType(feedbackType);
    }

    public async Task<RepositoryResponse> DeleteFeedbackType(int feedbackTypeId)
    {
        return await _repositoryWrapper.FeedbackTypes.DeleteFeedbackType(feedbackTypeId);
    }
}
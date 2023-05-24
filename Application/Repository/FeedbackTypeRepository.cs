/*
using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class FeedbackTypeRepository : IFeedbackTypeRepository
{
    private readonly ApplicationContext _context;

    public FeedbackTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all feedback types
    /// </summary>
    /// <returns></returns>
    public IQueryable<FeedbackType> GetFeedbackTypeList(FeedbackTypeFilter filters)
    {
        return _context.FeedbackTypes
            .Where(x =>
                filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get feedback type by id
    /// </summary>
    /// <param name="feedbackTypeId"></param>
    /// <returns></returns>
    public IQueryable<FeedbackType> GetFeedbackTypeDetail(int? feedbackTypeId)
    {
        return _context.FeedbackTypes
            .Where(x => x.FeedbackTypeId == feedbackTypeId);
    }

    /// <summary>
    ///     AddInvoiceHistory new feedback type
    /// </summary>
    /// <param name="feedbackType"></param>
    /// <returns></returns>
    public async Task<FeedbackType> AddFeedbackType(FeedbackType feedbackType)
    {
        await _context.FeedbackTypes.AddAsync(feedbackType);
        await _context.SaveChangesAsync();
        return feedbackType;
    }

    /// <summary>
    ///     Update feedback type by id
    /// </summary>
    /// <param name="feedbackType"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateFeedbackType(FeedbackType? feedbackType)
    {
        var feedbackTypeData = await _context.FeedbackTypes
            .FirstOrDefaultAsync(x => x.FeedbackTypeId == feedbackType!.FeedbackTypeId);
        if (feedbackTypeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Feedback type not found"
            };

        feedbackTypeData.Name = feedbackType?.Name ?? feedbackTypeData.Name;

        _context.Attach(feedbackTypeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Feedback type updated successfully"
        };
    }

    /// <summary>
    ///     Delete feedback type by id
    /// </summary>
    /// <param name="feedbackTypeId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteFeedbackType(int feedbackTypeId)
    {
        var feedbackTypeFound = await _context.FeedbackTypes
            .FirstOrDefaultAsync(x => x.FeedbackTypeId == feedbackTypeId);
        if (feedbackTypeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Feedback type not found"
            };
        _context.FeedbackTypes.Remove(feedbackTypeFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Feedback type deleted successfully"
        };
    }
}
*/


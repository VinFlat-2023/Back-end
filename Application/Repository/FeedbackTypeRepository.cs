using Application.IRepository;
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
                filters.Name == null || x.Name.Contains(filters.Name))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get feedback type by id
    /// </summary>
    /// <param name="feedbackTypeId"></param>
    /// <returns></returns>
    public IQueryable<FeedbackType> GetFeedbackTypeDetail(int feedbackTypeId)
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
    public async Task<FeedbackType?> UpdateFeedbackType(FeedbackType? feedbackType)
    {
        var feedbackTypeData = await _context.FeedbackTypes
            .FirstOrDefaultAsync(x => x.FeedbackTypeId == feedbackType!.FeedbackTypeId);
        if (feedbackTypeData == null)
            return null;

        feedbackTypeData.Name = feedbackType?.Name ?? feedbackTypeData.Name;

        await _context.SaveChangesAsync();
        return feedbackTypeData;
    }

    /// <summary>
    ///     Delete feedback type by id
    /// </summary>
    /// <param name="feedbackTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteFeedbackType(int feedbackTypeId)
    {
        var feedbackTypeFound = await _context.FeedbackTypes
            .FirstOrDefaultAsync(x => x.FeedbackTypeId == feedbackTypeId);
        if (feedbackTypeFound == null)
            return false;
        _context.FeedbackTypes.Remove(feedbackTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }
}
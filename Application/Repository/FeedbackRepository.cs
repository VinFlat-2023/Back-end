using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class FeedbackRepository : IFeedbackRepository
{
    private readonly ApplicationContext _context;

    public FeedbackRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all feedbacks
    /// </summary>
    /// <returns></returns>
    public IQueryable<Feedback> GetFeedbackList(FeedbackFilter filters)
    {
        return _context.Feedbacks
            .Include(x => x.Flat)
            .Include(x => x.Renter)
            .Include(x => x.FeedbackType)
            .Where(x =>
                (filters.FeedbackTitle == null || x.FeedbackTitle.Contains(filters.FeedbackTitle))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.FlatId == null || x.FlatId == filters.FlatId)
                && (filters.FeedbackTypeId == null || x.FeedbackTypeId == filters.FeedbackTypeId)
                && (filters.RenterId == null || x.RenterId == filters.RenterId)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get feedback by id
    /// </summary>
    /// <param name="feedbackId"></param>
    /// <returns></returns>
    public IQueryable<Feedback> GetFeedbackDetail(int? feedbackId)
    {
        return _context.Feedbacks
            .Include(x => x.Flat)
            .Include(x => x.Renter)
            .Include(x => x.FeedbackType)
            .Where(x => x.FeedbackId == feedbackId);
    }

    /// <summary>
    ///     AddInvoiceHistory new feedback
    /// </summary>
    /// <param name="feedback"></param>
    /// <returns></returns>
    public async Task<Feedback> AddFeedback(Feedback feedback)
    {
        await _context.Feedbacks.AddAsync(feedback);
        await _context.SaveChangesAsync();
        return feedback;
    }

    /// <summary>
    ///     Update feedback by id
    /// </summary>
    /// <param name="feedback"></param>
    /// <returns></returns>
    public async Task<Feedback?> UpdateFeedback(Feedback feedback)
    {
        var feedbackData = await _context.Feedbacks
            .FirstOrDefaultAsync(x => x.FeedbackId == feedback.FeedbackId);
        if (feedbackData == null)
            return null;

        feedbackData.Description = feedback?.Description ?? feedbackData.Description;
        feedbackData.Status = feedback?.Status ?? feedbackData.Status;
        feedbackData.FeedbackTypeId = feedback?.FeedbackTypeId ?? feedbackData.FeedbackTypeId;

        await _context.SaveChangesAsync();
        return feedbackData;
    }

    /// <summary>
    ///     Delete feedback by id
    /// </summary>
    /// <param name="feedbackId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteFeedback(int feedbackId)
    {
        var feedbackFound = await _context.Feedbacks
            .FirstOrDefaultAsync(x => x.FeedbackId == feedbackId);
        if (feedbackFound == null)
            return false;
        _context.Feedbacks.Remove(feedbackFound);
        await _context.SaveChangesAsync();
        return true;
    }
}
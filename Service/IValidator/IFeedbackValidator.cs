using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IFeedbackValidator
{
    Task<ValidatorResult> ValidateParams(Feedback? obj, int? feedbackId);

    Task<ValidatorResult> ValidateParams(FeedbackType? obj, int? feedbackTypeId);
}
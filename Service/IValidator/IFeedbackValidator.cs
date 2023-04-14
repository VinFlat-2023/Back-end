using Domain.EntitiesForManagement;
using Domain.EntityRequest.FeedBack;
using Service.Validator;

namespace Service.IValidator;

public interface IFeedbackValidator
{
    Task<ValidatorResult> ValidateParams(Feedback? obj, int? feedbackId);
    Task<ValidatorResult> ValidateParams(FeedbackUpdateRequest? obj, int? feedbackId);
    Task<ValidatorResult> ValidateParams(FeedbackCreateRequest? obj);
    Task<ValidatorResult> ValidateParams(FeedbackType? obj, int? feedbackTypeId);

}
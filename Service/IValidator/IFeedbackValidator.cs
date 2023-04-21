using Domain.EntityRequest.FeedBack;
using Domain.EntityRequest.FeedbackType;
using Service.Validator;

namespace Service.IValidator;

public interface IFeedbackValidator
{
    //Task<ValidatorResult> ValidateParams(Feedback? obj, int? feedbackId, CancellationToken token);

    //Task<ValidatorResult> ValidateParams(FeedbackType? obj, int? feedbackTypeId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(FeedbackCreateRequest? feedback, CancellationToken token);

    Task<ValidatorResult> ValidateParams(FeedbackUpdateRequest? feedback, int? feedbackTypeId,
        CancellationToken token);

    Task<ValidatorResult> ValidateParams(FeedbackTypeCreateRequest? feedback, CancellationToken token);

    Task<ValidatorResult> ValidateParams(FeedbackTypeUpdateRequest? feedbackType, int? feedbackTypeId,
        CancellationToken token);
}
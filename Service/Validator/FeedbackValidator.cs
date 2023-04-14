using Domain.EntitiesForManagement;
using Domain.EntityRequest.FeedBack;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class FeedbackValidator : BaseValidator, IFeedbackValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public FeedbackValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Feedback? obj, int? feedbackId)
    {
        try
        {
            if (feedbackId != null)
                switch (obj?.FeedbackId)
                {
                    case not null when obj.FeedbackId != feedbackId:
                        ValidatorResult.Failures.Add("Feedback id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Feedback is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FeedbackCheck(obj.FeedbackId) == null)
                            ValidatorResult.Failures.Add("Feedback provided does not exist");
                        break;
                }

            if (feedbackId == null)
                switch (obj?.RenterId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Renter is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                            ValidatorResult.Failures.Add("Renter provided does not exist");
                        break;
                }

            if (feedbackId == null)
                switch (obj?.FlatId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                            ValidatorResult.Failures.Add("Flat provided does not exist");
                        break;
                }

            if (feedbackId == null)
                switch (obj?.FeedbackTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Feedback type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FeedbackTypeCheck(obj.FeedbackTypeId) == null)
                            ValidatorResult.Failures.Add("Feedback type provided does not exist");
                        break;
                }

            switch (obj?.Description)
            {
                case null:
                    ValidatorResult.Failures.Add("Feedback description is required");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Feedback description cannot exceed 500 characters");
                    break;
            }

            switch (obj?.FeedbackTitle)
            {
                case null:
                    ValidatorResult.Failures.Add("Feedback title is required");
                    break;
                case not null when obj.FeedbackTitle.Length > 100:
                    ValidatorResult.Failures.Add("Feedback title cannot exceed 100 characters");
                    break;
            }

            if (obj?.CreateDate == null)
                ValidatorResult.Failures.Add("Created date is required");

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the feedback");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FeedbackUpdateRequest? obj, int? feedbackId)
    {
        try
        {
            if (feedbackId != null)
                switch (feedbackId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Phản hồi là bắt buộc");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FeedbackCheck(feedbackId) == null)
                            ValidatorResult.Failures.Add("Phản hồi không tồn tại");
                        break;
                }

            switch (obj?.RenterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Người thuê là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                        ValidatorResult.Failures.Add("Người thuê không tồn tại");
                    break;
            }

            switch (obj?.FlatId)
            {
                case null:
                    ValidatorResult.Failures.Add("Căn hộ là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                        ValidatorResult.Failures.Add("Căn hộ không tồn tại");
                    break;
            }

            switch (obj?.FeedbackTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại phản hồi là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FeedbackTypeCheck(obj.FeedbackTypeId) == null)
                        ValidatorResult.Failures.Add("Loại phản hồi không tồn tại");
                    break;
            }

            switch (obj?.Description)
            {
                case null:
                    ValidatorResult.Failures.Add("Chi tiết là bắt buộc");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Chi tiết không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.FeedbackTitle)
            {
                case null:
                    ValidatorResult.Failures.Add("Tựa đề phản hồi là bắt buộc");
                    break;
                case not null when obj.FeedbackTitle.Length > 100:
                    ValidatorResult.Failures.Add("Tựa đề không được vượt quá 100 ký tự");
                    break;
            }

            if (obj?.CreateDate == null)
                ValidatorResult.Failures.Add("Ngày tạo là bắt buộc");

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái là bắt buộc");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực phản hồi");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FeedbackCreateRequest? obj)
    {
        try
        {
            switch (obj?.RenterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Người thuê là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                        ValidatorResult.Failures.Add("Người thuê không tồn tại");
                    break;
            }

            switch (obj?.FlatId)
            {
                case null:
                    ValidatorResult.Failures.Add("Căn hộ là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                        ValidatorResult.Failures.Add("Căn hộ không tồn tại");
                    break;
            }

            switch (obj?.FeedbackTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại phản hồi là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FeedbackTypeCheck(obj.FeedbackTypeId) == null)
                        ValidatorResult.Failures.Add("Loại phản hồi không tồn tại");
                    break;
            }

            switch (obj?.Description)
            {
                case null:
                    ValidatorResult.Failures.Add("Chi tiết là bắt buộc");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Chi tiết không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.FeedbackTitle)
            {
                case null:
                    ValidatorResult.Failures.Add("Tựa đề là bắt buộc");
                    break;
                case not null when obj.FeedbackTitle.Length > 100:
                    ValidatorResult.Failures.Add("Tựa đề không được vượt quá 100 ký tự");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái là bắt buộc");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực phản hồi");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FeedbackType? obj, int? feedbackTypeId)
    {
        try
        {
            if (feedbackTypeId != null)
                switch (obj?.FeedbackTypeId)
                {
                    case not null when obj.FeedbackTypeId != feedbackTypeId:
                        ValidatorResult.Failures.Add("Feedback type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Feedback type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FeedbackTypeCheck(obj.FeedbackTypeId) == null)
                            ValidatorResult.Failures.Add("Feedback type provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Feedback type name is required");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Feedback type name cannot exceed 100 characters");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the feedback type");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}
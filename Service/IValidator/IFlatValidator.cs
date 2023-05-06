using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Service.Validator;

namespace Service.IValidator;

public interface IFlatValidator
{
    // Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId);

    // Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId);
    Task<ValidatorResult> ValidateParams(FlatTypeUpdateRequest? flatType, int? flatId, int building,
        CancellationToken token);

    Task<ValidatorResult> ValidateParams(FlatTypeCreateRequest? flatType, int building, CancellationToken token);
    Task<ValidatorResult> ValidateParams(FlatUpdateRequest? flat, int? flatId, int building, CancellationToken token);
    Task<ValidatorResult> ValidateParams(FlatCreateRequest? flat, int building, CancellationToken token);
}
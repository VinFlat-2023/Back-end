using Domain.EntitiesForManagement;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Service.Validator;

namespace Service.IValidator;

public interface IFlatValidator
{
    Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId);
    Task<ValidatorResult> ValidateParams(FlatUpdateRequest? flat, int? flatTypeId);
    Task<ValidatorResult> ValidateParams(FlatCreateRequest? flat);
    Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId);
    Task<ValidatorResult> ValidateParams(FlatTypeUpdateRequest? obj, int? flatTypeId);
    Task<ValidatorResult> ValidateParams(FlatTypeCreateRequest? obj);
}
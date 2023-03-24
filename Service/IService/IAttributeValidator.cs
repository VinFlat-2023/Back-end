using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IService;

public interface IAttributeValidator
{
    Task<ValidatorResult> ValidateParams(AttributeForNumeric? obj, int? attributeId);
}
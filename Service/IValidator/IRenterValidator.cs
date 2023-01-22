using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IRenterValidator
{
    Task<ValidatorResult> ValidateParams(Renter? obj, int? renterId);
}
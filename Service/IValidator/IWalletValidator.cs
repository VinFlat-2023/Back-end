using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IWalletValidator
{
    ValidatorResult ValidateParams(Wallet? obj);

    ValidatorResult ValidateParams(WalletType? obj);
}
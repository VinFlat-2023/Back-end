namespace Service.Validator;

public class BaseValidator
{
    protected BaseValidator()
    {
        ValidatorResult = new ValidatorResult();
    }

    protected ValidatorResult ValidatorResult { get; set; }
}
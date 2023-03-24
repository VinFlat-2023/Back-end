using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IService;

namespace Service.Validator;

public class AttributeValidator : BaseValidator, IAttributeValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public AttributeValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(AttributeForNumeric? obj, int? attributeId)
    {
        try
        {
            var validateFloatingPointNumber =
                new Regex("[+]?([0-9]*[.])?[0-9]+");

            if (attributeId != null)
                switch (obj?.AttributeForNumericId)
                {
                    case { } when obj.AttributeForNumericId != attributeId:
                        ValidatorResult.Failures.Add("Attribute id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Attribute is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.AttributeCheck(obj.AttributeForNumericId) == null)
                            ValidatorResult.Failures.Add("Account provided does not exist");
                        break;
                }

            switch (obj?.ElectricityAttribute)
            {
                case { } when !validateFloatingPointNumber.IsMatch(obj.ElectricityAttribute):
                    ValidatorResult.Failures.Add("Attribute number is invalid");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Attribute is required");
                    break;
            }

            switch (obj?.WaterAttribute)
            {
                case { } when !validateFloatingPointNumber.IsMatch(obj.WaterAttribute):
                    ValidatorResult.Failures.Add("Attribute number is invalid");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Attribute is required");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the attribute");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}
using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Contract;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class ContractValidator : BaseValidator, IContractValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public ContractValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Contract? obj, int? contractId)
    {
        try
        {
            if (contractId != null)
                switch (obj?.ContractId)
                {
                    case { } when obj.ContractId != contractId:
                        ValidatorResult.Failures.Add("Contract id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Contract is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ContractCheck(obj.ContractId) == null)
                            ValidatorResult.Failures.Add("Contract provided does not exist");
                        break;
                }

            switch (obj?.ContractName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Contract name is required");
                    break;
                case { } when obj.ContractName.Length > 100:
                    ValidatorResult.Failures.Add("Contract name cannot exceed 100 characters");
                    break;
            }

            if (obj?.DateSigned == null)
                ValidatorResult.Failures.Add("Date signed is required");

            if (obj?.StartDate == null)
                ValidatorResult.Failures.Add("Start date is required");

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Contract description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Contract description cannot exceed 500 characters");
                    break;
            }

            if (obj?.EndDate == null)
                ValidatorResult.Failures.Add("End date is required");

            if (obj?.ContractStatus == null)
                ValidatorResult.Failures.Add("Contract status is required");

            switch (obj?.PriceForRent)
            {
                case { } when obj.PriceForRent <= 0:
                    ValidatorResult.Failures.Add("Rent price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Rent price is required");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case { } when obj.PriceForElectricity <= 0:
                    ValidatorResult.Failures.Add("Electricity price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Electricity price is required");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case { } when obj.PriceForWater <= 0:
                    ValidatorResult.Failures.Add("Water price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Water price is required");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case { } when obj.PriceForService <= 0:
                    ValidatorResult.Failures.Add("Service price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Service price is required");
                    break;
            }

            if (contractId == null)
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

            if (contractId == null)
                switch (obj?.BuildingId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null)
                            ValidatorResult.Failures.Add("Building provided does not exist");
                        break;
                }

            if (contractId == null)
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

            if (contractId == null)
                switch (obj?.RoomId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Room is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RoomCheck(obj.RoomId) == null)
                            ValidatorResult.Failures.Add("Room provided does not exist");
                        break;
                }
            // TODO : Flat and Room check validation
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the contract");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(ContractUpdateRequest? obj, int? contractId)
    {
        try
        {
            switch (obj?.ContractName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Contract name is required");
                    break;
                case { } when obj.ContractName.Length > 100:
                    ValidatorResult.Failures.Add("Contract name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.DateSigned)
            {
                case { } when obj.DateSigned > DateTime.Now:
                    ValidatorResult.Failures.Add("Date signed cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Date signed is required");
                    break;
            }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Description cannot exceed 500 characters");
                    break;
            }

            switch (obj?.StartDate)
            {
                case { } when obj.StartDate > DateTime.Now:
                    ValidatorResult.Failures.Add("Start date cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Start date is required");
                    break;
            }

            switch (obj?.EndDate)
            {
                case { } when obj.EndDate > DateTime.Now:
                    ValidatorResult.Failures.Add("End date cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("End date is required");
                    break;
            }

            switch (obj?.ContractStatus)
            {
                case { } when string.IsNullOrWhiteSpace(obj.ContractStatus):
                    ValidatorResult.Failures.Add("Contract status is required");
                    break;
                case { } when obj.ContractStatus.ToLower() != "active"
                              || obj.ContractStatus.ToLower() != "inactive"
                              || obj.ContractStatus.ToLower() != "suspend":
                    ValidatorResult.Failures.Add("Contract status must match Active, Inactive or Suspended");
                    break;
            }

            switch (obj?.PriceForRent)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForRent):
                    ValidatorResult.Failures.Add("Price for rent is required");
                    break;
                case { } when decimal.Parse(obj.PriceForRent) < 0:
                    ValidatorResult.Failures.Add("Price for rent cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForRent) > 1000000000:
                    ValidatorResult.Failures.Add("Price for rent cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForElectricity):
                    ValidatorResult.Failures.Add("Electricity price is required");
                    break;
                case { } when decimal.Parse(obj.PriceForElectricity) < 0:
                    ValidatorResult.Failures.Add("Electricity price cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForElectricity) > 1000000000:
                    ValidatorResult.Failures.Add("Electricity price cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForWater):
                    ValidatorResult.Failures.Add("Water price is required");
                    break;
                case { } when decimal.Parse(obj.PriceForWater) < 0:
                    ValidatorResult.Failures.Add("Water price cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForWater) > 1000000000:
                    ValidatorResult.Failures.Add("Water price cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForService):
                    ValidatorResult.Failures.Add("Building service price is required");
                    break;
                case { } when decimal.Parse(obj.PriceForService) < 0:
                    ValidatorResult.Failures.Add("Building service price cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForService) > 1000000000:
                    ValidatorResult.Failures.Add("Building service cannot be greater than 1,000,000,000");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the contract");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }

    public async Task<ValidatorResult> ValidateParams(ContractCreateRequest? obj)
    {
        try
        {
            switch (obj?.RenterUsername)
            {
                case { } when string.IsNullOrWhiteSpace(obj.RenterUsername):
                    ValidatorResult.Failures.Add("Renter username is required");
                    break;
                case { } when obj.RenterUsername.Length > 100:
                    ValidatorResult.Failures.Add("Renter username cannot exceed 100 characters");
                    break;
            }

            switch (obj?.FullName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.FullName):
                    ValidatorResult.Failures.Add("Full name is required");
                    break;
                case { } when obj.FullName.Length > 100:
                    ValidatorResult.Failures.Add("Full name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.RenterEmail)
            {
                case { } when obj.RenterEmail.Length > 100:
                    ValidatorResult.Failures.Add("Email cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.RenterEmail):
                    ValidatorResult.Failures.Add("Email is required");
                    break;
                case { } when !Regex.IsMatch(obj.RenterEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Email is invalid");
                    break;
                case { } when await _conditionCheckHelper.EmployeeEmailCheck(obj.RenterEmail) != null:
                    ValidatorResult.Failures.Add("Email is duplicated");
                    break;
                case { } when await _conditionCheckHelper.RenterEmailCheck(obj.RenterEmail) != null:
                    ValidatorResult.Failures.Add("Email is duplicated");
                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.RenterPhone)
            {
                case { } when string.IsNullOrWhiteSpace(obj.RenterPhone):
                    ValidatorResult.Failures.Add("Phone is required");
                    break;
                case { } when !validatePhoneNumberRegex.IsMatch(obj.RenterPhone):
                    ValidatorResult.Failures.Add("Phone number is invalid");
                    break;
                case { } when obj.RenterPhone.Length > 13:
                    ValidatorResult.Failures.Add("Phone number cannot exceed 13 characters");
                    break;
                case { } when obj.RenterPhone.Length < 7:
                    ValidatorResult.Failures.Add("Phone number cannot be less than 7 characters");
                    break;
            }

            switch (obj?.RenterBirthDate)
            {
                case { } when obj.RenterBirthDate > DateTime.Now:
                    ValidatorResult.Failures.Add("Birth date cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Birth date is required");
                    break;
            }

            switch (obj?.Address)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("Address is required");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("Address is required");
                    break;
            }

            switch (obj?.Gender)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Gender):
                    ValidatorResult.Failures.Add("Gender is required");
                    break;
                case { } when obj.Gender.ToLower() != "female" || obj.Gender.ToLower() != "male":
                    ValidatorResult.Failures.Add("Gender must match Male or Female");
                    break;
            }

            switch (obj?.ContractName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Contract name is required");
                    break;
                case { } when obj.ContractName.Length > 100:
                    ValidatorResult.Failures.Add("Contract name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.DateSigned)
            {
                case { } when obj.DateSigned > DateTime.Now:
                    ValidatorResult.Failures.Add("Date signed cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Date signed is required");
                    break;
            }

            switch (obj?.StartDate)
            {
                case { } when obj.StartDate > DateTime.Now:
                    ValidatorResult.Failures.Add("Start date cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Start date is required");
                    break;
            }

            switch (obj?.EndDate)
            {
                case { } when obj.EndDate > DateTime.Now:
                    ValidatorResult.Failures.Add("End date cannot be greater than today");
                    break;
                case null:
                    ValidatorResult.Failures.Add("End date is required");
                    break;
            }

            switch (obj?.ContractStatus)
            {
                case { } when string.IsNullOrWhiteSpace(obj.ContractStatus):
                    ValidatorResult.Failures.Add("Contract status is required");
                    break;
                case { } when obj.ContractStatus.ToLower() != "active"
                              || obj.ContractStatus.ToLower() != "inactive"
                              || obj.ContractStatus.ToLower() != "suspend":
                    ValidatorResult.Failures.Add("Contract status must match Active, Inactive or Suspended");
                    break;
            }

            switch (obj?.PriceForRent)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForRent):
                    ValidatorResult.Failures.Add("Price for rent is required");
                    break;
                case { } when decimal.Parse(obj.PriceForRent) < 0:
                    ValidatorResult.Failures.Add("Price for rent cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForRent) > 1000000000:
                    ValidatorResult.Failures.Add("Price for rent cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForElectricity):
                    ValidatorResult.Failures.Add("Electricity price is required");
                    break;
                case { } when decimal.Parse(obj.PriceForElectricity) < 0:
                    ValidatorResult.Failures.Add("Electricity price cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForElectricity) > 1000000000:
                    ValidatorResult.Failures.Add("Electricity price cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForWater):
                    ValidatorResult.Failures.Add("Water price is required");
                    break;
                case { } when decimal.Parse(obj.PriceForWater) < 0:
                    ValidatorResult.Failures.Add("Water price cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForWater) > 1000000000:
                    ValidatorResult.Failures.Add("Water price cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case { } when string.IsNullOrWhiteSpace(obj.PriceForService):
                    ValidatorResult.Failures.Add("Building service price is required");
                    break;
                case { } when decimal.Parse(obj.PriceForService) < 0:
                    ValidatorResult.Failures.Add("Building service price cannot be less than 0");
                    break;
                case { } when decimal.Parse(obj.PriceForService) > 1000000000:
                    ValidatorResult.Failures.Add("Building service cannot be greater than 1,000,000,000");
                    break;
            }

            switch (obj?.FlatId)
            {
                case null:
                    ValidatorResult.Failures.Add("Flat is required");
                    break;
                case { } when obj.FlatId < 0:
                    ValidatorResult.Failures.Add("Flat is invalid");
                    break;
                case { } when await _conditionCheckHelper.FlatCheck(obj.FlatId) == null:
                    ValidatorResult.Failures.Add("Flat is invalid");
                    break;
            }

            switch (obj?.RoomId)
            {
                case null:
                    ValidatorResult.Failures.Add("Room is required");
                    break;
                case { } when obj.RoomId < 0:
                    ValidatorResult.Failures.Add("Room is invalid");
                    break;
                case { } when await _conditionCheckHelper.RoomCheck(obj.RoomId) == null:
                    ValidatorResult.Failures.Add("Room is invalid");
                    break;
                case { } when await _conditionCheckHelper.RoomCheck(obj.RoomId) != null:
                    var room = await _conditionCheckHelper.RoomCheck(obj.RoomId);
                    switch (room)
                    {
                        case { } when room?.FlatId != obj.FlatId:
                            ValidatorResult.Failures.Add("Room is does not belong to the flat");
                            break;
                        case { AvailableSlots: 0 }:
                            ValidatorResult.Failures.Add("Room is full");
                            break;
                        case { AvailableSlots: < 0 }:
                            ValidatorResult.Failures.Add("Room available slots is invalid");
                            break;
                    }

                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the contract");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }
}
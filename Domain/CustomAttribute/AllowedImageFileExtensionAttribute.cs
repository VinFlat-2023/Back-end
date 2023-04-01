using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Domain.CustomAttribute;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class AllowedImageFileExtensionAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedImageFileExtensionAttribute(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile file)
            return ValidationResult.Success;
        var extension = Path.GetExtension(file.FileName);
        return !_extensions.Contains(extension.ToLower())
            ? new ValidationResult(GetErrorMessage())
            : ValidationResult.Success;
    }

    private static string GetErrorMessage()
    {
        return "This photo extension is not allowed.";
    }
}
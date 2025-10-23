using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.API.Attributes.Validation;

public class PositiveIdAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
            return ValidationResult.Success;
        if (!int.TryParse(value.ToString(), out int id))
            return new ValidationResult("AuthorId must be a number.");
        if(id <= 0)
            return new ValidationResult("AuthorId must be greater than zero.");
        return ValidationResult.Success;
    }
}
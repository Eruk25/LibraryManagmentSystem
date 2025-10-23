using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.API.Attributes.Validation;

public class YearRangeAttribute : ValidationAttribute
{
    private readonly int _minYear;

    public YearRangeAttribute(int minYear)
    {
        _minYear = minYear;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
            return ValidationResult.Success;
        if(!int.TryParse(value.ToString(), out var year))
            return new  ValidationResult("Year must be a number.");
        if(year < _minYear ||  year > DateTime.UtcNow.Year)
            return new  ValidationResult($"Year must be between {_minYear} and {DateTime.UtcNow.Year}.");
        
        return ValidationResult.Success;
    }
}
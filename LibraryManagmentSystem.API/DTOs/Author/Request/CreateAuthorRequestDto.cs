using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.API.DTOs;

public record CreateAuthorRequestDto(
    [param: Required(ErrorMessage = "Name is required.")]
    [param: StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 50 characters.")]
    string Name,
    [param: Required(ErrorMessage = "DateOfBirth is required.")]
    [param: RegularExpression(@"^\d{4}/\d{1,2}/\d{1,2}$", ErrorMessage = @"Input DateOfBirth in ""yyyy/mm/dd"" format")]
    string DateOfBirth);
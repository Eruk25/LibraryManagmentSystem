using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.API.DTOs;

public record UpdateAuthorRequestDto(
    [param: StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 to 50 characters.")]
    string? Name,
    [param: RegularExpression(@"^\d{4}/\d{1,2}/\d{1,2}$", ErrorMessage = @"Input DateOfBirth in ""yyyy/mm/dd"" format")]
    string? DateOfBirth);
using System.ComponentModel.DataAnnotations;
using LibraryManagmentSystem.API.Attributes.Validation;

namespace LibraryManagmentSystem.API.DTOs;

public record UpdateBookRequestDto(
    [param: StringLength(30, MinimumLength = 3, ErrorMessage = "Title cannot exceed 30 characters.")]
    string? Title = null,
    [param: YearRange(1400)]
    int? PublishedYear = null,
    [param: PositiveId()]
    int? AuthorId = null);
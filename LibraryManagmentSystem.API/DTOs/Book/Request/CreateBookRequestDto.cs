using System.ComponentModel.DataAnnotations;
using LibraryManagmentSystem.API.Attributes.Validation;

namespace LibraryManagmentSystem.API.DTOs;

public record CreateBookRequestDto(
    [param: Required(ErrorMessage = "Title is required.")]
    [param: StringLength(30, MinimumLength = 3, ErrorMessage = "Title cannot exceed 30 characters.")]
    string Title,
    [param: Required(ErrorMessage = "PublishedYear is required.")]
    [param: YearRange(1400)]
    int PublishedYear,
    [param: Required(ErrorMessage = "AuthorId is required.")]
    [param: PositiveId()]
    int AuthorId);
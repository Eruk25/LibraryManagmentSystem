using LibraryManagmentSystem.API.Attributes.Validation;

namespace LibraryManagmentSystem.API.DTOs.Book.Filters;

public record BookFilterQueryDto(
    [param: YearRange(1400)]
    int? PublishedYearFrom,
    [param: YearRange(1400)]
    int? PublishedYearTo);
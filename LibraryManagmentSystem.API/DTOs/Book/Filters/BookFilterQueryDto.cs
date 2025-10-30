namespace LibraryManagmentSystem.API.DTOs.Book.Filters;

public record BookFilterQueryDto(
    int? PublishedYearFrom,
    int? PublishedYearTo);
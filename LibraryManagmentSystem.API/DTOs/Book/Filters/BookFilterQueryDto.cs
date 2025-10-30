namespace LibraryManagmentSystem.API.DTOs.Author.Filters;

public record BookFilterQueryDto(
    int PublishedYearFrom,
    int PublishedYearTo
    );
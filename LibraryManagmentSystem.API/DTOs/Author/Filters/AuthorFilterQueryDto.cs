namespace LibraryManagmentSystem.API.DTOs.Author.Filters;

public record AuthorFilterQueryDto(
    int? QuantityBooks,
    string? AuthorName);
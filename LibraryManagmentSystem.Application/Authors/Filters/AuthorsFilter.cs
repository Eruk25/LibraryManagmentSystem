namespace LibraryManagmentSystem.Application.Authors.Filters;

public record AuthorsFilter(
    int? QuantityBooks,
    string? AuthorName);
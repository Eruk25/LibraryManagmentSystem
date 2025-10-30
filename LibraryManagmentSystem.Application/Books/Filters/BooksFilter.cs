namespace LibraryManagmentSystem.Application.Books.Filters;

public record BooksFilter(
    int? PublishedYearFrom,
    int? PublishedYearTo);
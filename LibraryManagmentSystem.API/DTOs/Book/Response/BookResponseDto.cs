namespace LibraryManagmentSystem.API.DTOs.Book.Response;

public record BookResponseDto(int Id, string Title, int PublishedYear, int AuthorId);
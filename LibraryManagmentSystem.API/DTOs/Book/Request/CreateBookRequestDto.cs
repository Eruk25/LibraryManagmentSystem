namespace LibraryManagmentSystem.API.DTOs;

public record CreateBookRequestDto(string Title, int PublishedYear, int AuthorId);
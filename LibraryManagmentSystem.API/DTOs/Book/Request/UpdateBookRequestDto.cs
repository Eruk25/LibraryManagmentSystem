namespace LibraryManagmentSystem.API.DTOs;

public record UpdateBookRequestDto(string? Title, int? PublishedYear, int? AuthorId);
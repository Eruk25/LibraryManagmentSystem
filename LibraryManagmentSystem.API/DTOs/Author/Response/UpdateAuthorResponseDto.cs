namespace LibraryManagmentSystem.API.DTOs.Author.Response;

public record UpdateAuthorResponseDto(
    int Id,
    string Name,
    string DateOfBirth);
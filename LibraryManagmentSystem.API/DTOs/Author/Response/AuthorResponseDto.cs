using LibraryManagmentSystem.API.DTOs.Book.Response;

namespace LibraryManagmentSystem.API.DTOs.Author.Response;

public record AuthorResponseDto(int Id, string Name, string DateOfBirth, IEnumerable<BookResponseDto> Books);
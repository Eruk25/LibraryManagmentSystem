using LibraryManagmentSystem.Application.Books;

namespace LibraryManagmentSystem.Application.Authors;

public record AuthorDto(int Id, string Name, DateOnly DateOfBirth, IEnumerable<BookDto> Books);
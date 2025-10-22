using MediatR;

namespace LibraryManagmentSystem.Application.Books.Commands;

public record CreateBookCommand(int Id, string Title, int PublishedYear, int AuthorId) : IRequest<int>;
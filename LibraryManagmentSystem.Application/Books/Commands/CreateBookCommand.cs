using MediatR;

namespace LibraryManagmentSystem.Application.Books.Commands;

public record CreateBookCommand(string Title, int PublishedYear, int AuthorId) : IRequest<int>;
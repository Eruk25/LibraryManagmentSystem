using MediatR;

namespace LibraryManagmentSystem.Application.Books.Commands;

public record UpdateBookCommand(int Id, string Title, int PublishedYear, int AuthorId) : IRequest;
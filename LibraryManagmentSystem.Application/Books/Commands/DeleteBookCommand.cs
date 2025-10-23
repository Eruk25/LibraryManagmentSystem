using MediatR;

namespace LibraryManagmentSystem.Application.Books.Commands;

public record DeleteBookCommand(int Id) : IRequest<bool>;
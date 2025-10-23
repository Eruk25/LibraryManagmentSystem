using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Queries;

public record GetAllBooksQuery() : IRequest<IEnumerable<BookDto>>;
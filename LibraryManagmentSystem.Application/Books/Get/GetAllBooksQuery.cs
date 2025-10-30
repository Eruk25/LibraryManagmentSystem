using LibraryManagmentSystem.Application.Books.Filters;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Queries;

public record GetAllBooksQuery(BooksFilter Filters) : IRequest<IEnumerable<BookDto>>;
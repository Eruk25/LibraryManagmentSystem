using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Books.Queries;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    private readonly IBookRepository _repository;

    public GetAllBooksQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetAllAsync(request.Filters);
        var result = books.Select(b => new BookDto(b.Id, b.Title, b.PublishedYear, b.AuthorId));
        return result;
    }
}
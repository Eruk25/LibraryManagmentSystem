using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Application.Books.Queries;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, BookDto>
{
    private readonly IBookRepository _repository;

    public GetByIdBookQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookDto> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.BookId);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {request.BookId} not found");
        return new BookDto(book.Id, book.Title, book.PublishedYear, book.AuthorId);
    }
}
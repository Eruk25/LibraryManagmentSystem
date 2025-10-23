using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Application.Books.Queries;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, Book>
{
    private readonly IBookRepository _repository;

    public GetByIdBookQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<Book> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.BookId);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {request.BookId} not found");
        return book;
    }
}
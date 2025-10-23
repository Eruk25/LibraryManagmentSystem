using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Books.Commands;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
{
    private readonly IBookRepository _repository;

    public UpdateBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {request.Id} not found");
        if (!string.IsNullOrEmpty(request.Title))
            book.UpdateTitle(request.Title);
        if(request.PublishedYear > 0)
            book.UpdatePublishedYear(request.PublishedYear);
        if(request.AuthorId > 0)
            book.UpdateAuthor(request.AuthorId);
        await _repository.UpdateAsync(request.Id, book);
        return book;
    }
}
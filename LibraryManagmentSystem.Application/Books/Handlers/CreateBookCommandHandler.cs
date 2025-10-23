using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Books.Commands;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        if(request == null)
            throw new ArgumentNullException(nameof(request));
        
        var author = await _authorRepository.GetByIdAsync(request.AuthorId);
        if(author == null)
            throw new KeyNotFoundException($"Author with id {request.AuthorId} not found");
        
        var book = new Book(request.Title, request.PublishedYear, request.AuthorId);
        return await _bookRepository.CreateAsync(book);
    }
}
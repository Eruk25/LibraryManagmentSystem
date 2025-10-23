using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Books.Commands;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public UpdateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {request.Id} not found");
        
        if (!string.IsNullOrEmpty(request.Title))
            book.UpdateTitle(request.Title);
        
        if(request.PublishedYear.HasValue)
            book.UpdatePublishedYear(request.PublishedYear.Value);

        if (request.AuthorId.HasValue)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId.Value);
            if(author == null)
                throw new KeyNotFoundException($"Author with id {request.AuthorId} not found");
            
            book.UpdateAuthor(request.AuthorId.Value);
        }
            
        await _bookRepository.UpdateAsync(request.Id, book);
        return new BookDto(book.Id, book.Title, book.PublishedYear, book.AuthorId);
    }
}
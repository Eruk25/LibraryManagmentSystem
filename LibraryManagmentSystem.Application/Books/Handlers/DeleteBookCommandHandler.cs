using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Books.Commands;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Handlers;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _repository;

    public DeleteBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {request.Id} was not found");
        return await _repository.DeleteAsync(book.AuthorId);
    }
}
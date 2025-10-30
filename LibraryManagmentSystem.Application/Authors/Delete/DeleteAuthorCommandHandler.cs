using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Commands;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
{
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _authorRepository.DeleteAsync(request.Id);
        if(!deleted)
            throw new KeyNotFoundException($"Author with id {request.Id} not found");
        return deleted;
    }
}
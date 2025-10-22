using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQuery, Author>
{
    private readonly IAuthorRepository _repository;

    public GetByIdAuthorQueryHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Author> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.AuthorId);
        if(author == null)
            throw new KeyNotFoundException($"Author with id {request.AuthorId} not found");
        return author;
    }
}
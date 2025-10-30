using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Application.Books;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQuery, AuthorDto>
{
    private readonly IAuthorRepository _repository;

    public GetByIdAuthorQueryHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuthorDto> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.AuthorId);
        if(author == null)
            throw new KeyNotFoundException($"Author with id {request.AuthorId} not found");
        return new AuthorDto(
            author.Id,
            author.Name,
            author.DateOfBirth,
            author.Books.Select(b => 
                new BookDto(b.Id, b.Title, b.PublishedYear, b.AuthorId)
            ).ToList());
    }
}
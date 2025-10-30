using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Application.Books;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
{
    private readonly IAuthorRepository _repository;

    public GetAllAuthorsQueryHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _repository.GetAllAsync(request.Filters);
        var result = authors.Select(a =>
            new AuthorDto(a.Id,
                a.Name,
                a.DateOfBirth,
                a.Books.Select(b => 
                    new BookDto(b.Id, b.Title, b.PublishedYear, b.AuthorId)
                ).ToList()));
        return result;
    }
}
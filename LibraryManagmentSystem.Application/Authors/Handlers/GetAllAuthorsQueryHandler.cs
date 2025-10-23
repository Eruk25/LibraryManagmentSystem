using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Queries;
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
        var authors = await _repository.GetAllAsync();
        var result = authors.Select(a => new AuthorDto(a.Id, a.Name, a.DateOfBirth));
        return result;
    }
}
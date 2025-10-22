using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>, IRequest<IEnumerable<Author>>
{
    private readonly IAuthorRepository _repository;

    public GetAllAuthorsQuery(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _repository.GetAllAsync();
        
        return authors;
    }
}
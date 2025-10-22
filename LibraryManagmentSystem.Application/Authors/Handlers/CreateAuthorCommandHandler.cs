using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Commands;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _repository;

    public CreateAuthorCommandHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        if(request == null)
            throw new ArgumentNullException(nameof(request));
        var author = new Author(request.Name, request.DateOfBirth);
        return await _repository.CreateAsync(author);
    }
}
using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Commands;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorDto>
{
    private readonly IAuthorRepository _repository;

    public UpdateAuthorCommandHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.Id);
        if(author == null)
            throw new KeyNotFoundException($"Author with id {request.Id} not found");
        
        if(!string.IsNullOrWhiteSpace(request.Name))
            author.UpdateName(request.Name);
        
        if(request.DateOfBirth.HasValue)
            author.UpdateDateOfBirth(request.DateOfBirth.Value);
        return new AuthorDto(author.Id, author.Name, author.DateOfBirth);
    }
}
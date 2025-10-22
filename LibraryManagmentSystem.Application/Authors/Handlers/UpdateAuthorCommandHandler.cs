using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Commands;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Handlers;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
{
    private readonly IAuthorRepository _repository;

    public UpdateAuthorCommandHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.Id);
        if(author == null)
            throw new KeyNotFoundException($"Author with id {request.Id} not found");
        
        if(!string.IsNullOrWhiteSpace(request.Name))
            author.Name = request.Name;
        
        if(request.DateOfBirth.HasValue)
            author.DateOfBirth = request.DateOfBirth.Value;
        return author;
    }
}
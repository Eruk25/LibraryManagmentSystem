using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Abstractions.Services;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _authorRepository.GetAllAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if(author == null)
            throw new KeyNotFoundException($"Author with id {id} not found");
        return author;
    }

    public async Task<Author> CreateAsync(Author author)
    {
        var newAuthor = await _authorRepository.CreateAsync(author);
        if(newAuthor == null)
            throw new ArgumentNullException(nameof(newAuthor));
        return newAuthor;
    }

    public async Task<Author?> UpdateAsync(int id, Author author)
    {
        var newAuthor = await _authorRepository.UpdateAsync(id, author);
        if(newAuthor == null)
            throw new KeyNotFoundException($"Author with id {id} not found");
        return newAuthor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var success = await _authorRepository.DeleteAsync(id);
        if(!success)
            throw new KeyNotFoundException($"Author with id {id} not found");
        return true;
    }
}
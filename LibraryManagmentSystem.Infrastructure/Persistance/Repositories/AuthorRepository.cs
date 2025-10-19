using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Infrastructure.Persistance.DB;

namespace LibraryManagmentSystem.Infrastructure.Persistance.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationContext _context;

    public AuthorRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<Author>> GetAllAsync()
    {
        return Task.FromResult(_context.Authors.AsEnumerable());
    }

    public Task<Author?> GetByIdAsync(int id)
    {
        var author = _context.Authors.FirstOrDefault(author => author.Id == id);
        if (author == null)
            return Task.FromResult<Author?>(null);
        return Task.FromResult(author);
    }

    public Task<Author?> CreateAsync(Author? author)
    {
        if(author == null)
            return Task.FromResult<Author?>(null);
        author.Id = _context.Authors.Count > 0 ? _context.Authors.Max(au => au.Id) + 1 : 1;
        _context.Authors.Add(author);
        return Task.FromResult(author);
    }

    public Task<Author?> UpdateAsync(int id, Author author)
    {
        var existing = _context.Authors.FirstOrDefault(au => au.Id == id);
        if (existing == null)
            return Task.FromResult<Author?>(null);
        existing.Name = author.Name;
        existing.DateOfBirth = author.DateOfBirth;
        return Task.FromResult(existing);  
    }

    public Task<bool> DeleteAsync(int id)
    {
        var author = _context.Authors.FirstOrDefault(author => author.Id == id);
        if (author == null)
            return Task.FromResult(false);
        _context.Authors.Remove(author);
        return Task.FromResult(true);
    }
}
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
        return Task.FromResult(author);
    }

    public Task<int> CreateAsync(Author author)
    {
        author.UpdateId(_context.Authors.Count > 0 ? _context.Authors.Max(au => au.Id) + 1 : 1);
        _context.Authors.Add(author);
        return Task.FromResult(author.Id);
    }

    public Task<Author?> UpdateAsync(int id, Author author)
    {
        var existing = _context.Authors.FirstOrDefault(au => au.Id == id);
        if (existing == null)
            return Task.FromResult<Author?>(null);
        existing.UpdateName(author.Name);
        existing.UpdateDateOfBirth(author.DateOfBirth);
        return Task.FromResult(existing);  
    }

    public Task<bool> DeleteAsync(int id)
    {
        var author = _context.Authors.First(author => author.Id == id);
        _context.Authors.Remove(author);
        return Task.FromResult(true);
    }
}
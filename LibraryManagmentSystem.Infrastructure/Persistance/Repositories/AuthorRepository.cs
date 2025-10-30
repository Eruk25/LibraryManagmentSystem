using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Authors.Filters;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Infrastructure.Extenstions.Authors;
using LibraryManagmentSystem.Infrastructure.Persistance.DB;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Infrastructure.Persistance.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryContext _context;

    public AuthorRepository(LibraryContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Author>> GetAllAsync(AuthorsFilter filters)
    {
        return await _context.Authors
            .Include(au => au.Books)
            .ApplyFilter(filters)
            .ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        var author = await _context.Authors
            .Include(au => au.Books)
            .FirstOrDefaultAsync(au => au.Id == id);
        return author;
    }

    public async Task<int> CreateAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
        return author.Id;
    }

    public async Task<Author> UpdateAsync(int id, Author author)
    {
        var existing = await _context.Authors.FirstAsync(au => au.Id == id);
        existing.UpdateName(author.Name);
        existing.UpdateDateOfBirth(author.DateOfBirth);
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var author = await _context.Authors.FirstAsync(au => au.Id == id);
        _context.Authors.Remove(author);
        return true;
    }
}
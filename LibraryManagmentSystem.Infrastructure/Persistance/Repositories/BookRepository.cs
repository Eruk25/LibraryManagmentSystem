using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Infrastructure.Persistance.DB;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Infrastructure.Persistance.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books
            .ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(book => book.Id == id);
        return book;
    }

    public async Task<int> CreateAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        return book.Id;
    }

    public async Task<Book> UpdateAsync(int id, Book book)
    {
        var existing = await _context.Books.FirstAsync(b => b.Id == id);
        existing.UpdateTitle(book.Title);
        existing.UpdatePublishedYear(book.PublishedYear);
        existing.UpdateAuthor(book.AuthorId);
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FirstAsync(b => b.Id == id);
        _context.Books.Remove(book);
        return true;
    }
}
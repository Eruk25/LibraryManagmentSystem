using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Books.Filters;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Infrastructure.Extenstions.Books;
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
    
    public async Task<IEnumerable<Book>> GetAllAsync(BooksFilter filters)
    {
        return await _context.Books
            .ApplyFilter(filters)
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
        await _context.SaveChangesAsync();
        return book.Id;
    }

    public async Task<Book> UpdateAsync(int id, Book book)
    {
        var existing = await _context.Books.FirstAsync(b => b.Id == id);
        existing.UpdateTitle(book.Title);
        existing.UpdatePublishedYear(book.PublishedYear);
        existing.UpdateAuthor(book.AuthorId);
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if(book == null)
            return false;
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}
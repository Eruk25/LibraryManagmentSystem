using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Infrastructure.Persistance.DB;

namespace LibraryManagmentSystem.Infrastructure.Persistance.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationContext _context;

    public BookRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<Book>> GetAllAsync()
    {
        return Task.FromResult(_context.Books.AsEnumerable());
    }

    public Task<Book?> GetByIdAsync(int id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if(book == null)
            return Task.FromResult<Book?>(null);
        return Task.FromResult(book);
    }

    public Task<Book?> CreateAsync(Book? book)
    {
        if(book == null)
            return Task.FromResult<Book?>(null);
        book.Id = _context.Books.Count > 0 ? _context.Books.Max(b => b.Id) + 1 : 0;
        _context.Books.Add(book);
        return Task.FromResult(book);
    }

    public Task<Book?> UpdateAsync(int id, Book book)
    {
        var existing = _context.Books.FirstOrDefault(b => b.Id == id);
        if (existing == null)
            return Task.FromResult<Book?>(null);
        existing.Title = book.Title;
        existing.PublishedDate = book.PublishedDate;
        existing.AuthorId = book.AuthorId;
        return Task.FromResult(existing);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return Task.FromResult(false);
        _context.Books.Remove(book);
        return Task.FromResult(true);
    }
}
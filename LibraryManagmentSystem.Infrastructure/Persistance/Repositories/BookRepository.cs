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
        return Task.FromResult(book);
    }

    public Task<int> CreateAsync(Book book)
    {
        book.GetType().GetProperty("Id")?.SetValue(book, _context.Books.Count + 1);
        _context.Books.Add(book);
        return Task.FromResult(book.Id);
    }

    public Task<Book> UpdateAsync(int id, Book book)
    {
        var existing = _context.Books.First(b => b.Id == id);
        existing.UpdateTitle(book.Title);
        existing.UpdatePublishedYear(book.PublishedYear);
        existing.UpdateAuthor(book.AuthorId);
        return Task.FromResult(existing);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var book = _context.Books.First(b => b.Id == id);
        _context.Books.Remove(book);
        return Task.FromResult(true);
    }
}
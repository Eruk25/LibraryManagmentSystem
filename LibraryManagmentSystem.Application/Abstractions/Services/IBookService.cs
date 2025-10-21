using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Abstractions.Services;

public interface IBookService
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<Book?> GetByIdAsync(int id);
    public Task<Book> CreateAsync(Book entity);
    public Task<Book?> UpdateAsync(int id, Book entity);
    public Task<bool> DeleteAsync(int id);
}
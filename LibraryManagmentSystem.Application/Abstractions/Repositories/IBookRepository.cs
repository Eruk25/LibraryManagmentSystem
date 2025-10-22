using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Abstractions.Repositories;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<Book?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Book book);
    public Task<Book?> UpdateAsync(int id, Book book);
    public Task<bool> DeleteAsync(int id);
}
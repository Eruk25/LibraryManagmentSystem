using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Abstractions.Repositories;

public interface IAuthorRepository
{
    public Task<IEnumerable<Author>> GetAllAsync();
    public Task<Author?> GetByIdAsync(int id);
    public Task<Author?> CreateAsync(Author author);
    public Task<Author?> UpdateAsync(int id, Author author);
    public Task<bool> DeleteAsync(int id);
}
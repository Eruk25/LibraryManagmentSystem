using LibraryManagmentSystem.Application.Authors.Filters;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Abstractions.Repositories;

public interface IAuthorRepository
{
    public Task<IEnumerable<Author>> GetAllAsync(AuthorsFilter filters);
    public Task<Author?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Author author);
    public Task<Author> UpdateAsync(int id, Author author);
    public Task<bool> DeleteAsync(int id);
}
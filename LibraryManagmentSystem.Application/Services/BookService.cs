using LibraryManagmentSystem.Application.Abstractions.Repositories;
using LibraryManagmentSystem.Application.Abstractions.Services;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {id} not found");
        return book;
    }

    public Task<Book> CreateAsync(Book entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        return _repository.CreateAsync(entity);
    }

    public async Task<Book?> UpdateAsync(int id, Book enity)
    {
        var book = await _repository.UpdateAsync(id, enity);
        if(book == null)
            throw new KeyNotFoundException($"Book with id {id} not found");
        return book;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var success = await _repository.DeleteAsync(id);
        if(!success)
            throw new KeyNotFoundException($"Book with id {id} not found");
        return true;
    }
}
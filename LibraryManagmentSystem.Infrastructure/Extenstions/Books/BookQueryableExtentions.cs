using LibraryManagmentSystem.Application.Books.Filters;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Infrastructure.Extenstions.Books;

public static class BookQueryableExtentions
{
    public static IQueryable<Book> ApplyFilter(this IQueryable<Book> query, BooksFilter filters)
    {
        if (filters.PublishedYearFrom.HasValue)
            query = query.Where(b => b.PublishedYear >= filters.PublishedYearFrom);
        
        if(filters.PublishedYearTo.HasValue)
            query = query.Where(b => b.PublishedYear <= filters.PublishedYearTo);
        
        return query;
    }
}
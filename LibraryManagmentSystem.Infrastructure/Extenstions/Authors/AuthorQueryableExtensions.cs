using LibraryManagmentSystem.Application.Authors.Filters;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Infrastructure.Extenstions.Authors;

public static class AuthorQueryableExtensions
{
    public static IQueryable<Author> ApplyFilter(this IQueryable<Author> query, AuthorsFilter filters)
    {
        if (!string.IsNullOrWhiteSpace(filters.AuthorName))
            query = query.Where(au => au.Name.Contains(filters.AuthorName));
        
        if(filters.QuantityBooks.HasValue)
            query = query.Where(au => au.Books.Count() == filters.QuantityBooks.Value);
        
        return query;
    }
}
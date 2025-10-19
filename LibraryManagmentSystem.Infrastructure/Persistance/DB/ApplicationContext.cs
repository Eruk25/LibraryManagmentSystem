using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Infrastructure.Persistance.DB;

public class ApplicationContext
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Author> Authors { get; set; } = new List<Author>();
}
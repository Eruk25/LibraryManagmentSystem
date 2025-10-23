namespace LibraryManagmentSystem.Domain.Entities;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public int PublishedYear { get; private set; }
    public int AuthorId { get; private set; }
    public Author? Author { get; private set; }

    public Book(string title, int publishedYear, int authorId)
    {
        UpdateTitle(title);
        UpdatePublishedYear(publishedYear);
        UpdateAuthor(authorId);
    }

    public void UpdateId(int newId)
    {
        if(newId <= 0)
            throw new ArgumentException("Id cannot be less or equal to zero", nameof(newId));
        Id = newId;
    }
    public void UpdateTitle(string title)
    {
        if(string.IsNullOrEmpty(title))
            throw new ArgumentException("Title can not be null or empty", nameof(title));
        Title = title;
    }
    public void UpdatePublishedYear(int publishedYear)
    {
        if(!IsValidYear(publishedYear))
            throw new ArgumentException("The published year must be between 1500 and current year", nameof(publishedYear));
        PublishedYear = publishedYear;
    }
    public void UpdateAuthor(int authorId)
    {
        if(authorId <= 0)
            throw new ArgumentException("The authorId can not be negative", nameof(authorId));
        AuthorId = authorId;
    }
    private static bool IsValidYear(int year)
    {
        return year >= 1500 && year <= DateTime.UtcNow.Year;
    }
}
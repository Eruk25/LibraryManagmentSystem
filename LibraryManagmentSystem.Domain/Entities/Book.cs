namespace LibraryManagmentSystem.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublishedDate { get; set; }
    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public Book(string title, int publishedDate, int authorId)
    {
        if(string.IsNullOrEmpty(title))
            throw new ArgumentException("Title can not be null or empty");
        if(!IsValidYear(publishedDate))
            throw new ArgumentException("The published year is incorrect");
        if(authorId < 0)
            throw new ArgumentException("The authorId can not be negative");
        Title = title;
        PublishedDate = publishedDate;
        AuthorId = authorId;
    }

    public bool IsValidYear(int year)
    {
        var currentDate = DateOnly.Parse(DateTime.UtcNow.Year.ToString());
        return year >= 1900 && year <= currentDate.Year;
    }
}
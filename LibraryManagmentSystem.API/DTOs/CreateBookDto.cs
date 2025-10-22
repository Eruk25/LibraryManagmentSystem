namespace LibraryManagmentSystem.API.DTOs;

public class CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public int PublishYear { get; set; }
    public int AuthorId { get; set; }
}
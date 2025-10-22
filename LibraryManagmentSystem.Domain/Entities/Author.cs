namespace LibraryManagmentSystem.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public Author(string name, string birthOfDate)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty");
        if(string.IsNullOrEmpty(birthOfDate))
            throw new ArgumentException("Birth of date cannot be null or empty");
        Name = name;
        DateOfBirth = DateOnly.Parse(birthOfDate);
    }
    public Author(){}
}
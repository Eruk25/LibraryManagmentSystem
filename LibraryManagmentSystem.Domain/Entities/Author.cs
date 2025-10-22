namespace LibraryManagmentSystem.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public Author(string name, DateOnly dateOfBirth)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty");
        if(DateOfBirth > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("Date of birth cannot be in the future");
        if(dateOfBirth.Year < 1800)
            throw new ArgumentException("Date of birth cannot be less than 1800");
        Name = name;
        DateOfBirth = dateOfBirth;
    }
    public Author(){}
}
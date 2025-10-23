namespace LibraryManagmentSystem.Domain.Entities;

public class Author
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateOnly DateOfBirth { get; private set; }

    public Author(string name, DateOnly dateOfBirth)
    {
        UpdateName(name);
        UpdateDateOfBirth(dateOfBirth);
    }
    
    public void UpdateName(string name)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        Name = name;
    }

    public void UpdateDateOfBirth(DateOnly dateOfBirth)
    {
        if(dateOfBirth > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("Date of birth cannot be in the future", nameof(dateOfBirth));
        if(dateOfBirth.Year < 1400)
            throw new ArgumentException("Date of birth cannot be less than 1400", nameof(dateOfBirth));
        DateOfBirth = dateOfBirth;
    }
    public Author(){}
}
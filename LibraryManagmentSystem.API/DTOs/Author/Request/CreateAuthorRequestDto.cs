namespace LibraryManagmentSystem.API.DTOs;

public class CreateAuthorRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
}
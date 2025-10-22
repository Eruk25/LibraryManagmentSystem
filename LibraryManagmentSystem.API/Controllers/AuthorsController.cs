using LibraryManagmentSystem.API.DTOs;
using LibraryManagmentSystem.API.DTOs.Author.Response;
using LibraryManagmentSystem.Application.Abstractions.Services;
using LibraryManagmentSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.API.Controllers;

public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAsync()
    {
        var dto =  await _authorService.GetAllAsync();
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponseDto>> GetByIdAsync(int id)
    {
        var dto = await _authorService.GetByIdAsync(id);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorResponseDto>> CreateAsync(CreateAuthorRequestDto dto)
    {
        var author = new Author
        {
            Name = dto.Name,
            DateOfBirth = DateOnly.Parse(dto.DateOfBirth),
        };
        var result = await _authorService.CreateAsync(author);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AuthorResponseDto>> UpdateAsync(int id, UpdateAuthorRequestDto dto)
    {
        var author = new Author()
        {
            Name = dto.Name,
            DateOfBirth = DateOnly.Parse(dto.DateOfBirth),
        };
        var result = await _authorService.UpdateAsync(id, author);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var result = await _authorService.DeleteAsync(id);
        return Ok(result);
    }
}
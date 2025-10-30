using LibraryManagmentSystem.API.DTOs;
using LibraryManagmentSystem.API.DTOs.Author.Filters;
using LibraryManagmentSystem.API.DTOs.Author.Response;
using LibraryManagmentSystem.API.DTOs.Book.Response;
using LibraryManagmentSystem.Application.Authors.Commands;
using LibraryManagmentSystem.Application.Authors.Filters;
using LibraryManagmentSystem.Application.Authors.Queries;
using LibraryManagmentSystem.Application.Books.Filters;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAsync([FromQuery]AuthorFilterQueryDto filtersDto)
    {
        var filters = new AuthorsFilter(
            filtersDto.QuantityBooks,
            filtersDto.AuthorName);
        
        var authors = await _mediator.Send(new GetAllAuthorsQuery(filters));
        var response = authors
            .Select(a => new AuthorResponseDto(
                a.Id,
                a.Name,
                a.DateOfBirth.ToString("dd/MM/yyyy"),
                a.Books.Select(b =>
                    new BookResponseDto(b.Id, b.Title, b.PublisherYear, b.AuthorId)
                ).ToList()));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponseDto>> GetByIdAsync(int id)
    {
        var author = await _mediator.Send(new GetByIdAuthorQuery(id));
        var response = new AuthorResponseDto(
            author.Id,
            author.Name,
            author.DateOfBirth.ToString("dd/MM/yyyy"),
            author.Books.Select(b =>
                new BookResponseDto(b.Id, b.Title, b.PublisherYear, b.AuthorId)
            ).ToList());
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateAsync([FromBody]CreateAuthorRequestDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _mediator.Send(new CreateAuthorCommand(
            dto.Name,
            DateOnly.Parse(dto.DateOfBirth)));
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateAuthorResponseDto>> UpdateAsync(int id, [FromBody]UpdateAuthorRequestDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _mediator.Send(new UpdateAuthorCommand(
            id,
            dto.Name,
            dto.DateOfBirth));
        
        var response = new UpdateAuthorResponseDto(
            result.Id,
            result.Name,
            result.DateOfBirth.ToString("dd/MM/yyyy"));
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var response = await _mediator.Send(new DeleteAuthorCommand(id));
        return Ok(response);
    }
}
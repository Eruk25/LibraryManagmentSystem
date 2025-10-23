using LibraryManagmentSystem.API.DTOs;
using LibraryManagmentSystem.API.DTOs.Book.Response;
using LibraryManagmentSystem.Application.Books;
using LibraryManagmentSystem.Application.Books.Commands;
using LibraryManagmentSystem.Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllAsync()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());
        var response = books.Select(b => new BookResponseDto(
            b.Id,
            b.Title,
            b.PublisherYear,
            b.AuthorId));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDto>> GetByIdAsync(int id)
    {
        var book = await _mediator.Send(new GetByIdBookQuery(id));
        var response = new BookResponseDto(
            book.Id,
            book.Title,
            book.PublisherYear,
            book.AuthorId);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateAsync([FromBody]CreateBookRequestDto dto)
    {
        var response = await _mediator.Send(new CreateBookCommand(
            dto.Title,
            dto.PublishedYear,
            dto.AuthorId));
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookResponseDto>> UpdateAsync(int id, UpdateBookRequestDto dto)
    {
        var book = await _mediator.Send(new UpdateBookCommand(
            id,
            dto.Title,
            dto.PublishedYear,
            dto.AuthorId));
        var response = new BookResponseDto(
            book.Id,
            book.Title,
            book.PublisherYear,
            book.AuthorId);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var response = await _mediator.Send(new DeleteBookCommand(id));
        return Ok(response);
    }
}
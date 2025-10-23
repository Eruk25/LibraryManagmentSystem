using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Books.Queries;

public record GetByIdBookQuery(int Id) : IRequest<Book>;
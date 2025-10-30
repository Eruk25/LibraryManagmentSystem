using LibraryManagmentSystem.Application.Authors.Filters;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Queries;

public record GetAllAuthorsQuery(AuthorsFilter Filters) : IRequest<IEnumerable<AuthorDto>>;
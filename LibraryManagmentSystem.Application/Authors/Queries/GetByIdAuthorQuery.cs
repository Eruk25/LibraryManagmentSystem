using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Queries;

public record GetByIdAuthorQuery(int AuthorId) : IRequest<AuthorDto>;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Commands;

public record UpdateAuthorCommand(int Id, string? Name, DateOnly? DateOfBirth) : IRequest<Author>; 
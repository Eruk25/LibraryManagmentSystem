using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Commands;

public record DeleteAuthorCommand(int Id) : IRequest<bool>;
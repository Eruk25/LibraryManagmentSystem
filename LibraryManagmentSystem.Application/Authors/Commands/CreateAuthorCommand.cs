using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Commands;

public record CreateAuthorCommand(string Name, DateOnly DateOfBirth) : IRequest<int>;

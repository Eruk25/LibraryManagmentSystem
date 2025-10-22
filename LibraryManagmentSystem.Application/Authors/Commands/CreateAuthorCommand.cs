using MediatR;

namespace LibraryManagmentSystem.Application.Authors.Commands;

public record CreateAuthorCommand(int Id, string Name, DateOnly DateOfBirth) : IRequest<int>;

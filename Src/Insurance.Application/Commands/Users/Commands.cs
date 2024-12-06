using Insurance.Application.Interfaces;

namespace Insurance.Application.Commands.Users;

public record CreateUserCommand(string Username, string Password, string Role) : ICommand<Guid>;


public record LoginCommand(string Username, string Password) : ICommand<CommandResponse<LoginCommandResponseModel>>;
public record LoginCommandResponseModel(string Username, string Token);
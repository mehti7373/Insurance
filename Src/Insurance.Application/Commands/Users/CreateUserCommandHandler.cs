using Insurance.Application.Interfaces;
using Insurance.Core.Entities;
using Insurance.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Insurance.Application.Commands.Users;

public class CreateUserCommandHandler(IUserRepository _userRepository, ILogger<CreateUserCommandHandler> logger) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(command.Username, HashPassword(command.Password), command.Role);
        await _userRepository.AddAsync(user);

        logger.LogInformation("command execuetd : {Command} , {Username} , {Role} , {CreatedUserId}",
            nameof(CreateUserCommand), command.Username, command.Role, user.Id);

        return user.Id;
    }
    private string HashPassword(string password)
    {
        // Hashing logic (e.g., BCrypt)
        return password; // Placeholder
    }
}

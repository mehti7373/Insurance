using Insurance.Application.Interfaces;
using Insurance.Core.Entities;
using Insurance.Core.Interfaces;

namespace Insurance.Application.Commands.Users;

public class CreateUserCommandHandler (IUserRepository _userRepository) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(command.Username, HashPassword(command.Password), command.Role);
        await _userRepository.AddAsync(user);
        return user.Id;
    }
private string HashPassword(string password)
{
    // Hashing logic (e.g., BCrypt)
    return password; // Placeholder
}
}

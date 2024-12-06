using Insurance.Application.Interfaces;
using Insurance.Core.Interfaces;

namespace Insurance.Application.Commands.Users;

public class LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    : ICommandHandler<LoginCommand, CommandResponse<LoginCommandResponseModel>>
{
    public async Task<CommandResponse<LoginCommandResponseModel>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameAsync(command.Username);
        if (user == null)
            return CommandResponse<LoginCommandResponseModel>.Faild(["Invalid credentials"]);

        if (user.PasswordHash != HashPassword(command.Password))
            return CommandResponse<LoginCommandResponseModel>.Faild(["Invalid credentials"]);

        var token = tokenService.GenerateToken(user.Username, user.Role);

        var data = new LoginCommandResponseModel(user.Username, token);
        var resposne = CommandResponse<LoginCommandResponseModel>.Success(data);
        return resposne;
    }

    private string HashPassword(string password)
    {
        // Hashing logic (e.g., BCrypt)
        return password; // Placeholder
    }
}
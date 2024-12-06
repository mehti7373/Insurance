using Insurance.Application.Commands.Users;
using Insurance.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    public async Task<CommandResponse<LoginCommandResponseModel>> Login(LoginCommand command,
                                                                        CancellationToken cancellationToken,
                                                                        [FromServices] LoginCommandHandler commandHandler)
    {
        return await commandHandler.Handle(command, cancellationToken);
    }
    [HttpPost("register")]
    public async Task<Guid> Register(CreateUserCommand command,
                               CancellationToken cancellationToken,
                               [FromServices] CreateUserCommandHandler commandHandler)
    {
        return await commandHandler.Handle(command, cancellationToken);
    }
}

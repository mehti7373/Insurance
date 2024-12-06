using Insurance.Core.Entities;

namespace Insurance.Application.Interfaces;

public interface IUserService
{
    Task<bool> ValidatePasswordHash( );
    Task<User> ValidateUserAsync(string username, string password);
    Task<Guid> RegisterUserAsync(string username, string password, string role);
    Task<string> AuthenticateUserAsync(string username, string password);
    Task<bool> UserExistsAsync(string username);
    Task<bool> ValidateTokenAsync(string token);
}

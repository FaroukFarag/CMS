using CMS.Application.Dtos.Users;

namespace CMS.Application.Interfaces.Users;

public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto registerDto);

    Task<string> LoginAsync(LoginDto loginDto);
}

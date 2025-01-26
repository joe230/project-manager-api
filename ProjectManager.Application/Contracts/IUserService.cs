using ProjectManager.Application.DTOs;

namespace ProjectManager.Application.Contracts;

public interface IUserService
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto registerUserDto);
    Task<LoginResponse> LoginUserAsync(LoginDto loginDto);
}

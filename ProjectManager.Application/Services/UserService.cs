using ProjectManager.Application.Contracts;
using ProjectManager.Application.DTOs;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.RepositoryContracts;

namespace ProjectManager.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService){
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<LoginResponse> LoginUserAsync(LoginDto loginDto)
    {
        var getUser = await _userRepository.GetUserByEmail(loginDto.Email);
        if (getUser == null) return new LoginResponse(false, "User not found");

        bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, getUser.Password);
        if (checkPassword) 
            return new LoginResponse(true, "Authentication successfull", _jwtTokenService.GenerateJwtToken(getUser));
        else
            return new LoginResponse(false, "Invalid credentials");
    }

    public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        var getUser = await _userRepository.GetUserByEmail(registerUserDto.Email);
        if(getUser != null) 
            return new RegistrationResponse(false, "User already exists");

        var user = new User
        {
            Username = registerUserDto.Username,
            Email = registerUserDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password),
            CreationDate = DateTime.UtcNow,
            Projects = new List<Project>()
        };
        
        await _userRepository.AddUserAsync(user);
        return new RegistrationResponse(true, "Registration successfull");
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Contracts;
using ProjectManager.Application.DTOs;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto)
        {
            var result = await _userService.LoginUserAsync(loginDto);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else return BadRequest(result);
            
        } 

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterUserDto registerUserDto)
        {
            var result = await _userService.RegisterUserAsync(registerUserDto);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}

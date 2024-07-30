using medic_api.Models.DTOs;
using medic_api.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public AuthController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var user = await userRepository.GetUserByUsernameAndPassword(loginDto.Username, loginDto.Password);

        if (user != null)
        {
            if (user.Role == "Admin")
            {

                return Ok(new { Message = "Login successful" });
            }
            else
            {
                return Unauthorized("User is not an Admin");
            }
        }

        return Unauthorized("Invalid credentials");
    }
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok(new { Message = "Logout successful" });
    }
}
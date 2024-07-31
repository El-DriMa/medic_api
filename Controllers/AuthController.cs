using medic_api.Data;
using medic_api.Models.DTOs;
using medic_api.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepository;
    private readonly ApplicationDbContext dbContext;

    public AuthController(IUserRepository userRepository,ApplicationDbContext dbContext)
    {
        this.userRepository = userRepository;
        this.dbContext = dbContext;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var user = await userRepository.GetUserByUsernameAndPassword(loginDto.Username, loginDto.Password);

        if (user != null)
        {
            if (user.Role == "Admin")
            {
                user.LastLoginDate = DateTime.Now;
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
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
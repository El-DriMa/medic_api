using AutoMapper;
using medic_api.Data;
using medic_api.Models.Domain;
using medic_api.Models.DTOs;
using medic_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Client;

namespace medic_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UsersController(ApplicationDbContext dbContext, IUserRepository userRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var userDomain = await userRepository.GetAllUsers();
            return Ok(mapper.Map<List<UsersDTO>>(userDomain));
        }
        [HttpGet("users/details/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var userDomain=await userRepository.GetById(Id);
            if (userDomain == null) return NotFound();
            return Ok(mapper.Map<UsersDetailsDTO>(userDomain));
        }
        [HttpPost("users/block/{Id}")]
        public async Task<IActionResult> BlockUser(int Id)
        {
            var user=await userRepository.GetById(Id);
            if(user == null) return NotFound();
            user.Status = "Blocked";
            await userRepository.BlockUser(user);
            return NoContent();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO user)
        {
            var existingUser = await userRepository.GetUserByUsernameAndPassword(user.Username,user.PasswordHash);
            if (existingUser != null) { return BadRequest("User already exists"); }

            var domainUser = mapper.Map<User>(user);
            await userRepository.RegisterUser(domainUser);
            return Ok(new { Message = "User registered successfully" });
        }

    }
}

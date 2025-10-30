using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Backend.Services;
using BudgetPlanner.Dtos;
using Microsoft.AspNetCore.Mvc;
using BudgetPlanner.Backend.Interfaces;

namespace BudgetPlanner.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserContoller : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        public UserContoller(IUserService userService, AppDbContext context, ITokenService tokenService)
        {
            _userService = userService;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
        {
            int id = await _userService.CreateUserAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, new { id, username = dto.Username });
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            int? id = await _userService.VerifyPasswordAsync(dto);
            if (id == null)
                return Unauthorized();

            var user = await _userService.GetByIdAsync(id.Value);
            var token = _tokenService.CreateAccessToken(id.Value, user!.Username);

            return Ok(new { AccessToken = token });  
        }
    }
}


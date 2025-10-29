using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Backend.Services;
using BudgetPlanner.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserContoller : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AppDbContext _context;
        public UserContoller(UserService userService, AppDbContext context)
        {
            _userService = userService;
            _context = context;

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            User? user = await _userService.GetByIdAsync(id);
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
            return id == null ? Unauthorized() : Ok(id);
        }
    }
}


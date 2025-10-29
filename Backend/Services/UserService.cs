using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Interfaces;
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace BudgetPlanner.Backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
        _context = context;
        _passwordHasher = passwordHasher;
        }
        public async Task<int> CreateUserAsync(UserDto dto)
        {
        if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
            throw new ArgumentException("Username and password cannot be empty");

        if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
            throw new InvalidOperationException("Username already exists");

        User user = new User { Username = dto.Username };

        string hash = _passwordHasher.HashPassword(user, dto.Password);
        user.SetPasswordHash(hash);

        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.UserId;
        }

        public async Task DeleteUserAsync(int userId)
        {
        }

        public async Task<UserResponseDto?> GetByIdAsync(int id)
        {
        return await _context.Users
            .AsNoTracking()
            .Where(u => u.UserId == id)
            .Select(u => new UserResponseDto
            {
                UserId = u.UserId,
                Username = u.Username

            }).FirstOrDefaultAsync();
        }

        public async Task<int?> VerifyPasswordAsync(LoginDto dto)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null)
            {
                return 0;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    string newHash = _passwordHasher.HashPassword(user, dto.Password);
                    user.SetPasswordHash(newHash);
                    await _context.SaveChangesAsync(); 
                }
                return user.UserId;
            }
            return 0;
        }
    }
}


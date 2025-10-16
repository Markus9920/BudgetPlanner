using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Interfaces;
using BudgetPlanner.Backend.Models;
using System.Threading.Tasks;

namespace BudgetPlanner.Backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(User user)
        {
        }
        
        public async Task Login(/*LoginDto dto*/)
        {
        }

    }
}


using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Dtos;

namespace BudgetPlanner.Backend.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserDto dto);

        Task<UserResponseDto?> GetByIdAsync(int id);

        Task DeleteUserAsync(int userId);

        Task<int?> VerifyPasswordAsync(LoginDto dto);
    }
}

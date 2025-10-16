using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Models;

namespace BudgetPlanner.Backend.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(/*UserDto dto*/);

        Task DeleteUser(int userId);

        Task Login(/*LoginDto dto*/);
    }
}

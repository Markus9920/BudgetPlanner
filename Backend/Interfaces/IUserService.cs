using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Models;

namespace BudgetPlanner.Backend.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);

        Task DeleteUser(User user);

        Task Login(/*LoginDto dto*/);
    }
}

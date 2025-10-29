
using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Models;
using System.Threading.Tasks;

namespace BudgetPlanner.Backend.Interfaces
{
    public interface IExpenseService
    {
        Task AddExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int  expenseId);
        Task UpdateExpenseAsync(NewExpenseDto dto);
        Task SetPaidAsync(int expenseId);
        Task SetUnpaidAsync(int expenseId);

        public IEnumerable<Expense> GetAllExpensesAsync(int userId);
        public IEnumerable<Expense> GetPaidExpensesAsync(int userId);
        public IEnumerable<Expense> GetUnpaidExpensesAsync(int userId);
        public IEnumerable<Expense> GetRecurringExpensesAsync(int userId);
        public IEnumerable<Expense> GetNonRecurringExpensesAsync(int userId);

    }
}

using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Models;
using System.Threading.Tasks;

namespace BudgetPlanner.Backend.Interfaces
{
    public interface IExpenseService
    {
        Task AddExpense(Expense expense);
        Task DeleteExpense(int  expenseId);
        Task UpdateExpense(NewExpenseDto dto);
        Task SetPaid(int expenseId);
        Task SetUnpaid(int expenseId);

        public IEnumerable<Expense> GetAllExpenses(int userId);
        public IEnumerable<Expense> GetPaidExpenses(int userId);
        public IEnumerable<Expense> GetUnpaidExpenses(int userId);
        public IEnumerable<Expense> GetRecurringExpenses(int userId);
        public IEnumerable<Expense> GetNonRecurringExpenses(int userId);

    }
}
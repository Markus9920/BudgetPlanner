
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Backend.Dtos;

namespace BudgetPlanner.Backend.Interfaces
{

    public interface IExpenseService
    {
        void AddExpense(Expense expense);
        void DeleteExpense(int  expenseId);
        void UpdateExpense(UpdateExpenseDto dto);
        void SetPaid(int expenseId);
        void SetUnpaid(int expenseId);

        IEnumerable<Expense> GetAllExpenses(int userId);
        IEnumerable<Expense> GetPaidExpenses(int userId);
        IEnumerable<Expense> GetUnpaidExpenses(int userId);
        IEnumerable<Expense> GetRecurringExpenses(int userId);
        IEnumerable<Expense> GetNonRecurringExpenses(int userId);

    }
}
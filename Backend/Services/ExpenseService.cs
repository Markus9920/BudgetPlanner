using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Interfaces;
using BudgetPlanner.Backend.Models;
using System.Threading.Tasks;

namespace BudgetPlanner.Backend.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _context;
        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExpense(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpense(int expenseId)
        {
              
        }

        public async Task UpdateExpense(UpdateExpenseDto dto)
        {
            
        }

        public async Task SetPaid(int expenseId)
        {
            
        }
        public async Task SetUnpaid(int expenseId)
        {
             
        }

        public IEnumerable<Expense> GetAllExpenses(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetPaidExpenses(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetUnpaidExpenses(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetRecurringExpenses(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetNonRecurringExpenses(int userId)
        {
            return Enumerable.Empty<Expense>();
        }
    }
}

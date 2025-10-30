using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Dtos;
using BudgetPlanner.Backend.Interfaces;
using BudgetPlanner.Backend.Models;
using System.Threading.Tasks;

namespace BudgetPlanner.Backend.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _context;
        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int expenseId)
        {
              
        }

        public async Task UpdateExpenseAsync(NewExpenseDto dto)
        {
            
        }

        public async Task SetPaidAsync(int expenseId)
        {
            
        }
        public async Task SetUnpaidAsync(int expenseId)
        {
             
        }

        public IEnumerable<Expense> GetAllExpensesAsync(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetPaidExpensesAsync(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetUnpaidExpensesAsync(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetRecurringExpensesAsync(int userId)
        {
            return Enumerable.Empty<Expense>();
        }

        public IEnumerable<Expense> GetNonRecurringExpensesAsync(int userId)
        {
            return Enumerable.Empty<Expense>();
        }
    }
}

using BudgetPlanner.Backend.Models;
using BudgetPlanner.Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;
        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("add-expense")]
        public async Task<IActionResult> AddExpense(Expense expense) // pitää käyttää DTO
        {
            await _expenseService.AddExpenseAsync(expense);
            return Ok("Lisäys onnistui!");
        }



    }
}

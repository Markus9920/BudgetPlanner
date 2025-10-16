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

        [HttpPost("add")]
        public async Task<IActionResult> AddExpense(Expense expense)
        {
            await _expenseService.AddExpense(expense);
            return Ok("Lisäys onnistui!");
        }



    }
}

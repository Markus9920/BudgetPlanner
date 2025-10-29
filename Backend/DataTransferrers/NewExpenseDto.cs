

using BudgetPlanner.Backend.Models;

namespace BudgetPlanner.Backend.Dtos
{
    public class NewExpenseDto
    {
        public string? Description { get; set; } = string.Empty;
        public decimal Cost { get; set; } = 0;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; } = 0; //Shows as category name based on id number in frontend
        public RecurrenceType RecurrType { get; set; } = 0;
    }
}
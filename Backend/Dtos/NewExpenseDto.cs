

using BudgetPlanner.Backend.Models;

namespace BudgetPlanner.Backend.Dtos
{
    public class NewExpenseDto
    {
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? CategoryId { get; set; } //Shows as category name based on id number in frontend
        public RecurrenceType RecurrType { get; set; }

        public NewExpenseDto(string description, decimal cost, DateTime expDate, int categoryId, RecurrenceType recurrType)
        { 
            Description = description;
            Cost = cost;
            ExpirationDate = expDate;
            CategoryId = categoryId;
            RecurrType = recurrType;
        }
    }
}







namespace BudgetPlanner.Backend.Models
{


    public class LastOccurrDate
    {

        public int LastOccurrDateId { get; set; } //primary key

        public DateTime LastOccurrence { get; set; }

        public int UserId { get; set; } //Foreing key

        public User? User { get; set; } //reference

        public int ExpenseId { get; set; } //Foreing key

        public Expense? Expense { get; set; } //reference

        public LastOccurrDate() { } //For EF Core

        public LastOccurrDate(int Id, DateTime lastOccur, int userId, int expenseId)
        {
            LastOccurrDateId = Id;
            LastOccurrence = lastOccur;
            UserId = userId;
            ExpenseId = expenseId;

        }
    }
}
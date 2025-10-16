




using System;


namespace BudgetPlanner.Backend.Models
{


    public class Expense
    {
        public int ExpenseId { get; set; } //Primary key, value comes from EF Core. Autoincrement
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpirationDate { get; set; }


        public int UserId { get; set; }
        public bool IsPaid { get; set; }
        public User? User { get; set; }

        //category enum. Can be null
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //Recurremce type. No null
        public int RecurrTypeId { get; set; }
        public Expense() // For EF Core
        {
            Description = string.Empty;     
        } 

        public Expense(string description, decimal cost, DateTime expDate, int userId, int categoryId, int recurrTypeId)
        {
            Description = description;
            UserId = userId;
            IsPaid = false;
            Cost = cost;
            ExpirationDate = expDate;
            CategoryId = categoryId;
            RecurrTypeId = recurrTypeId;
        }
    }
}
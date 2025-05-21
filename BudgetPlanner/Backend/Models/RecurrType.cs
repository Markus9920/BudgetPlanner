




using System.ComponentModel.DataAnnotations;




namespace BudgetPlanner.Backend.Models
{
    public class RecurrType
    {
        public int RecurrTypeId { get; set; } //primary key
        public string Name { get; set; }

        public RecurrType() 
        {
            Name = string.Empty;
        } //For EF Core

        public RecurrType(int recurrTypeId, string name)
        {
            RecurrTypeId = recurrTypeId;
            Name = name;
        }

    }
}
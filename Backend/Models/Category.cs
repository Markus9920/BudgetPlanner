




namespace BudgetPlanner.Backend.Models
{

    public class Category
    {
        public int CategoryId { get; set; } //primary key

        public string Name { get; set; }

        public Category()//For EF Core
        {
            Name = string.Empty;
        }

        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
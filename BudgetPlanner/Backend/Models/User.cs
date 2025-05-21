




namespace BudgetPlanner.Backend.Models
{



    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }


        public User() //For EF Core
        {
            Username = string.Empty;
            Password = string.Empty;
        } 

        public User(int userId, string password, string username)
        {
            UserId = userId;
            Password = password;
            Username = username;
        }
    }
}
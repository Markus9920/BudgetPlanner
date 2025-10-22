using BudgetPlanner.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.Backend.Models
{



    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }


        public List<Expense> Expenses { get; set; } = new();

        public User() //For EF Core
        {
            Username = string.Empty;
            Password = string.Empty;
        } 

        public User(string passwordHash, string username)
        {
            Password = passwordHash;
            Username = username;
        }

        public void SetPasswordHash(string passwordHash) => Password = passwordHash;

        public static implicit operator User?(UserResponseDto? v)
        {
        throw new NotImplementedException();
        }
    }
}

namespace BudgetPlanner.Dtos
{
    public class UserResponseDto
    {
        public int UserId { get; init; }
        public string Username { get; init; } = string.Empty;


        public UserResponseDto() {}

        public UserResponseDto(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }
    }
}


namespace BudgetPlanner.Backend.Interfaces
{
    public interface ITokenService
    {
        string CreateAccessToken(int userId, string username);
        string CreateRefreshToken();

    }
}    
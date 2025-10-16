using BudgetPlanner.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserContoller
    {
        private readonly UserService _userService;
        public UserContoller(UserService userService)
        {
            _userService = userService;
        }
    }
}

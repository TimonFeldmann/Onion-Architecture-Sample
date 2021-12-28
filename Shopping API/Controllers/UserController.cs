using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Entities;
using Shopping.Service.Services;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService shoppingListService)
        {
            _logger = logger;
            _userService = shoppingListService;
        }
        [HttpGet(Name = "Get All Users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost("{name}", Name = "Create User")]
        public async Task<ActionResult<User>> CreateUser([FromRoute] string name)
        {
            var user = await _userService.CreateUserAsync(name);

            return Ok(user);
        }
    }
}
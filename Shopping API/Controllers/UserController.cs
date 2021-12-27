using Microsoft.AspNetCore.Mvc;
using Shopping.Service.Services;
using Shopping_Service.DTOs;

namespace Shopping_API.Controllers
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

        [HttpPost("{name}")]
        public async Task<IActionResult> CreateUser([FromRoute] string name)
        {
            var user = await _userService.CreateUserAsync(name);

            return Ok(user);
        }
    }
}
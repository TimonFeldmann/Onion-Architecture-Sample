using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Service.Services;

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

        [HttpGet("/Users", Name = "Get All Users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost("", Name = "Create User")]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = await _userService.CreateUser(createUserDto);

            return Ok(user);
        }
    }
}
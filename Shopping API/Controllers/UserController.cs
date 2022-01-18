using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Service.Services;

namespace Shopping_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ODataController
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService shoppingListService)
        {
            _logger = logger;
            _userService = shoppingListService;
        }

        [HttpPost("", Name = "Create User")]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = await _userService.CreateUser(createUserDto);

            return Ok(user);
        }

        [HttpPut("{id}", Name = "Update User")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] UpdateUserDto updateUserDto, [FromRoute] Guid id)
        {
            var user = await _userService.UpdateUser(id, updateUserDto);

            return Ok(user);
        }

        [EnableQuery]
        [HttpGet("/odata/User")]
        public ActionResult<IQueryable<User>> GetODataUser()
        {
            return Ok(_userService.GetUsersQueryable());
        }
    }
}
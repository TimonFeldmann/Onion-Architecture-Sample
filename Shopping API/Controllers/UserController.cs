

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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> Logger;
        private readonly UserService UserService;

        public UserController(ILogger<UserController> logger, UserService shoppingListService)
        {
            Logger = logger;
            UserService = shoppingListService;
        }
        [HttpGet("{id}", Name = "Get User By Id")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] Guid id)
        {
            var user = await UserService.GetUser(id);

            return Ok(new UserDto(user));
        }

        [HttpPost("", Name = "Create User")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = await UserService.CreateUser(createUserDto);

            return Ok(new UserDto(user));
        }

        [HttpPut("{id}", Name = "Update User")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserDto updateUserDto, [FromRoute] Guid id)
        {
            var user = await UserService.UpdateUser(id, updateUserDto);

            return Ok(new UserDto(user));
        }

        [EnableQuery]
        [HttpGet("/odata/User", Name = "Get OData User")]
        public ActionResult<IQueryable<UserDto>> GetODataUserDto()
        {
            return Ok(UserService.GetUserDtoQueryable());
        }
    }
}
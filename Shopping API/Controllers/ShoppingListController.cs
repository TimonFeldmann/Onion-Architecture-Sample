using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Entities;
using Shopping.Repository.DTOs;
using Shopping.Service.Services;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly ILogger<ShoppingListController> _logger;
        private readonly ShoppingListService _shoppingListService;

        public ShoppingListController(ILogger<ShoppingListController> logger, ShoppingListService shoppingListService)
        {
            _logger = logger;
            _shoppingListService = shoppingListService;
        }

        [HttpGet("{userId}", Name = "Get Shopping List for User")]
        public async Task<ActionResult<ShoppingList?>> GetShoppingListForUser([FromRoute] Guid userId)
        {
            var shoppingList = await _shoppingListService.GetShoppingListForUserAsync(userId);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        [HttpPost("", Name = "Create Shopping List for User")]
        public async Task<ActionResult<ShoppingList>> CreateShoppingListForUser([FromBody] CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = await _shoppingListService.CreateShoppingListForUserAsync(createShoppingListDto);

            return Ok(shoppingList);
        }
    }
}
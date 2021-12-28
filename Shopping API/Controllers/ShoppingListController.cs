using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Service.Services;

namespace Shopping_API.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> GetShoppingListById (Guid id)
        {
            var shoppingList = await _shoppingListService.GetShoppingListById(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return shoppingList;
        }

        [HttpGet("/User/{userId}", Name = "Get Shopping List for User")]
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

        [HttpPost("/Item/{shoppingListId}")]
        public async Task<ActionResult<ShoppingItem>> CreateShoppingListItem([FromRoute] Guid shoppingListId, [FromBody] CreateShoppingItemDto createShoppingItemDto)
        {
            var shoppingItem = await _shoppingListService.CreateShoppingListItemAsync(shoppingListId, createShoppingItemDto);

            return Ok(shoppingItem);
        }
    }
}
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
        public async Task<ActionResult<ShoppingList>> GetShoppingListById(Guid id)
        {
            var shoppingList = await _shoppingListService.GetShoppingListById(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return shoppingList;
        }

        [HttpGet("User/{id}", Name = "Get Shopping List for User")]
        public async Task<ActionResult<ShoppingList?>> GetShoppingListForUser([FromRoute] Guid id)
        {
            var shoppingList = await _shoppingListService.GetShoppingListForUser(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        [HttpPost("", Name = "Create Shopping List")]
        public async Task<ActionResult<ShoppingList>> CreateShoppingList([FromBody] CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = await _shoppingListService.CreateShoppingList(createShoppingListDto);

            return Ok(shoppingList);
        }

        [HttpPost("{shoppingListId}/Item")]
        public async Task<ActionResult<ShoppingItem>> CreateShoppingListItem([FromRoute] Guid shoppingListId, [FromBody] CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await _shoppingListService.CreateShoppingListItem(shoppingListId, shoppingItemDto);

            return Ok(shoppingItem);
        }

        [HttpPut("{shoppingListId}/Item/{shoppingItemId}")]
        public async Task<ActionResult<ShoppingItem>> UpdateShoppingListItem([FromRoute] Guid shoppingListId, [FromRoute] Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await _shoppingListService.UpdateShoppingListItem(shoppingListId, shoppingItemId, shoppingItemDto);

            return Ok(shoppingItem);
        }
    }
}
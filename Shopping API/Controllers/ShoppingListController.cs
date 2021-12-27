using Microsoft.AspNetCore.Mvc;
using Shopping.Service.Services;
using Shopping_Service.DTOs;

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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetShoppingListForUser([FromRoute] Guid userId)
        {
            var shoppingList = await _shoppingListService.GetShoppingListForUserAsync(userId);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateShoppingListForUser([FromBody] CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = await _shoppingListService.CreateShoppingListForUserAsync(createShoppingListDto);

            return Ok(shoppingList);
        }
    }
}
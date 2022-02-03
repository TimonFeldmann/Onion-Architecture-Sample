using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.Service.Services;

namespace Shopping_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController : ODataController
    {
        private readonly ILogger<ShoppingListController> Loggger;
        private readonly ShoppingListService ShoppinggListService;
        private readonly IShoppingListContext ShoppingListContext;

        public ShoppingListController(ILogger<ShoppingListController> logger, ShoppingListService shoppingListService, IShoppingListContext shoppingListContext)
        {
            Loggger = logger;
            ShoppinggListService = shoppingListService;
            ShoppingListContext = shoppingListContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListDto>> GetShoppingListById(Guid id)
        {
            var shoppingList = await ShoppinggListService.GetShoppingListById(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(new ShoppingListDto(shoppingList));
        }

        [HttpGet("User/{id}", Name = "Get Shopping List for User")]
        public async Task<ActionResult<ShoppingListDto?>> GetShoppingListForUser([FromRoute] Guid id)
        {
            var shoppingList = await ShoppinggListService.GetShoppingListForUser(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(new ShoppingListDto(shoppingList));
        }

        [HttpPost("", Name = "Create Shopping List")]
        public async Task<ActionResult<ShoppingListDto>> CreateShoppingList([FromBody] CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = await ShoppinggListService.CreateShoppingList(createShoppingListDto);

            return Ok(new ShoppingListDto(shoppingList));
        }

        [HttpPost("{shoppingListId}/Item")]
        public async Task<ActionResult<ShoppingItemDto>> CreateShoppingListItem([FromRoute] Guid shoppingListId, [FromBody] CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await ShoppinggListService.CreateShoppingListItem(shoppingListId, shoppingItemDto);

            return Ok(new ShoppingItemDto(shoppingItem));
        }

        [HttpPut("{shoppingListId}/Item/{shoppingItemId}")]
        public async Task<ActionResult<ShoppingItemDto>> UpdateShoppingListItem([FromRoute] Guid shoppingListId, [FromRoute] Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await ShoppinggListService.UpdateShoppingListItem(shoppingListId, shoppingItemId, shoppingItemDto);

            return Ok(new ShoppingItemDto(shoppingItem));

        }

        [EnableQuery]
        [HttpGet("/odata/ShoppingList")]
        public IQueryable<ShoppingListDto> GetODataShoppingList()
        {
            return ShoppinggListService.GetShoppingListDtoQueryable();
        }

        [EnableQuery]
        [HttpGet("/odata/ShoppingListReport")]
        public IQueryable<ShoppingListDto> GetODataShoppingListReport()
        {
            return ShoppinggListService.GetShoppingListReportQueryable();
        }
    }
}
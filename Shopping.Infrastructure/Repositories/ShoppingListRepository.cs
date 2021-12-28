using Microsoft.EntityFrameworkCore;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Infrastructure.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private IShoppingListContext _shoppingListContext { get; set; }
        public ShoppingListRepository(IShoppingListContext shoppingListContext )
        {
            _shoppingListContext = shoppingListContext;
        }
        public async Task<ShoppingList?> GetShoppingListForUser(Guid userId)
        {
            return await _shoppingListContext.ShoppingList
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync() ;
        }
        public ShoppingList CreateShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = MapCreateToShoppingList(createShoppingListDto);

            _shoppingListContext.ShoppingList.Add(shoppingList);

            return shoppingList;
        }

        public async Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateShoppingItemDto createShoppingItemDto)
        {
            var shoppingList = await _shoppingListContext.ShoppingList.FindAsync(shoppingListId);

            if (shoppingList == null)
            {
                throw new Exception($"Shopping list with id {shoppingListId} could not be found while creating a shopping list item");
            }

            var shoppingItem = shoppingList.AddShoppingItem(createShoppingItemDto);

            return shoppingItem;
        }
        private ShoppingList MapCreateToShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            return new ShoppingList(createShoppingListDto);
        }
    }
}

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
        public async Task<ShoppingList> GetShoppingListByIdAsync(Guid shoppingListId)
        {
            var shoppingList = await _shoppingListContext.ShoppingList.FindAsync(shoppingListId);

            if (shoppingList == null)
            {
                throw new Exception($"Shopping list with id {shoppingListId} could not be found while creating a shopping list item");
            }

            return shoppingList;
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

        public async Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingList = await GetShoppingListByIdAsync(shoppingListId);
            var shoppingItem = shoppingList.AddShoppingItem(shoppingItemDto);

            return shoppingItem;
        }

        public async Task<ShoppingItem> UpdateShoppingListItem(Guid shoppingListId, Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingList = await GetShoppingListByIdAsync(shoppingListId);
            var shoppingItem = shoppingList.UpdateShoppingItem(shoppingItemId, shoppingItemDto);

            return shoppingItem;
        }

        private ShoppingList MapCreateToShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            return new ShoppingList(createShoppingListDto);
        }
    }
}

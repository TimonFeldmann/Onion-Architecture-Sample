using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Repository.Contexts;
using Shopping.Repository.Repositories;

namespace Shopping.Service.Services
{
    public class ShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IShoppingListContext _shoppingListContext;

        public ShoppingListService(IShoppingListRepository shoppingListRepository, IShoppingListContext shoppingListContext)
        {
            _shoppingListRepository = shoppingListRepository;
            _shoppingListContext = shoppingListContext;
        }

        public async Task <ShoppingList?> GetShoppingListById(Guid id)
        {
            var shoppingList = await _shoppingListContext.ShoppingList.FindAsync(id);

            return shoppingList;
        }

        public async Task<ShoppingList?> GetShoppingListForUserAsync(Guid userId)
        {
            return await _shoppingListRepository.GetShoppingListForUser(userId);
        }

        public async Task<ShoppingList> CreateShoppingListForUserAsync(CreateShoppingListDto createShoppingListDto)
        {
            var userId = createShoppingListDto.userId;
            var shoppingList = await _shoppingListRepository.GetShoppingListForUser(userId);

            if (shoppingList == null)
            {
                shoppingList = _shoppingListRepository.CreateShoppingList(createShoppingListDto);
            }
            else
            {
                throw new Exception($"Shopping list already exists for user {userId}.");
            }

            await _shoppingListContext.SaveChangesAsync();

            return shoppingList;
        }

        public async Task<ShoppingItem> CreateShoppingListItemAsync(Guid shoppingListId, CreateShoppingItemDto createShoppingItemDto)
        {
            var shoppingItem = await _shoppingListRepository.CreateShoppingListItem(shoppingListId, createShoppingItemDto);

            await _shoppingListContext.SaveChangesAsync();

            return shoppingItem;
        }
    }
}

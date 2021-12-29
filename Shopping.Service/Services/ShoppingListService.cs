using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

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

        public async Task<ShoppingList> GetShoppingListById(Guid shoppingListId)
        {
            var shoppingList = await _shoppingListRepository.GetShoppingListById(shoppingListId);

            return shoppingList;
        }

        public async Task<ShoppingList?> GetShoppingListForUser(Guid userId)
        {
            return await _shoppingListRepository.GetShoppingListForUser(userId);
        }

        public async Task<ShoppingList> CreateShoppingList(CreateShoppingListDto createShoppingListDto)
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

        public async Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await _shoppingListRepository.CreateShoppingListItem(shoppingListId, shoppingItemDto);

            await _shoppingListContext.SaveChangesAsync();

            return shoppingItem;
        }

        public async Task<ShoppingItem> UpdateShoppingListItem(Guid shoppingListId, Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await _shoppingListRepository.UpdateShoppingListItem(shoppingListId, shoppingItemId, shoppingItemDto);

            await _shoppingListContext.SaveChangesAsync();

            return shoppingItem;
        }
    }
}

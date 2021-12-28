using Shopping.Domain.Entities;
using Shopping.Repository.Contexts;
using Shopping.Repository.DTOs;
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

            await _shoppingListContext.SaveChangesAsync();

            return shoppingList;
        }
    }
}

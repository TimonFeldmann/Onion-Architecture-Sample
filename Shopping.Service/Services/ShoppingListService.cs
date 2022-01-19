using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Domain.View_Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Service.Services
{
    public class ShoppingListService
    {
        private readonly IShoppingListRepository ShoppingListRepository;
        private readonly IShoppingListContext ShoppingListContext;

        public ShoppingListService(IShoppingListRepository shoppingListRepository, IShoppingListContext shoppingListContext)
        {
            ShoppingListRepository = shoppingListRepository;
            ShoppingListContext = shoppingListContext;
        }

        public async Task<ShoppingList> GetShoppingListById(Guid shoppingListId)
        {
            var shoppingList = await ShoppingListRepository.GetShoppingListById(shoppingListId);

            return shoppingList;
        }

        public async Task<ShoppingList?> GetShoppingListForUser(Guid userId)
        {
            return await ShoppingListRepository.GetShoppingListForUser(userId);
        }

        public IQueryable<ShoppingListDto> GetShoppingListDtoQueryable()
        {
            return ShoppingListRepository.ConvertToShoppingListDtoQueryable(ShoppingListContext.ShoppingList);
        }

        public IQueryable<ShoppingListReport> GetShoppingListReportQueryable()
        {
            return ShoppingListContext.ShoppingListReport;
        }

        public async Task<ShoppingList> CreateShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            var userId = createShoppingListDto.userId;
            var shoppingList = await ShoppingListRepository.GetShoppingListForUser(userId);

            if (shoppingList == null)
            {
                shoppingList = ShoppingListRepository.CreateShoppingList(createShoppingListDto);
            }
            else
            {
                throw new Exception($"Shopping list already exists for user {userId}.");
            }

            await ShoppingListContext.SaveChangesAsync();

            return shoppingList;
        }

        public async Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await ShoppingListRepository.CreateShoppingListItem(shoppingListId, shoppingItemDto);

            await ShoppingListContext.SaveChangesAsync();

            return shoppingItem;
        }

        public async Task<ShoppingItem> UpdateShoppingListItem(Guid shoppingListId, Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = await ShoppingListRepository.UpdateShoppingListItem(shoppingListId, shoppingItemId, shoppingItemDto);

            await ShoppingListContext.SaveChangesAsync();

            return shoppingItem;
        }
    }
}

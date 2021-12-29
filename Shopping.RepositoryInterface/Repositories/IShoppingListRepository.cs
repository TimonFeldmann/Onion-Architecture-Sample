using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;

namespace Shopping.RepositoryInterface.Repositories
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList> GetShoppingListByIdAsync(Guid shoppingListId);
        Task<ShoppingList> GetShoppingListForUser(Guid userId);
        ShoppingList CreateShoppingList(CreateShoppingListDto shoppingListDto);
        Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateUpdateShoppingItemDto shoppingItemDto);
        Task<ShoppingItem> UpdateShoppingListItem(Guid shoppingListId, Guid shoppingListItemId, CreateUpdateShoppingItemDto shoppingItemDto);
    }
}

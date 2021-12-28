using Shopping.Domain.Entities;
using Shopping.Repository.DTOs;

namespace Shopping.Repository.Repositories
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList?> GetShoppingListForUser(Guid userId);
        ShoppingList CreateShoppingList(CreateShoppingListDto shoppingListDto);
    }
}
 
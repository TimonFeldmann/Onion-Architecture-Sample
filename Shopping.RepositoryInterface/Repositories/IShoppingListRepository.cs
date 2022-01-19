using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Domain.Events;
using Shopping.Domain.View_Entities;

namespace Shopping.RepositoryInterface.Repositories
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList> GetShoppingListById(Guid shoppingListId);
        Task<ShoppingList?> GetShoppingListForUser(Guid userId);
        Task<ShoppingListReport> GetShoppingListReportByShoppingListId(Guid shoppingListId);
        Task<ShoppingListReport> GetShoppingListReportByUserId(Guid userId);
        ShoppingList CreateShoppingList(CreateShoppingListDto shoppingListDto);
        Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateUpdateShoppingItemDto shoppingItemDto);
        Task<ShoppingListReport> CreateShoppingListReport(ShoppingListUpdatedEvent shoppingListUpdateEvent);
        Task<ShoppingItem> UpdateShoppingListItem(Guid shoppingListId, Guid shoppingListItemId, CreateUpdateShoppingItemDto shoppingItemDto);
        Task<ShoppingListReport> UpdateShoppingListReport(ShoppingListUpdatedEvent shoppingListUpdateEvent);
        Task<ShoppingListReport> UpdateShoppingListReportUser(Guid shoppingListReportId, UserUpdatedEvent userUpdatedEvent);
        IQueryable<ShoppingListDto> ConvertToShoppingListDtoQueryable(IQueryable<ShoppingList> shoppingListQueryable);
    }
}

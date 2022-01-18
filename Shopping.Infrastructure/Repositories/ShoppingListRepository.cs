using Microsoft.EntityFrameworkCore;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Domain.Events;
using Shopping.Domain.View_Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Infrastructure.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private IShoppingListContext ShoppingListContext { get; set; }
        private IUserRepository UserRepository { get; set; }

        public ShoppingListRepository(IShoppingListContext shoppingListContext, IUserRepository userRepository)
        {
            ShoppingListContext = shoppingListContext;
            UserRepository = userRepository;
        }
        public async Task<ShoppingList> GetShoppingListById(Guid shoppingListId)
        {
            var shoppingList = await ShoppingListContext.ShoppingList.FindAsync(shoppingListId);

            if (shoppingList == null)
            {
                throw new Exception($"Shopping list with id {shoppingListId} could not be found.");
            }

            return shoppingList;
        }
        public async Task<ShoppingList?> GetShoppingListForUser(Guid userId)
        {
            var shoppingList = await ShoppingListContext.ShoppingList
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            return shoppingList;
        }

        public async Task<ShoppingListReport> GetShoppingListReportByShoppingListId(Guid shoppingListId)
        {
            var shoppingListReport = await ShoppingListContext.ShoppingListReport.FirstOrDefaultAsync(x => x.ShoppingListId == shoppingListId);

            if (shoppingListReport == null)
            {
                throw new Exception($"Shopping list report for shopping list id {shoppingListId} was not found");
            }

            return shoppingListReport;
        }

        public async Task<ShoppingListReport> GetShoppingListReportByUserId(Guid userId)
        {
            var shoppingListReport = await ShoppingListContext.ShoppingListReport.FirstOrDefaultAsync(x => x.UserId == userId);

            if (shoppingListReport == null)
            {
                throw new Exception($"Shopping list report for user id {userId} was not found");
            }

            return shoppingListReport;
        }

        public ShoppingList CreateShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = new ShoppingList(createShoppingListDto);

            ShoppingListContext.ShoppingList.Add(shoppingList);

            return shoppingList;
        }

        public async Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingList = await GetShoppingListById(shoppingListId);
            var shoppingItem = shoppingList.AddShoppingItem(shoppingItemDto);

            return shoppingItem;
        }

        public async Task<ShoppingListReport> CreateShoppingListReport(ShoppingListUpdatedEvent shoppingListUpdatedEvent)
        {
            var user = await UserRepository.GetUserById(shoppingListUpdatedEvent.ShoppingList.UserId);
            var shoppingListReport = new ShoppingListReport()
            {
                ShoppingListId = shoppingListUpdatedEvent.ShoppingList.Id,
                UserId = user.Id,
                UserName = user.Name,
                ShoppingListTotalValue = shoppingListUpdatedEvent.ShoppingListTotalValue
            };

            shoppingListReport.SetShoppingItemNames(shoppingListUpdatedEvent.ShoppingItems);

            ShoppingListContext.ShoppingListReport.Add(shoppingListReport);

            return shoppingListReport;
        }

        public async Task<ShoppingItem> UpdateShoppingListItem(Guid shoppingListId, Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingList = await GetShoppingListById(shoppingListId);
            var shoppingItem = shoppingList.UpdateShoppingItem(shoppingItemId, shoppingItemDto);

            return shoppingItem;
        }

        public async Task<ShoppingListReport> UpdateShoppingListReport(ShoppingListUpdatedEvent shoppingListUpdatedEvent)
        {
            var shoppingListReport = await GetShoppingListReportByShoppingListId(shoppingListUpdatedEvent.ShoppingList.Id);

            shoppingListReport.ShoppingListTotalValue = shoppingListUpdatedEvent.ShoppingListTotalValue;
            shoppingListReport.SetShoppingItemNames(shoppingListUpdatedEvent.ShoppingItems);

            return shoppingListReport;
        }

        public async Task<ShoppingListReport> UpdateShoppingListReportUser(Guid shoppingListReportId, UserUpdatedEvent userUpdatedEvent)
        {
            var shoppingListReport = await ShoppingListContext.ShoppingListReport.FindAsync(shoppingListReportId);

            if (shoppingListReport == null)
            {
                throw new Exception($"ShoppingListReport with id {shoppingListReportId} was not found while updating.");
            }

            shoppingListReport.UserName = userUpdatedEvent.Name;

            return shoppingListReport;
        }
    }
}

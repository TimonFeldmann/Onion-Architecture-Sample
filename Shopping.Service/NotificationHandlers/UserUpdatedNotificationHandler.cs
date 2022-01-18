using MediatR;
using Shopping.Domain.Enumerables;
using Shopping.Domain.Events;
using Shopping.Domain.View_Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Service.NotificationHandlers
{
    public class UserUpdatedNotificationHandler : INotificationHandler<UserUpdatedEvent>
    {
        private IShoppingListRepository ShoppingListRepository { get; set; }
        public UserUpdatedNotificationHandler(IShoppingListRepository shoppingListRepository)
        {
            ShoppingListRepository = shoppingListRepository;
        }

        public async Task Handle(UserUpdatedEvent userUpdatedEvent, CancellationToken cancellationToken)
        {
            await UpdateShoppingListReportUserName(userUpdatedEvent);
        }

        private async Task UpdateShoppingListReportUserName(UserUpdatedEvent userUpdatedEvent)
        {
            var shoppingList = await ShoppingListRepository.GetShoppingListReportByUserId(userUpdatedEvent.Id);

            // Not all users have shoppingg lists.
            if (shoppingList != null)
            {
                // This method will not refetch the shopping list report as it is now cached in the change tracker.
                await ShoppingListRepository.UpdateShoppingListReportUser(shoppingList.Id, userUpdatedEvent);
            }
        }
    }
}

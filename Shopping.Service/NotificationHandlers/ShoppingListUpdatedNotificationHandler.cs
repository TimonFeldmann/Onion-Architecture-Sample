using MediatR;
using Shopping.Domain.Enumerables;
using Shopping.Domain.Events;
using Shopping.Domain.View_Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Service.NotificationHandlers
{
    public class ShoppingListUpdatedNotificationHandler : INotificationHandler<ShoppingListUpdatedEvent>
    {
        private IShoppingListRepository ShoppingListRepository { get; set; }
        public ShoppingListUpdatedNotificationHandler(IShoppingListRepository shoppingListRepository)
        {
            ShoppingListRepository = shoppingListRepository;
        }

        public async Task Handle(ShoppingListUpdatedEvent shoppingListUpdatedEvent, CancellationToken cancellationToken)
        {
            if (shoppingListUpdatedEvent.NotificationEventType == NotificationEventType.Domain)
            {
                await HandleDomainEvent(shoppingListUpdatedEvent, cancellationToken);
            }
        }

        private async Task HandleDomainEvent(ShoppingListUpdatedEvent shoppingListUpdatedEvent, CancellationToken cancellationToken)
        {
            var shoppingListUpdateType = shoppingListUpdatedEvent.ShoppingListUpdateType;

            if (shoppingListUpdateType == ShoppingListUpdateType.Create)
            {
                await ShoppingListRepository.CreateShoppingListReport(shoppingListUpdatedEvent);
            }

            if (shoppingListUpdateType == ShoppingListUpdateType.Update || shoppingListUpdateType == ShoppingListUpdateType.Delete)
            {
                await ShoppingListRepository.UpdateShoppingListReport(shoppingListUpdatedEvent);
            }
        }
    }
}

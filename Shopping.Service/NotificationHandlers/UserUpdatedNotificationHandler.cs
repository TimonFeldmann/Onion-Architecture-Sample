
using Hangfire;
using MediatR;
using Newtonsoft.Json;
using Shopping.Domain.Enumerables;
using Shopping.Domain.Events;
using Shopping.Domain.View_Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;
using System.Diagnostics;

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
            if (userUpdatedEvent.NotificationEventType == NotificationEventType.Domain)
            {
                await HandleDomainEvent(userUpdatedEvent);
            }
            if (userUpdatedEvent.NotificationEventType == NotificationEventType.Integration)
            {
                await HandleIntegrationEvent(userUpdatedEvent);
            }
        }

        private async Task HandleDomainEvent(UserUpdatedEvent userUpdatedEvent)
        {
            await UpdateShoppingListReportUserName(userUpdatedEvent);
        }

        private Task HandleIntegrationEvent(UserUpdatedEvent userUpdatedEvent)
        {
            SendEmailToUpdatedUser(userUpdatedEvent);

            return Task.CompletedTask;
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

        private void SendEmailToUpdatedUser(UserUpdatedEvent userUpdatedEvent)
        {
            BackgroundJob.Enqueue(() => Debug.WriteLine(JsonConvert.SerializeObject(userUpdatedEvent)));
        }
    }
}

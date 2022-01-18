using MediatR;

namespace Shopping.Domain.Events
{
    public class ShoppingItemUpdatedEvent : INotification
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
    }
}

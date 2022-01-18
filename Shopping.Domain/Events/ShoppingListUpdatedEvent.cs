using MediatR;
using Shopping.Domain.Entities;
using Shopping.Domain.Enumerables;

namespace Shopping.Domain.Events
{
    public class ShoppingListUpdatedEvent : INotification
    {
        public ShoppingList ShoppingList { get; set; } = null!;
        public decimal ShoppingListTotalValue { get; set; }
        public List<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
        public ShoppingListUpdateType ShoppingListUpdateType { get; set; }
    }
}

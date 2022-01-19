using Shopping.Domain.DTOs;
using Shopping.Domain.Enumerables;
using Shopping.Domain.Events;
using Shopping.Domain.Generic;

namespace Shopping.Domain.Entities
{
    public class ShoppingList : EventEntity
    {
        private ShoppingList() { }
        public ShoppingList(CreateShoppingListDto shoppingListDto)
        {
            UserId = shoppingListDto.userId;

            CreateUpdateEvent(ShoppingListUpdateType.Create);
        }

        public Guid UserId { get; private set; }
        public List<ShoppingItem> ShoppingItems { get; private set; } = new List<ShoppingItem>();
        public decimal ShoppingListTotalValue
        {
            get => ShoppingItems
                .Select(x => x.Price)
                .Aggregate((decimal)0, (agggregate, current) => agggregate + current);
            private set
            {

            }
        }

        public ShoppingItem AddShoppingItem(CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = new ShoppingItem(shoppingItemDto);

            ShoppingItems.Add(shoppingItem);

            CreateUpdateEvent(ShoppingListUpdateType.Update);

            return shoppingItem;
        }

        public ShoppingItem UpdateShoppingItem(Guid shoppingItemId, CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = ShoppingItems.FirstOrDefault(x => x.Id == shoppingItemId);

            if (shoppingItem == null)
            {
                throw new Exception($"Shopping item with id {shoppingItemId} was not found while updating in shopping list id {Id}.");
            }

            shoppingItem.Update(shoppingItemDto);

            CreateUpdateEvent(ShoppingListUpdateType.Update);

            return shoppingItem;
        }

        public ShoppingItem RemoveShoppingItem(Guid shoppingItemId)
        {
            var shoppingItem = ShoppingItems.FirstOrDefault(x => x.Id == shoppingItemId);

            if (shoppingItem == null)
            {
                throw new Exception($"Shopping item with id {shoppingItemId} was not found while removing in shopping list id {Id}.");
            }

            ShoppingItems.Remove(shoppingItem);

            CreateUpdateEvent(ShoppingListUpdateType.Delete);

            return shoppingItem;
        }

        private void CreateUpdateEvent(ShoppingListUpdateType shoppingListUpdateType)
        {
            DomainEvents.Add(new ShoppingListUpdatedEvent()
            {
                ShoppingList = this,
                ShoppingItems = ShoppingItems,
                ShoppingListTotalValue = ShoppingListTotalValue,
                ShoppingListUpdateType = shoppingListUpdateType
            });
        }
    }
}

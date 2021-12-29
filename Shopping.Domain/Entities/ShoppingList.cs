using Shopping.Domain.DTOs;

namespace Shopping.Domain.Entities
{
    public class ShoppingList
    {
        private ShoppingList() { }
        public ShoppingList(CreateShoppingListDto shoppingListDto)
        {
            Id = Guid.NewGuid();
            UserId = shoppingListDto.userId;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public List<ShoppingItem> ShoppingItems { get; private set; } = new List<ShoppingItem>();

        public ShoppingItem AddShoppingItem(CreateUpdateShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = new ShoppingItem(shoppingItemDto);

            ShoppingItems.Add(shoppingItem);

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

            return shoppingItem;
        }
    }
}

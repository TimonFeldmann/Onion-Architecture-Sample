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

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
        
        public ShoppingItem AddShoppingItem(CreateShoppingItemDto createShoppingItemDto)
        {
            var shoppingItem = new ShoppingItem(createShoppingItemDto);
            
            ShoppingItems.Add(shoppingItem);

            return shoppingItem;
        }

        public ShoppingItem RemoveShoppingItem(Guid shoppingItemId)
        {
            var shoppingItem = ShoppingItems.FirstOrDefault(x => x.Id == shoppingItemId);

            if (shoppingItem == null)
            {
                throw new Exception($"Shopping item with id {shoppingItemId} was not found in shopping list id {Id}.");
            }

            ShoppingItems.Remove(shoppingItem);

            return shoppingItem;
        }
    }
}

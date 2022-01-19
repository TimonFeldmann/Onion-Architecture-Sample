using Shopping.Domain.DTOs;
using Shopping.Domain.Events;
using Shopping.Domain.Generic;

namespace Shopping.Domain.Entities
{
    public class ShoppingItem : EventEntity
    {
        private ShoppingItem() { }
        public ShoppingItem(CreateUpdateShoppingItemDto shoppingItemDto)
        {
            Price = shoppingItemDto.Price;
            Name = shoppingItemDto.Name;
        }

        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }

        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; } = null!;

        public void Update(CreateUpdateShoppingItemDto shoppingItemDto)
        {
            Name = shoppingItemDto.Name;
            Price = shoppingItemDto.Price;
        }
    }
}

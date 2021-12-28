using Shopping.Domain.DTOs;

namespace Shopping.Domain.Entities
{
    public class ShoppingItem
    {
        private ShoppingItem() { }
        public ShoppingItem(CreateUpdateShoppingItemDto shoppingItemDto)
        {
            Id = Guid.NewGuid();
            Price = shoppingItemDto.Price;
            Name = shoppingItemDto.Name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public ShoppingList ShoppingList { get; set; } = null!;

        public void Update(CreateUpdateShoppingItemDto shoppingItemDto)
        {
            Name = shoppingItemDto.Name;
            Price = shoppingItemDto.Price;
        }
    }
}

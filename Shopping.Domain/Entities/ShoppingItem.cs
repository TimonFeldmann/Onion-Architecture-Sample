using Shopping.Domain.DTOs;

namespace Shopping.Domain.Entities
{
    public class ShoppingItem
    {
        private ShoppingItem() { }
        public ShoppingItem(CreateShoppingItemDto createShoppingItemDto)
        {
            Id = Guid.NewGuid();
            Price = createShoppingItemDto.Price;
            Name = createShoppingItemDto.Name;
        }

        public Guid Id { get; set; }

        public decimal Price { get; set; }
        public string Name { get; set; } = null!;

        public ShoppingList ShoppingList { get; set; } = null!;
    }
}

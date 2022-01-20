using Shopping.Domain.Entities;

namespace Shopping.Domain.DTOs
{
    public class ShoppingItemDto
    {
        public Guid Id { get; set; }
        public Guid ShoppingListId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public ShoppingItemDto() { }
        public ShoppingItemDto(ShoppingItem shoppingItem)
        {
            Id = shoppingItem.Id;
            Name = shoppingItem.Name;
            Price = shoppingItem.Price;
            ShoppingListId = shoppingItem.ShoppingListId;
        }
    }
}

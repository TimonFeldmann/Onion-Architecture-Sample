using Shopping.Domain.Entities;

namespace Shopping.Domain.DTOs
{
    public class ShoppingListDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingItemDto> ShoppingItems { get; set; } = new List<ShoppingItemDto>();
        public decimal ShoppingListTotalValue { get; set; }

        public ShoppingListDto() { }
        public ShoppingListDto(ShoppingList shoppingList)
        {
            Id = shoppingList.Id;
            UserId = shoppingList.UserId;
            ShoppingItems = shoppingList.ShoppingItems.Select(x => new ShoppingItemDto(x)).ToList();
            ShoppingListTotalValue = shoppingList.ShoppingListTotalValue;
        }
    }
}

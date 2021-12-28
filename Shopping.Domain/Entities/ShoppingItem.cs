namespace Shopping.Domain.Entities
{
    public class ShoppingItem
    {
        public ShoppingItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public ShoppingList ShoppingList { get; set; } = null!;
    }
}

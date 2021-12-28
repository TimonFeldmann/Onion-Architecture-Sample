namespace Shopping.Domain.DTOs
{
    public class CreateShoppingItemDto
    {
        public decimal Price { get; set; }
        public string Name { get; set; } = null!;
    }
}

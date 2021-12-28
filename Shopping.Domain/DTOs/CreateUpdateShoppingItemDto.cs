namespace Shopping.Domain.DTOs
{
    public class CreateUpdateShoppingItemDto
    {
        public decimal Price { get; set; }
        public string Name { get; set; } = null!;
    }
}

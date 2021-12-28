using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.EntityConfigurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            var shoppingItemBuilder = builder
                .OwnsMany(shoppingList => shoppingList.ShoppingItems);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne<User>().WithOne().HasForeignKey<ShoppingList>(x => x.UserId);

            shoppingItemBuilder.WithOwner(x => x.ShoppingList);
            shoppingItemBuilder.HasKey(x => x.Id);
            shoppingItemBuilder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}

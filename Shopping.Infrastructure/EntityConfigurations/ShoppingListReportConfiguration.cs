
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;
using Shopping.Domain.View_Entities;

namespace Shopping.Infrastructure.EntityConfigurations
{
    public class ShoppingListReportConfiguration : IEntityTypeConfiguration<ShoppingListReport>
    {
        public void Configure(EntityTypeBuilder<ShoppingListReport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne<ShoppingList>().WithOne().HasForeignKey<ShoppingListReport>(x => x.ShoppingListId);
            builder.HasOne<User>().WithOne().HasForeignKey<ShoppingListReport>(x => x.UserId);
        }
    }
}

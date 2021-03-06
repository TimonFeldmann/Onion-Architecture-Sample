// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Shopping.Infrastructure.DBContexts;

#nullable disable

namespace Shopping.Infrastructure.Migrations
{
    [DbContext(typeof(ShoppingListContext))]
    [Migration("20211227030836_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shopping.Domain.ShoppingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("Shopping.Domain.ShoppingList", b =>
                {
                    b.OwnsMany("Shopping.Domain.ShoppingItem", "ShoppingItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<Guid>("ShoppingListId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("ShoppingListId");

                            b1.ToTable("ShoppingItem");

                            b1.WithOwner("ShoppingList")
                                .HasForeignKey("ShoppingListId");

                            b1.Navigation("ShoppingList");
                        });

                    b.Navigation("ShoppingItems");
                });
#pragma warning restore 612, 618
        }
    }
}

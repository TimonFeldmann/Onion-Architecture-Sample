using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using System.Reflection;

namespace Shopping.Infrastructure.DBContexts
{
    internal class ShoppingListContext : DbContext, IShoppingListContext
    {
        public DbSet<ShoppingList> ShoppingList { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;

        public ShoppingListContext(DbContextOptions<ShoppingListContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

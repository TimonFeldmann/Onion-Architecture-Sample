using Microsoft.EntityFrameworkCore;
using Shopping.Domain;
using Shopping.Service.Interfaces;
using System.Reflection;

namespace Shopping.Infrastructure
{
    internal class ShoppingListContext : DbContext, IShoppingListContext
    {
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<User> User { get; set; }

        public ShoppingListContext(DbContextOptions<ShoppingListContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Domain.View_Entities;

namespace Shopping.RepositoryInterface.Contexts
{
    public interface IShoppingListContext
    {
        DbSet<ShoppingList> ShoppingList { get; set; }
        DbSet<ShoppingListReport> ShoppingListReport { get; set; }
        DbSet<User> User { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

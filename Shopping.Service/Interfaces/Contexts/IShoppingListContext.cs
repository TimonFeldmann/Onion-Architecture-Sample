using Microsoft.EntityFrameworkCore;
using Shopping.Domain;

namespace Shopping.Service.Interfaces
{
    public interface IShoppingListContext
    {
        DbSet<ShoppingList> ShoppingList { get; set; }
        DbSet<User> User { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IShoppingListContext _shoppingListContext { get; set; }
        public UserRepository(IShoppingListContext shoppingListContext)
        {
            _shoppingListContext = shoppingListContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _shoppingListContext.User.ToListAsync();
        }
        public User CreateUser(string name)
        {
            var user = new User(name);

            _shoppingListContext.User.Add(user);

            return user;
        }
    }
}

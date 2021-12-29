using Microsoft.EntityFrameworkCore;
using Shopping.Domain.DTOs;
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _shoppingListContext.User.ToListAsync();
        }
        public User CreateUser(CreateUserDto createUserDto)
        {
            var user = new User(createUserDto);

            _shoppingListContext.User.Add(user);

            return user;
        }
    }
}

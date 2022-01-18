using Microsoft.EntityFrameworkCore;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IShoppingListContext ShoppingListContext { get; set; }
        public UserRepository(IShoppingListContext shoppingListContext)
        {
            ShoppingListContext = shoppingListContext;
        }

        public async Task<User> GetUserById(Guid userId)
        {
            var user = await ShoppingListContext.User.FindAsync(userId);

            if (user == null)
            {
                throw new Exception($"Could not find user with id {userId}");
            }

            return user;
        }

        public IQueryable<User> GetUsersQueryable()
        {
            return ShoppingListContext.User.AsQueryable();
        }

        public User CreateUser(CreateUserDto createUserDto)
        {
            var user = new User(createUserDto);

            ShoppingListContext.User.Add(user);

            return user;
        }

        public async Task<User> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await ShoppingListContext.User.FindAsync(id);

            if (user == null)
            {
                throw new Exception($"User with id {id} was not found while updating.");
            }

            user.UpdateUser(updateUserDto.Name);

            return user;
        }
    }
}

using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

namespace Shopping.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IShoppingListContext ShoppingListContext;

        public UserService(IUserRepository userRepository, IShoppingListContext shoppingListContext)
        {
            UserRepository = userRepository;
            ShoppingListContext = shoppingListContext;
        }

        public IQueryable<UserDto> GetUserDtoQueryable()
        {
            return UserRepository.ConvertToUserDtoQueryable(ShoppingListContext.User);
        }

        public async Task<User> GetUser(Guid id)
        {
            return await UserRepository.GetUserById(id);
        }

        public async Task<User> CreateUser(CreateUserDto createUserDto)
        {
            var user = UserRepository.CreateUser(createUserDto);

            await ShoppingListContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await UserRepository.UpdateUser(id, updateUserDto);

            await ShoppingListContext.SaveChangesAsync();

            return user;
        }
    }
}

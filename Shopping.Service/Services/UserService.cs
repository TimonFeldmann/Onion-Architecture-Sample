using Shopping.Domain.Entities;
using Shopping.Repository.Contexts;
using Shopping.Repository.Repositories;

namespace Shopping.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IShoppingListContext _shoppingListContext;

        public UserService(IUserRepository userRepository, IShoppingListContext shoppingListContext)
        {
            _userRepository = userRepository;
            _shoppingListContext = shoppingListContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> CreateUserAsync(string name)
        {
            var user = _userRepository.CreateUser(name);

            await _shoppingListContext.SaveChangesAsync();

            return user;
        }
    }
}

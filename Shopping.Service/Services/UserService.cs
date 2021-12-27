using Shopping.Domain;
using Shopping.Service.Interfaces;
using Shopping.Service.Interfaces.Repositories;
using Shopping_Service.DTOs;

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

        public async Task<User> CreateUserAsync(string name)
        {
            var user = _userRepository.CreateUser(name);

            await _shoppingListContext.SaveChangesAsync();

            return user;
        }
    }
}

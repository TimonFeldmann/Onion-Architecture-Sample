using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.RepositoryInterface.Contexts;
using Shopping.RepositoryInterface.Repositories;

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
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> CreateUser(CreateUserDto createUserDto)
        {
            var user = _userRepository.CreateUser(createUserDto);

            await _shoppingListContext.SaveChangesAsync();

            return user;
        }
    }
}

using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;

namespace Shopping.RepositoryInterface.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        User CreateUser(CreateUserDto createUserDto);
    }
}

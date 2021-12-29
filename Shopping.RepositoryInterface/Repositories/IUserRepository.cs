using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;

namespace Shopping.RepositoryInterface.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        User CreateUser(CreateUserDto createUserDto);
    }
}

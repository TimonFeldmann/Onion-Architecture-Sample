using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;

namespace Shopping.RepositoryInterface.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsersQueryable();
        User CreateUser(CreateUserDto createUserDto);
        Task<User> UpdateUser(Guid id, UpdateUserDto updateUserDto);
        Task<User> GetUserById(Guid id);
    }
}

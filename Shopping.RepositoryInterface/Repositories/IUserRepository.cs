using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;

namespace Shopping.RepositoryInterface.Repositories
{
    public interface IUserRepository
    {
        User CreateUser(CreateUserDto createUserDto);
        Task<User> UpdateUser(Guid id, UpdateUserDto updateUserDto);
        Task<User> GetUserById(Guid id);
        IQueryable<UserDto> ConvertToUserDtoQueryable(IQueryable<User> userQueryable);
    }
}

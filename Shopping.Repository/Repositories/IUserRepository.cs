using Shopping.Domain.Entities;

namespace Shopping.Repository.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        User CreateUser(string name);
    }
}

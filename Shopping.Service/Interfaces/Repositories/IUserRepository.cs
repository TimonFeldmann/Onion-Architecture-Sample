using Shopping.Domain;

namespace Shopping.Service.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User CreateUser(string name);
    }
}

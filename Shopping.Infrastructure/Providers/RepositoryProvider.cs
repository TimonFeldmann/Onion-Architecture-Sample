using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Shopping.Infrastructure.Repositories;
using Shopping.Repository.Repositories;

namespace Shopping.Infrastructure.Providers
{
    public static class RepositoryProvider
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IShoppingListRepository, ShoppingListRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            return serviceCollection;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Shopping.Service.Services;

namespace Shopping.Infrastructure.Providers
{
    public static class ApplicationServiceProvider
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ShoppingListService>();
            serviceCollection.AddScoped<UserService>();

            return serviceCollection;
        }
    }
}
